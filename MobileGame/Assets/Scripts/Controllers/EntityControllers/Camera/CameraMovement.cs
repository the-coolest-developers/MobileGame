using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controllers.Camera
{
    public class CameraMovement : MonoBehaviour
    {
        //Те, которые указываются в редакторе Unity
        public GameObject Player;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Player != null)
            {
                transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, -10f);
            }
        }
    }
}

