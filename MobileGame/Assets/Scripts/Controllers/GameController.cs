using Singletones;
using UnityEngine;

namespace Controllers
{
    public class GameController : MonoBehaviour
    {
        private void Start()
        {
            //PlayerGameObject = GameObject.Find("Player");
            //RespawnPoint = GameObject.Find("RespawnPoint");

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
            return References.GetRespawnPoint().transform.position;
        }


        public float GetDistanceToPlayer(GameObject self)
        {
            return Tools.GetHorizontalDistance(self, References.GetPlayer());
        }
        public float GetAbsoluteHorizontalDistanceToPlayer(GameObject self)
        {
            return Tools.GetHorizontalAbsoluteDistance(self, References.GetPlayer());
        }
    }
}
