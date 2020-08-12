using Controllers.BehaviorControllers;
using UnityEngine;

namespace Singletones
{
    public class References
    {
        private static GameObject PlayerGameObject; //{ get; private set; }
        private static GameObject RespawnPoint; //{ get; private set; }

        public static void SetPlayer(GameObject player)
        {
            if (player.GetComponent<PlayerBehaviourController>() != null)
                PlayerGameObject = player;
        }

        public static void SetSpawnPoint(GameObject spawnPoint) => RespawnPoint = spawnPoint;
        
        public static GameObject GetPlayer() => PlayerGameObject;
        public static GameObject GetRespawnPoint() => RespawnPoint;
    }
}