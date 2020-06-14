using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Parents
{
    public abstract class MovementController : MonoBehaviour
    {
        //Внешние переменные
        public float JumpPower;
        public float RunningSpeed;

        //Внутренние переменные
        protected Rigidbody2D rigidbody2d;

        public abstract AnimationController AnimationController { get; set; }
        public abstract BattleController battleController { get; set; }

        protected float SpeedX { get; set; } = 0;
        protected bool FaceRight { get; set; }
        public bool IsOnTheGround { get; set; }

        private void Start()
        {
            rigidbody2d = GetComponent<Rigidbody2D>();

            FaceRight = true;
            IsOnTheGround = true;
        }
        private void FixedUpdate()
        {
            if (SpeedX != 0 & battleController.CanStrike)
            {
                rigidbody2d.MovePosition(rigidbody2d.position + Vector2.right * SpeedX);
                AnimationController.SetIsRunning();
            }
        }

        protected void Flip()
        {
            FaceRight = !FaceRight;
            rigidbody2d.transform.Rotate(0f, 180f, 0f);
        }
        public void TurnRight()
        {
            if (!FaceRight)
            {
                Flip();
            }
            SpeedX = RunningSpeed;
        }
        public void TurnLeft()
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
        public void Jump()
        {
            if (IsOnTheGround)
            {
                rigidbody2d.AddForce(Vector2.up * JumpPower);
                IsOnTheGround = false;
            }
        }

        void OnTriggerEnter2D(Collider2D collision)
        {
            switch (collision.gameObject.tag)
            {
                case "Ground":
                    IsOnTheGround = true;
                    break;
            }
        }
    }
}