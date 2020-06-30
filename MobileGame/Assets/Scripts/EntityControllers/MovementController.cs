using EntityControllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EntityControllers
{
    public abstract class MovementController : MonoBehaviour
    {
        //Внешние переменные
        public float JumpPower;
        public float RunningSpeed;
        public bool CanMove;

        //Внутренние переменные
        protected Rigidbody2D rigidbody2d;
        public AnimationController AnimationController { get; set; }
        public BattleController BattleController { get; set; }

        public bool IsOnTheGround { get; set; }
        protected float SpeedX { get; set; }
        protected bool FaceRight { get; set; }


        protected virtual void Start()
        {
            RunningSpeed = RunningSpeed / 100;
            rigidbody2d = GetComponent<Rigidbody2D>();

            BattleController = GetComponent<BattleController>();
            AnimationController = GetComponent<AnimationController>();

            AnimationController.SetIsNotRunning();
            FaceRight = true;
        }
        protected virtual void FixedUpdate()
        {
            MoveIfPossible();
        }
        void Flip()
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
            AnimationController.SetIsNotRunning();
            SpeedX = 0;
        }
        public void Jump()
        {
            if (IsOnTheGround)
            {
                rigidbody2d.AddForce(Vector2.up * JumpPower);
            }
        }

        public void MoveIfPossible()
        {
            if (CanMove && SpeedX != 0)
            {
                //rigidbody2d.AddForce(Vector2.right * 30);
                rigidbody2d.MovePosition(rigidbody2d.position + Vector2.right * SpeedX);

                if (AnimationController != null)
                {
                    AnimationController.SetIsRunning();
                }
            }
        }

        protected virtual void OnTriggerEnter2D(Collider2D collision)
        {
            switch (collision.gameObject.tag)
            {
                case "Ground":
                    IsOnTheGround = true;
                    break;
            }
        }
        protected virtual void OnTriggerExit2D(Collider2D collision)
        {
            switch (collision.gameObject.tag)
            {
                case "Ground":
                    IsOnTheGround = false;
                    break;
            }
        }
    }
}