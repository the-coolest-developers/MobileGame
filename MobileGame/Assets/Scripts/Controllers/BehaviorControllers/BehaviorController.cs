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

        public void Strike(Action strikeAction)
        {
            if (IsOnTheGround)
            {
                MovementController.StopRunning();
                BattleController.Strike(strikeAction);
            }
        }

        public void MoveRight()
        {
            MovementController.TurnRight();
            MovementController.SetSpeedXToRight();
        }
        public void MoveLeft()
        {
            MovementController.TurnLeft();
            MovementController.SetSpeedXToLeft();
        }
    }
}
