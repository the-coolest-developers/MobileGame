using Controllers.EntityControllers;
using Controllers.UI_Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Controllers.BehaviorControllers;

namespace Controllers
{
    public class GameController : MonoBehaviour
    {
        public GameObject PlayerGameObject;
        public GameObject RespawnPoint;

        float normaltimescale;

        // Start is called before the first frame update
        void Start()
        {
            normaltimescale = Time.timeScale;
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

        public Vector3 GetRespawnPosition()
        {
            return RespawnPoint.transform.position;
        }
    }
}
