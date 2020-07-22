using Controllers.EntityControllers;
using Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Controllers.BehaviorControllers
{
    public class BehaviorController : MonoBehaviour
    {
        protected BattleController BattleController;
        protected AnimationController AnimationController;
        protected MovementController MovementController;

        public bool FaceRight => MovementController.FaceRight;
        public bool IsOnTheGround => MovementController.IsOnTheGround;
        public bool CanMove => MovementController.CanMove;
        public float RunningSpeed => MovementController.RunningSpeed;

        public bool IsStriking => BattleController.IsStriking;
        public bool CanStrike => BattleController.CanStrike;
        public float CurrentHealth => BattleController.CurrentHealth;
        public float MaxHealth => BattleController.MaxHealth;

        public void InitializeControllers()
        {
            BattleController = GetComponent<BattleController>();
            AnimationController = GetComponent<AnimationController>();
            MovementController = GetComponent<MovementController>();
        }
        public void Die()
        {
            Destroy(gameObject);
            //Анимация смерти
        }

        public void Strike(Action<float> strikeAction, float additionalDamage = 0)
        {
            if (IsOnTheGround && BattleController.Strike(strikeAction, additionalDamage))
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
