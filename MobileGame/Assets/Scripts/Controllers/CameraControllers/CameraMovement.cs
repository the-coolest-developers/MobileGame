﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controllers.CameraControllers
{
    public class CameraMovement : MonoBehaviour
    {
        private GameController GameController { get; set; }

        private GameObject Player => GameController.PlayerGameObject;

        // Start is called before the first frame update
        private void Start()
        {
            GameController = GameObject.Find("GameControllerObject").GetComponent<GameController>();
        }

        // Update is called once per frame
        private void Update()
        {
            if (Player != null)
            {
                transform.position = new Vector3(Player.transform.position.x, transform.position.y, -10f);
                //transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, -10f);
            }
        }
    }
}