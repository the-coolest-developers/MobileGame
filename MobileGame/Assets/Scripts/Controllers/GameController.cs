using Controllers.EntityControllers;
using Controllers.UI_Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controllers
{
    public class GameController : MonoBehaviour
    {
        public GameObject PlayerGameObject;
        public GameObject RespawnPoint;
        public GameObject RespawnButton;

        BattleController PlayerBattleController { get; set; }
        HealthBarController PlayerHealthBarController { get; set; }

        // Start is called before the first frame update
        void Start()
        {
            Time.timeScale = 1;
            PlayerBattleController = PlayerGameObject.GetComponent<BattleController>();
            PlayerHealthBarController = PlayerGameObject.GetComponent<HealthBarController>();

            PlayerBattleController.HealthChanged += HandlePlayerDeath;
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void PauseGame()
        {
            Time.timeScale = 0;
        }
        public void ResumeGame()
        {
            Time.timeScale = 1;
        }

        public void SpawnObject(GameObject gameObject)
        {
            Instantiate(gameObject);
        }

        public void HandlePlayerDeath()
        {
            if (PlayerBattleController.CurrentHealth <= 0)
            {
                PauseGame();

                PlayerHealthBarController.HealthBarTip.SetActive(false);
                RespawnButton.gameObject.SetActive(true);
            }
        }

        public void RespawnPlayer()
        {
            PlayerHealthBarController.HealthBarTip.SetActive(true);
            PlayerBattleController.SetHealthToMax();

            gameObject.transform.position = RespawnPoint.transform.position;

            RespawnButton.gameObject.SetActive(false);

            ResumeGame();
        }
    }
}
