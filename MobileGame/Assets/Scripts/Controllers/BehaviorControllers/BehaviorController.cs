using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Controllers.UI_Controllers;
using Controllers.EntityControllers;
using Models.Attributes;
using Singletones;
using UnityEngine;

namespace Controllers.BehaviorControllers
{
    public abstract class BehaviorController : MonoBehaviour
    {
        protected Dictionary<string, ProgressBarController> ProgressBarControllers { get; private set; }
        private ProgressBarController HealthBarController { get; set; }

        protected BattleController BattleController { get; private set; }
        protected AnimationController AnimationController { get; private set; }
        protected MovementController MovementController { get; private set; }

        protected EntityAttributes EntityAttributes { get; private set; }

        protected GameObject MovementTarget => EntityAttributes.MovementAttributes.MovementTarget;

        protected bool FaceRight => MovementController.FaceRight;
        protected bool IsOnTheGround => MovementController.IsOnTheGround;
        protected bool CanMove => EntityAttributes.MovementAttributes.CanMove;
        protected float RunningSpeed => EntityAttributes.MovementAttributes.RunningSpeed;
        protected float JumpPower => EntityAttributes.MovementAttributes.JumpPower;

        protected bool IsStriking => BattleController.IsStriking;
        protected bool CanStrike => EntityAttributes.BattleAttributes.CanStrike;
        protected float CurrentHealth => EntityAttributes.BattleAttributes.CurrentHealth;
        protected float MaxHealth => EntityAttributes.BattleAttributes.MaxHealth;

        protected float BaseDamage => EntityAttributes.BattleAttributes.Damage;

        public float CurrentRunningSpeed { get; set; }

        protected void InitializeControllers()
        {
            BattleController = GetComponent<BattleController>();
            AnimationController = GetComponent<AnimationController>();
            MovementController = GetComponent<MovementController>();
            EntityAttributes = GetComponent<EntityAttributes>();

            ProgressBarControllers =
                GetComponents<ProgressBarController>().ToDictionary(b => b.ProgressBarName, b => b);

            if (ProgressBarControllers != null && ProgressBarControllers.ContainsKey("HealthBar"))
            {
                HealthBarController = ProgressBarControllers["HealthBar"];
            }
        }

        protected void InitializeAttributes()
        {
            EntityAttributes.BattleAttributes.CurrentHealth = EntityAttributes.BattleAttributes.MaxHealth;
        }

        protected void SubscribeToEvents()
        {
            BattleController.OnDamaged += HandleOnDamaged;
        }

        protected void Strike(Action<BattleAttributes> strikeAction, BattleAttributes battleAttributes)
        {
            if (IsOnTheGround && CanStrike && !IsStriking)
            {
                StopRunning();
                AnimationController.SetIsNotRunning();

                AnimationController.PlayStrikeAnimation();

                BattleController.Strike(strikeAction, battleAttributes);
            }
        }

        protected void MoveRight()
        {
            SetIsRunning();
            MovementController.TurnRight();
        }

        protected void MoveLeft()
        {
            SetIsRunning();
            MovementController.TurnLeft();
        }

        protected void SetIsRunning()
        {
            AnimationController.SetIsRunning();
            EntityAttributes.MovementAttributes.CurrentMovementSpeed =
                EntityAttributes.MovementAttributes.RunningSpeed / 100;
        }

        protected void StopRunning()
        {
            AnimationController.SetIsNotRunning();

            EntityAttributes.MovementAttributes.CurrentMovementSpeed = 0;
        }

        private void HandleOnDamaged(float damage)
        {
            SetHealth(CurrentHealth - damage);

            if (CurrentHealth <= 0)
            {
                EntityAttributes.BattleAttributes.IsDead = true;
                HandleDeath();
            }
        }

        private void HealthChanged(float health)
        {
            if (HealthBarController != null)
            {
                HealthBarController.UpdateLine(CurrentHealth, MaxHealth);
            }
        }

        protected void SetHealth(float value)
        {
            EntityAttributes.BattleAttributes.CurrentHealth = value > MaxHealth ? MaxHealth : value;
            HealthChanged(value);
        }

        protected void SetHealthToMax() => SetHealth(EntityAttributes.BattleAttributes.MaxHealth);

        public void SetHealthToZero() => SetHealth(0);

        protected void Move(Action<MovementAttributes> runningMethod, MovementAttributes movementAttributes)
        {
            if (movementAttributes.CurrentMovementSpeed != 0)
            {
                runningMethod.Invoke(movementAttributes);
            }
        }

        protected GameObject FindNearestObject(string objectTag)
        {
            var objects = GameObject.FindGameObjectsWithTag(objectTag);
            var nearestObject = objects.OrderBy(o => Tools.GetHorizontalAbsoluteDistance(o, gameObject)).First();

            return nearestObject;
        }

        protected abstract void HandleDeath();
    }
}