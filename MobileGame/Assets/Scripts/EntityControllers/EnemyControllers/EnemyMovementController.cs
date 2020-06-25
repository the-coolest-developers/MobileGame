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

        //Внутренние переменные
        double distance;

        // Update is called once per frame
        protected override void FixedUpdate()
        {
            base.FixedUpdate();

            if (Player != null)
            {
                distance = rigidbody2d.transform.position.x - PlayerRb.transform.position.x;
                var absoluteDistance = math.abs(distance);

                if (absoluteDistance <= MinDistance)
                {
                    RunToPlayer();
                }
            }
        }
        void RunToPlayer()
        {
            if (distance > 0)
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
