using UnityEngine;
using UnityEngine.Serialization;

namespace Models.Attributes
{
    [System.Serializable]
    public struct MovementAttributes
    {
        [FormerlySerializedAs("JumpPower")]
        public float jumpPower;
        [FormerlySerializedAs("CurrentMovementSpeed")]
        public float currentMovementSpeed;
        [FormerlySerializedAs("RunningSpeed")]
        public float runningSpeed;
        [FormerlySerializedAs("CanMove")]
        public bool canMove;

        [FormerlySerializedAs("MovementTarget")]
        public GameObject movementTarget;
    }
}