using System.Net.NetworkInformation;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Controllers;
using Controllers.UI_Controllers;
using UnityEngine.UI;
using UnityEngine;
using Controllers;
using System;

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
            if (!IsStriking)
            {
                MovementController.MoveIfPossible();
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

        public void Attack()
        {
            Strike(BattleController.SingleEnemyStrike);
        }
    }
}