using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singletones;

namespace Controllers.CameraControllers
{
    public class CameraMovementController : MonoBehaviour
    {
        // Update is called once per frame
        private void Update()
        {
            var player = References.GetPlayer();
            if (player != null)
            {
                transform.position = new Vector3(player.transform.position.x, transform.position.y, -10f);
                //transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, -10f);
            }
        }
    }
}