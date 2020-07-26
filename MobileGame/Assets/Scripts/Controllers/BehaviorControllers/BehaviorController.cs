using Controllers.EntityControllers;
using System;
using UnityEngine;
using Assets.Scripts.Models;
using Assets.Scripts.Models.Attributes;

namespace Assets.Scripts.Controllers.BehaviorControllers
{
    public abstract class BehaviorController : MonoBehaviour
    {
        protected BattleController BattleController { get; set; }
        protected AnimationController AnimationController { get; set; }
        protected MovementController MovementController { get; set; }
        protected EntityAttributes EntityAttributes { get; set; }

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

        public void InitializeControllers()
        {
            BattleController = GetComponent<BattleController>();
            AnimationController = GetComponent<AnimationController>();
            MovementController = GetComponent<MovementController>();
            EntityAttributes = GetComponent<EntityAttributes>();
        }
        public void Die()
        {
            Destroy(gameObject);
            //Анимация смерти
        }

        public void Strike(Action<BattleAttributes> strikeAction, BattleAttributes battleAttributes)
        {
            if (IsOnTheGround && BattleController.Strike(strikeAction, battleAttributes))
            {
                StopRunning();
                AnimationController.SetIsNotRunning();

                AnimationController.PlayStrikeAnimation();
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
            CurrentRunningSpeed = EntityAttributes.MovementAttributes.RunningSpeed / 100;
        }
        public void StopRunning()
        {
            AnimationController.SetIsNotRunning();

            CurrentRunningSpeed = 0;
        }

        public void GetDamage(float damage)
        {
            SetHealth(CurrentHealth - damage);
        }


        protected void InitializeAttributes()
        {
            EntityAttributes.BattleAttributes.CurrentHealth = EntityAttributes.BattleAttributes.MaxHealth;
        }

        public void SetHealth(float value)
        {
            EntityAttributes.BattleAttributes.CurrentHealth = value > MaxHealth ? MaxHealth : value;

            print(CurrentHealth);
        }
        public void SetHealthToMax()
        {
            SetHealth(EntityAttributes.BattleAttributes.MaxHealth);
        }
        public void SetHealthToZero()
        {
            SetHealth(0);
        }
    }
}
