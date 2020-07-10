using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;
using Assets.Scripts.Controllers;

namespace Assets.Scripts.Controllers.BehaviorControllers
{
    public class EnemyBehaviourController : BehaviorController
    {
        public GameObject Player { get; set; }

        //Переменные из Unity Editor
        public float MinDistance;
        public float StrikeDistance;
        
        //Внутренние переменные
        public double PlayerDistance { get; set; }
        Rigidbody2D PlayerRb;
        Rigidbody2D rigidbody2d;

        void Start()
        {
            InitializeControllers();

            Player = GameObject.Find("Player");

            PlayerRb = Player.GetComponent<Rigidbody2D>();
            rigidbody2d = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            if(CurrentHealth <= 0)
            {
                Destroy(gameObject);
                //Анимация смэрти
            }
        }

        void FixedUpdate()
        {
            if (PlayerRb != null && !IsStriking)
            {
                PlayerDistance = rigidbody2d.transform.position.x - PlayerRb.transform.position.x;
                var absoluteDistance = math.abs(PlayerDistance);

                if (absoluteDistance <= MinDistance && absoluteDistance >= StrikeDistance)
                {
                    MovementController.SpeedX = RunningSpeed;

                    MovementController.RunToGameObject(Player);
                    AnimationController.SetIsRunning();
                }
                else
                {
                    MovementController.StopRunning();
                }
                
                if (absoluteDistance <= StrikeDistance)
                {
                    MovementController.StopRunning();
                    Strike(BattleController.AOEStrike);
                }
            }
        }
    }
}