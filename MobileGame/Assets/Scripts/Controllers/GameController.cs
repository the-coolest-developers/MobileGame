using Controllers.EntityControllers;
using Controllers.UI_Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controllers
{
    public class GameController : MonoBehaviour
    {
        public GameObject PlayerGameObject { get; set; }
        public GameObject RespawnPoint { get; set; }

        void Start()
        {
            PlayerGameObject = GameObject.Find("Player");
            RespawnPoint = GameObject.Find("RespawnPoint");

            Time.timeScale = 1;
        }

        void Update()
        {

        }

        public void PauseGame() => Time.timeScale = 0;
        public void ResumeGame() => Time.timeScale = 1;

        public void SpawnObject(GameObject gameObject)
        {
            Instantiate(gameObject);
        }

        public Vector3 GetRespawnPosition()
        {
            return RespawnPoint.transform.position;
        }
    }
}
