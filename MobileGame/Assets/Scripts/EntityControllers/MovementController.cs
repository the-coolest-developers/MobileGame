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
        protected Rigidbody2D rigidbody2d;
        public AnimationController AnimationController { get; set; }
        public BattleController battleController{ get; set; }

        protected float SpeedX { get; set; } = 0;
        protected bool FaceRight { get; set; }

        protected void Flip()
        {
            
            FaceRight = !FaceRight;
            rigidbody2d.transform.Rotate(0f, 180f, 0f);
        }

        public void RunRight()
        {
            if (!FaceRight)
            {
                Flip();
            }
            SpeedX = RunningSpeed;
        }
        public void RunLeft()
        {
            if (FaceRight)
            {   
                Flip();
            }
            SpeedX = -RunningSpeed;
        }
        public void StopRunning()
        {
            SpeedX = 0;
        }
    }
}
