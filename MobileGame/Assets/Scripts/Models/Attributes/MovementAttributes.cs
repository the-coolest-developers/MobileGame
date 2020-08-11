using UnityEngine;

namespace Models.Attributes
{
    [System.Serializable]
    public struct MovementAttributes
    {
        public float JumpPower;
        public float CurrentMovementSpeed;
        public float RunningSpeed;
        public bool CanMove;

        public GameObject MovementTarget;
    }
}