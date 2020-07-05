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
        public bool FaceRight { get; set; }

        public bool IsOnTheGround { get; set; }
        public bool CanMove;
        public bool IsStriking { get; set; }
        protected BattleController BattleController;
        protected AnimationController AnimationController;
        protected MovementController MovementController;
        public GameController GameController;
        public bool CanStrike;        
        public float CurrentHealth;

        protected void Start()
        {
            BattleController = GetComponent<BattleController>();
            AnimationController = GetComponent<AnimationController>();
            MovementController = GetComponent<MovementController>();
        }
        
        protected virtual void Update()
        {
            if(CurrentHealth <= 0)
            {
                Destroy(gameObject);
            }
        }

        protected virtual void FixedUpdate()
        {
            MovementController.MoveIfPossible();
        }
    }
}
