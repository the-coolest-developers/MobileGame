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

        public bool IsStriking => BattleController.IsStriking;
        public bool CanStrike => BattleController.CanStrike;
        public float CurrentHealth => BattleController.CurrentHealth;
        public float MaxHealth => BattleController.MaxHealth;

        protected virtual void FixedUpdate()
        {
            MovementController.MoveIfPossible();
        }

        public void SetHealthbarValue()
        {

        }
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
    }
}
