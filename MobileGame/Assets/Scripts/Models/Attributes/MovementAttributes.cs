using UnityEngine;

namespace Models.Attributes
{
    [System.Serializable]
    public struct MovementAttributes
    {
        public float jumpPower;
        public float currentMovementSpeed;
        public float runningSpeed;
        public bool canMove;
        public GameObject movementTarget;
    }
}