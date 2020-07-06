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


        // Start is called before the first frame update
        void Start()
        {
            Time.timeScale = 1;
        }

        // Update is called once per frame
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
