using Controllers.BehaviorControllers;
using UnityEngine;

namespace Controllers.BehaviorControllers
{
    public class References
    {
        private static GameObject PlayerGameObject; //{ get; private set; }
        private static GameObject RespawnPoint; //{ get; private set; }

        public static void SetPlayer(GameObject player)
        {
            if(player.GetComponent<PlayerBehaviourController>() != null)
                PlayerGameObject = player;
            
        }
        public static GameObject GetPlayer() => PlayerGameObject;
    }
}