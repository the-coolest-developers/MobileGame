using System.Net.NetworkInformation;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Controllers;
using Controllers.UI_Controllers;
using UnityEngine.UI;
using UnityEngine;
using Controllers;

namespace Assets.Scripts.Controllers.BehaviorControllers
{
    public class PlayerBehaviourController : BehaviorController
    {
        public GameController GameController;
        public GameObject RespawnButton;

        HealthBarController HealthBarController;

        void Start()
        {
            InitializeControllers();
            HealthBarController = GetComponent<HealthBarController>();
        }

        void Update()
        {
            //base.Update();
        }
        protected override void FixedUpdate()
        {
            base.FixedUpdate();

            if (CurrentHealth <= 0)
            {
                GameController.PauseGame();

                HealthBarController.HealthBarTip.SetActive(false);
                RespawnButton.gameObject.SetActive(true);
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
    }
}