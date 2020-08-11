using Singletones;
using UnityEngine;

namespace Controllers
{
    public class GameController : MonoBehaviour
    {
        public GameObject PlayerGameObject { get; private set; }
        public GameObject RespawnPoint { get; private set; }

        private void Start()
        {
            PlayerGameObject = GameObject.Find("Player");
            RespawnPoint = GameObject.Find("RespawnPoint");

            Time.timeScale = 1;
        }

        private void Update()
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


        public float GetDistanceToPlayer(GameObject self)
        {
            return Tools.GetHorizontalDistance(self, PlayerGameObject);
        }
        public float GetAbsoluteHorizontalDistanceToPlayer(GameObject self)
        {
            return Tools.GetHorizontalAbsoluteDistance(self, PlayerGameObject);
        }
    }
}
