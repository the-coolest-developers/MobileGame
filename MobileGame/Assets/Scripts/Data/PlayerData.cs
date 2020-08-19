using Controllers.BehaviorControllers;
using Models.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Data
{
    [Serializable]
    public class PlayerData
    {
        public PlayerData(GameObject player)
        {
            var data = player.GetComponent<EntityAttributes>();

            battleAttributes = data.battleAttributes;
            //movementAttributes = data.movementAttributes;

            jumpPower = data.movementAttributes.jumpPower;
            currentMovementSpeed = data.movementAttributes.currentMovementSpeed;
            runningSpeed = data.movementAttributes.runningSpeed;
            canMove = data.movementAttributes.canMove;

            pos_x = player.GetComponent<Transform>().position.x;
            pos_y = player.GetComponent<Transform>().position.y;
        }

        public float pos_x;
        public float pos_y;

        public float jumpPower;
        public float currentMovementSpeed;
        public float runningSpeed;
        public bool canMove;

        //public MovementAttributes movementAttributes;
        public BattleAttributes battleAttributes;
        
    }
}
