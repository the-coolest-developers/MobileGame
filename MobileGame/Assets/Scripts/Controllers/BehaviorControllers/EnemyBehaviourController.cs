﻿using UnityEngine;
using Unity.Mathematics;

namespace Assets.Scripts.Controllers.BehaviorControllers
{
    public class EnemyBehaviourController : BehaviorController
    {
        //Переменные из Unity Editor
        public float MinDistance;
        public float StrikeDistance;

        void Start()
        {
            InitializeControllers();
            InitializeAttributes();
            SubscribeToEvents();
            SetHealthToMax();
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

                    MovementController.RunToGameObject(GameController.PlayerGameObject, CanMove, CurrentRunningSpeed);
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
    }
}