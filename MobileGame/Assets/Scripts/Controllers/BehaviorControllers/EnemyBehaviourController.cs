using UnityEngine;
using System.Linq;
using Controllers.BehaviorControllers;
using Singletones;
using Unity.Mathematics;
using UnityEngine.Serialization;

namespace Assets.Scripts.Controllers.BehaviorControllers
{
    public class EnemyBehaviourController : BehaviorController
    {
        //Переменные из Unity Editor
        [FormerlySerializedAs("MinDistance")]
        public float minDistance;
        [FormerlySerializedAs("StrikeDistance")]
        public float strikeDistance;

        private void Start()
        {
            InitializeControllers();
            InitializeAttributes();
            SubscribeToEvents();
            SetHealthToMax();
        }

        private void Update()
        {
        }

        private void FixedUpdate()
        {
            EntityAttributes.movementAttributes.movementTarget = FindNearestObject("Ally");

            if (!IsStriking)
            {
                var absoluteDistance = Tools.GetHorizontalAbsoluteDistance(gameObject, MovementTarget);

                if (absoluteDistance <= minDistance && absoluteDistance >= strikeDistance & CanMove)
                {
                    SetIsRunning();

                    Move(MovementController.RunToGameObject, EntityAttributes.movementAttributes);
                    AnimationController.SetIsRunning();
                }
                else
                {
                    StopRunning();
                }

                if (absoluteDistance <= strikeDistance)
                {
                    StopRunning();
                    Strike(BattleController.AoeStrike, EntityAttributes.battleAttributes);
                }
            }
        }

        protected override void HandleDeath()
        {
            Destroy(gameObject);
        }
    }
}