using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.UI_Controllers.PlayerControllers;
using EntityControllers;
using Assets.Scripts.UI_Controllers;

namespace EntityControllers.PlayerControllers
{
    public class PlayerBattleController : BattleController
    {
        public GameObject RespawnPoint;
        HealthBarController healthBarController;
        public Button RespawnButton;

        float normaltimescale;
        protected override void Start()
        {
            base.Start();
        
            healthBarController = GetComponent<HealthBarController>();
            normaltimescale = Time.timeScale;
        }
        protected override void FixedUpdate()
        {
            if(CurrentHealth <= 0)
            {
                Time.timeScale = 0f;
                RespawnButton.gameObject.SetActive(true);
            }
        }
        public void Respawn()
        {
            healthBarController.HealthBarTip.SetActive(true);
            SetHealth(MaxHealth);

           ThisObject.transform.position = RespawnPoint.transform.position; 
           Time.timeScale = normaltimescale;
           RespawnButton.gameObject.SetActive(false);
        }
    }
}