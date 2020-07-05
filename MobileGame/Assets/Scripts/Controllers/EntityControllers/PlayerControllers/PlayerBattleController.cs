using Controllers.UI_Controllers;
using UnityEngine;
using UnityEngine.UI;

namespace Controllers.EntityControllers.PlayerControllers
{
    public class PlayerBattleController : BattleController
    {
        public GameController GameController;

        public GameObject RespawnPoint;
        HealthBarController healthBarController;
        public Button RespawnButton;

        protected override void Start()
        {
            base.Start();

            healthBarController = GetComponent<HealthBarController>();
        }
        protected override void FixedUpdate()
        {
        }
    }
}