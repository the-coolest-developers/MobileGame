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
        public AnimationController AnimationController { get; set; }
        protected BattleController BattleController { get; set; }
        protected float SpeedX { get; set; } = 0;
        protected bool FaceRight { get; set; }

        protected void Flip()
        {
            FaceRight = !FaceRight;
            rigidbody.transform.Rotate(0f, 180f, 0f);
        }

        public void RunRight()
        {
            AnimationController.SetIsRunning();
            if (!FaceRight)
            {
                Flip();
            }
            SpeedX = RunningSpeed;
        }
        public void RunLeft()
        {
            AnimationController.SetIsRunning();
            if (FaceRight)
            {   
                Flip();
            }
            SpeedX = -RunningSpeed;
        }
        public void StopRunning()
        {
            AnimationController.SetIsNotRunning();
            SpeedX = 0;
        }
    }
}
