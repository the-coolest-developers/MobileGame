using System.Net.NetworkInformation;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Controllers;
using Controllers.UI_Controllers;
using UnityEngine.UI;
using UnityEngine;

namespace Assets.Scripts.Controllers.BehaviorControllers
{
    public class PlayerBehaviourController : BehaviorController
    {
        HealthBarController healthBarController;
        // Start is called before the first frame update
        void Start()
        {
            base.Start();
            healthBarController = GetComponent<HealthBarController>();
        }

        // Update is called once per frame
        protected override void Update()
        {
            //base.Update();
            if(CurrentHealth <= 0 )
            {
                GameController.PauseGame();
                GameController.RespawnButton.gameObject.SetActive(true);
            }
        }
        protected override void FixedUpdate()
        {
            base.FixedUpdate();
        }
    }
}