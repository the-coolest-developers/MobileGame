﻿using Controllers.UI_Controllers;
using UnityEngine;
using Controllers;

namespace Assets.Scripts.Controllers.BehaviorControllers
{
    public class PlayerBehaviourController : BehaviorController
    {
        public GameController GameController { get; set; }
        public GameObject RespawnButton { get; set; }

        HealthBarController HealthBarController;

        void Start()
        {
            InitializeControllers();
            HealthBarController = GetComponent<HealthBarController>();

            GameController = GameObject.Find("GameControllerObject").GetComponent<GameController>();
            RespawnButton = GameObject.Find("RespawnButton");
            RespawnButton.gameObject.SetActive(false);

            AnimationController.SetIsNotRunning();
        }

        void Update()
        {
            if (CurrentHealth <= 0)
            {
                GameController.PauseGame();

                HealthBarController.HealthBarTip.SetActive(false);
                RespawnButton.gameObject.SetActive(true);
            }
        }
        void FixedUpdate()
        {
            if (!IsStriking && MovementController.MoveIfPossible())
            {
                AnimationController.SetIsRunning();
            }
        }

        public void Respawn()
        {
            HealthBarController.HealthBarTip.SetActive(true);
            BattleController.SetHealthToMax();

            gameObject.transform.position = GameController.RespawnPoint.transform.position;

            RespawnButton.gameObject.SetActive(false);
            GameController.ResumeGame();
        }


        //Buttons part
        public void MoveRightButton_Click()
        {
            MoveRight();
        }

        public void MoveLeftButton_Click()
        {
            MoveLeft();
        }

        public void StopMovingButton_Click()
        {
            StopMoving();
        }

        public void StrikeButton_Click()
        {
            Strike(BattleController.SingleEnemyStrike);
        }

        public void JumpButton_Clicked()
        {
            MovementController.Jump();
        }
    }
}