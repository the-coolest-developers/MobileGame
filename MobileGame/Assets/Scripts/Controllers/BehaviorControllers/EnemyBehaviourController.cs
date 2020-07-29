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
        GameObject MainEnemy;

        void Start()
        {
            InitializeControllers();
            InitializeAttributes();
            SubscribeToEvents();
            SetHealthToMax();
            MainEnemy = SearhEnemy();
        }

        void Update()
        {
            if (CurrentHealth <= 0)
            {
                Destroy(gameObject);
                //Анимация смерти
            }
        }

        void FixedUpdate()
        {
            if (!IsStriking)
            {
                var PlayerDistance = GameController.GetDistanceToPlayer(gameObject);
                var absoluteDistance = math.abs(PlayerDistance);

                if (absoluteDistance <= MinDistance && absoluteDistance >= StrikeDistance)
                {
                    SetIsRunning();

                    MovementController.RunToGameObject(MainEnemy, CanMove, CurrentRunningSpeed);
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

        GameObject SearhEnemy()
        {
            var enemyes = GameObject.FindGameObjectsWithTag("Ally");

            float MinimalDistance = 1000; 

            GameObject Enemy = null;

            foreach(GameObject e in enemyes)
            {
                float distance = Tools.GetHorizontalAbsoluteDistance(e, gameObject);

                if(distance <= MinimalDistance )
                {
                    Enemy = e;
                    MinimalDistance = distance;
                    MainEnemy = e;
                }
            }
            return Enemy;
        }
    }
}