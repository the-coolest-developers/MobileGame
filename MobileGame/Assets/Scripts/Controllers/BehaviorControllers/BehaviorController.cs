using Controllers.EntityControllers;
using System;
using UnityEngine;
using Assets.Scripts.Models;

namespace Assets.Scripts.Controllers.BehaviorControllers
{
    public class BehaviorController : MonoBehaviour
    {
        protected BattleController BattleController { get; set; }
        protected AnimationController AnimationController { get; set; }
        protected MovementController MovementController { get; set; }
        protected EntityAttributes EntityAttributes { get; set; }

        public bool FaceRight => MovementController.FaceRight;
        public bool IsOnTheGround => MovementController.IsOnTheGround;
        public bool CanMove => EntityAttributes.MovementAttributes.CanMove;
        public float RunningSpeed => MovementController.RunningSpeed;

        public bool IsStriking => BattleController.IsStriking;
        public bool CanStrike => EntityAttributes.BattleAttributes.CanStrike;
        public float CurrentHealth => BattleController.CurrentHealth;
        public float MaxHealth => BattleController.MaxHealth;

        public float BaseDamage => EntityAttributes.BattleAttributes.BaseDamage;

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

        public void Strike(Action<float> strikeAction, float damage)
        {
            if (IsOnTheGround && BattleController.Strike(strikeAction, damage))
            {
                MovementController.StopRunning();
                AnimationController.SetIsNotRunning();

                AnimationController.PlayStrikeAnimation();
            }
        }

        public void MoveRight()
        {
            AnimationController.SetIsRunning();

            MovementController.TurnRight();
            MovementController.SetSpeedXToRight();
        }
        public void MoveLeft()
        {
            AnimationController.SetIsRunning();

            MovementController.TurnLeft();
            MovementController.SetSpeedXToLeft();
        }
        public void StopMoving()
        {
            AnimationController.SetIsNotRunning();

            MovementController.StopRunning();
        }
    }
}
