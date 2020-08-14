using Singletones;
using UnityEngine;

namespace Controllers
{
    public class GameController : MonoBehaviour
    {
        private static GameObject PlayerGameObject { get; set; }
        private static GameObject RespawnPoint { get; set; }

        private void Start()
        {
            PlayerGameObject = GameObject.Find("Player");
            RespawnPoint = GameObject.Find("RespawnPoint");

            Time.timeScale = 1;
        }

        public static void PauseGame() => Time.timeScale = 0;
        public static void ResumeGame() => Time.timeScale = 1;

        public void SpawnObject(GameObject spawnedObject)
        {
            Instantiate(spawnedObject);
        }

        public float GetDistanceToPlayer(GameObject self)
        {
            return Tools.GetHorizontalDistance(self, PlayerGameObject);
        }

        public float GetAbsoluteHorizontalDistanceToPlayer(GameObject self)
        {
            return Tools.GetHorizontalAbsoluteDistance(self, PlayerGameObject);
        }

        public static GameObject GetPlayer() => PlayerGameObject;
        public static GameObject GetRespawnPoint() => RespawnPoint;
        public static Vector2 GetRespawnPosition() => GetRespawnPoint().transform.position;
    }
}