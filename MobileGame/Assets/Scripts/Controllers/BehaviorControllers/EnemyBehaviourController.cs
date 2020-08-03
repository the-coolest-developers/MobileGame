using UnityEngine;
using System.Linq;
using Assets.Scripts.Singletones;
using Unity.Mathematics;

namespace Assets.Scripts.Controllers.BehaviorControllers
{
    public class EnemyBehaviourController : BehaviorController
    {
        //Переменные из Unity Editor
        public float MinDistance;
        public float StrikeDistance;

        public int GivenExperience;

        void Start()
        {
            InitializeControllers();
            InitializeAttributes();
            SubscribeToEvents();
            SetHealthToMax();
            EntityAttributes.MovementAttributes.MovementTarget = FindNearestObject("Ally");
        }

        void Update()
        {
        }

        void FixedUpdate()
        {
            if (!IsStriking)
            {
                var PlayerDistance = GameController.GetDistanceToPlayer(gameObject);
                var absoluteDistance = math.abs(PlayerDistance);

                if (absoluteDistance <= MinDistance && absoluteDistance >= StrikeDistance & CanMove)
                {
                    SetIsRunning();

                    Move(MovementController.RunToGameObject, EntityAttributes.MovementAttributes);
                    AnimationController.SetIsRunning();
                }
                else
                {
                    StopRunning();
                }

                if (absoluteDistance <= StrikeDistance)
                {
                    StopRunning();
                    Strike(BattleController.AOEStrike, EntityAttributes.BattleAttributes);
                }
            }
        }

        protected override void HandleDeath()
        {
            Destroy(gameObject);
        }
    }
}