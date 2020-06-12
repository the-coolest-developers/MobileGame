using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Parents
{
    public class MovementController : MonoBehaviour
    {
        //Внешние переменные
        public float JumpPower;
        public float RunningSpeed;

        //Внутренние переменные
        protected Rigidbody2D rigidbody;
        protected AnimationController AnimationController { get; set; }
        protected BattleController BattleController { get; set; }
        protected float SpeedX { get; set; } = 0;
        protected bool FaceRight { get; set; }
    }
}
