﻿using UnityEngine;


namespace Controllers.EntityControllers.EnemyControllers
{
    public class EnemyMovementController : MovementController
    {

        //Внутренние переменные
        
        // Update is called once per frame
       /* protected override void Start()
        {
            base.Start();

            PlayerRb = Player.GetComponent<Rigidbody2D>();
        }
        protected override void FixedUpdate()
        {
            base.FixedUpdate();

            if (PlayerRb != null)
            {
                PlayerDistance = rigidbody2d.transform.position.x - PlayerRb.transform.position.x;
                var absoluteDistance = math.abs(PlayerDistance);

                if (absoluteDistance <= MinDistance && absoluteDistance >= StrikeDistance)
                {
                    SpeedX = RunningSpeed;

                    RunToGameObjetc(Player);
                }
                else
                {
                    StopRunning();
                }
            }
        }*/
    }
}
