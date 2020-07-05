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

        float normaltimescale;

        // Start is called before the first frame update
        void Start()
        {
            normaltimescale = Time.timeScale;
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
            Time.timeScale = 0f;
        }
        public void ResumeGame()
        {
            Time.timeScale = normaltimescale;
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
