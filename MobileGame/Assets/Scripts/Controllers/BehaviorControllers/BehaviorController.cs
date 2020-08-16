using System;
using System.Collections.Generic;
using System.Linq;
using Controllers.EntityControllers;
using Controllers.UI_Controllers;
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

        protected GameObject MovementTarget => EntityAttributes.movementAttributes.movementTarget;

        protected bool FaceRight => MovementController.FaceRight;
        protected bool IsOnTheGround => MovementController.IsOnTheGround;
        protected bool CanMove => EntityAttributes.movementAttributes.canMove;
        protected float RunningSpeed => EntityAttributes.movementAttributes.runningSpeed;
        protected float JumpPower => EntityAttributes.movementAttributes.jumpPower;

        protected bool IsStriking => BattleController.IsStriking;
        protected bool CanStrike => EntityAttributes.battleAttributes.weaponAttributes.canStrike;
        protected float CurrentHealth => EntityAttributes.battleAttributes.CurrentHealth;
        protected float MaxHealth => EntityAttributes.battleAttributes.armorAttributes.maxHealth;

        protected float BaseDamage => EntityAttributes.battleAttributes.weaponAttributes.damage;

        public float CurrentRunningSpeed => EntityAttributes.movementAttributes.currentMovementSpeed;

        protected void InitializeControllers()
        {
            BattleController = GetComponent<BattleController>();
            AnimationController = GetComponent<AnimationController>();
            MovementController = GetComponent<MovementController>();
            EntityAttributes = GetComponent<EntityAttributes>();

            ProgressBarControllers =
                GetComponents<ProgressBarController>().ToDictionary(b => b.progressBarName, b => b);

            if (ProgressBarControllers != null && ProgressBarControllers.ContainsKey("HealthBar"))
            {
                HealthBarController = ProgressBarControllers["HealthBar"];
            }
        }

        protected void InitializeAttributes()
        {
            EntityAttributes.battleAttributes.CurrentHealth = EntityAttributes.battleAttributes.armorAttributes.maxHealth;
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
            EntityAttributes.movementAttributes.currentMovementSpeed =
                EntityAttributes.movementAttributes.runningSpeed / 100;
        }

        protected void StopRunning()
        {
            AnimationController.SetIsNotRunning();

            EntityAttributes.movementAttributes.currentMovementSpeed = 0;
        }

        private void HandleOnDamaged(float damage)
        {
            SetHealth(CurrentHealth - damage);

            if (CurrentHealth <= 0)
            {
                EntityAttributes.battleAttributes.IsDead = true;
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
            EntityAttributes.battleAttributes.CurrentHealth = value > MaxHealth ? MaxHealth : value;
            HealthChanged(value);
        }

        protected void SetHealthToMax() => SetHealth(EntityAttributes.battleAttributes.armorAttributes.maxHealth);

        public void SetHealthToZero() => SetHealth(0);

        protected void Move(Action<MovementAttributes> runningMethod, MovementAttributes movementAttributes)
        {
            if (movementAttributes.currentMovementSpeed != 0)
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