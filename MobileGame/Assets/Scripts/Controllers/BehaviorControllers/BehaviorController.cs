using Controllers.EntityControllers;
using System;
using UnityEngine;
using Assets.Scripts.Models;
using Assets.Scripts.Models.Attributes;
using Assets.Scripts.Controllers.UI_Controllers;
using Controllers;
using Assets.Scripts.Singletones;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts.Controllers.BehaviorControllers
{
    public abstract class BehaviorController : MonoBehaviour
    {
        protected BattleController BattleController { get; set; }
        protected AnimationController AnimationController { get; set; }
        protected MovementController MovementController { get; set; }
        protected EntityAttributes EntityAttributes { get; set; }

        protected Dictionary<string, ProgressBarController> ProgressBarControllers { get; set; }

        protected ProgressBarController HealthBarController { get; set; }

        protected GameController GameController { get; set; }


        public bool FaceRight => MovementController.FaceRight;
        public bool IsOnTheGround => MovementController.IsOnTheGround;
        public bool CanMove => EntityAttributes.MovementAttributes.CanMove;
        public float RunningSpeed => EntityAttributes.MovementAttributes.RunningSpeed;
        public float JumpPower => EntityAttributes.MovementAttributes.JumpPower;

        public bool IsStriking => BattleController.IsStriking;
        public bool CanStrike => EntityAttributes.BattleAttributes.CanStrike;
        public float CurrentHealth => EntityAttributes.BattleAttributes.CurrentHealth;
        public float MaxHealth => EntityAttributes.BattleAttributes.MaxHealth;

        public float BaseDamage => EntityAttributes.BattleAttributes.Damage;

        public float CurrentRunningSpeed { get; set; }

        protected void InitializeControllers()
        {
            BattleController = GetComponent<BattleController>();
            AnimationController = GetComponent<AnimationController>();
            MovementController = GetComponent<MovementController>();
            EntityAttributes = GetComponent<EntityAttributes>();

            ProgressBarControllers = GetComponents<ProgressBarController>().ToDictionary(b => b.ProgressBarName, b => b);

            if (ProgressBarControllers != null && ProgressBarControllers.ContainsKey("HealthBar"))
            {
                HealthBarController = ProgressBarControllers["HealthBar"];
            }

            GameController = GameObject.Find("GameControllerObject").GetComponent<GameController>();
        }
        protected void InitializeAttributes()
        {
            EntityAttributes.BattleAttributes.CurrentHealth = EntityAttributes.BattleAttributes.MaxHealth;
        }
        protected void SubscribeToEvents()
        {
            BattleController.OnDamaged += HandleOnDamaged;
        }

        public void Strike(Action<BattleAttributes> strikeAction, BattleAttributes battleAttributes)
        {
            if (IsOnTheGround && CanStrike && !IsStriking)
            {
                StopRunning();
                AnimationController.SetIsNotRunning();

                AnimationController.PlayStrikeAnimation();

                BattleController.Strike(strikeAction, battleAttributes);
            }
        }

        public void MoveRight()
        {
            SetIsRunning();
            MovementController.TurnRight();
        }
        public void MoveLeft()
        {
            SetIsRunning();
            MovementController.TurnLeft();
        }
        public void SetIsRunning()
        {
            AnimationController.SetIsRunning();
            EntityAttributes.MovementAttributes.CurrentMovementSpeed = EntityAttributes.MovementAttributes.RunningSpeed / 100;
        }
        public void StopRunning()
        {
            AnimationController.SetIsNotRunning();

            EntityAttributes.MovementAttributes.CurrentMovementSpeed = 0;
        }

        public void HandleOnDamaged(float damage)
        {
            SetHealth(CurrentHealth - damage);

            if (CurrentHealth <= 0)
            {
                HandleDeath();
            }
        }
        public void HealthChanged(float health)
        {
            if (HealthBarController != null)
            {
                HealthBarController.UpdateLine(CurrentHealth, MaxHealth);
            }
        }

        public void SetHealth(float value)
        {
            EntityAttributes.BattleAttributes.CurrentHealth = value > MaxHealth ? MaxHealth : value;
            HealthChanged(value);
        }
        public void SetHealthToMax() => SetHealth(EntityAttributes.BattleAttributes.MaxHealth);

        public void SetHealthToZero() => SetHealth(0);

        public void Move(Action<MovementAttributes> RunningMethod, MovementAttributes movementAttributes)
        {
            if (movementAttributes.CurrentMovementSpeed != 0)
            {
                RunningMethod.Invoke(movementAttributes);
            }
        }

        protected GameObject FindNearestObject(string Tag)
        {
            var Objects = GameObject.FindGameObjectsWithTag(Tag);
            var NearestObject = Objects.OrderBy(o => Tools.GetHorizontalAbsoluteDistance(o, gameObject)).First();

            return NearestObject;
        }

        protected abstract void HandleDeath();
    }
}
