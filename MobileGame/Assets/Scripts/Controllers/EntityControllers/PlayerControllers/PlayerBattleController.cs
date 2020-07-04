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
            if (CurrentHealth <= 0)
            {
                GameController.PauseGame();
                RespawnButton.gameObject.SetActive(true);
            }
        }
        public void Respawn()
        {
            healthBarController.HealthBarTip.SetActive(true);
            SetHealth(MaxHealth);

            gameObject.transform.position = RespawnPoint.transform.position;

            GameController.ResumeGame();

            RespawnButton.gameObject.SetActive(false);
        }
    }
}