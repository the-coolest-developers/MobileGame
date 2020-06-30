using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Unity.Mathematics;
using EntityControllers;

namespace EntityControllers.EnemyControllers
{
    public class EnemyMovementController : MovementController
    {
        //Переменные из Unity Editor
        public float MinDistance;
        public float StrikeDistance;

        public Rigidbody2D PlayerRb;

        //Внутренние переменные
        public double PlayerDistance { get; set; }

        // Update is called once per frame
        protected override void FixedUpdate()
        {
            base.FixedUpdate();

            if (PlayerRb != null)
            {
                PlayerDistance = rigidbody2d.transform.position.x - PlayerRb.transform.position.x;
                var absoluteDistance = math.abs(PlayerDistance);

                if (absoluteDistance <= MinDistance)
                {
                    SpeedX = RunningSpeed;

                    RunToPlayer();
                }
                else
                {
                    StopRunning();
                }
            }
        }
        void RunToPlayer()
        {
            if (PlayerDistance > 0)
            {
                TurnLeft();
            }
            else
            {
                TurnRight();
            }

            MoveIfPossible();
        }
    }
}
