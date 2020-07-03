﻿using UnityEngine;

namespace Controllers.EntityControllers
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
        //protected float SpeedX { get; set; }
        public float SpeedX;
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
            if (CanMove && !BattleController.IsStriking && SpeedX != 0)
            {
                if (SpeedX < 0)
                {
                    rigidbody2d.transform.Translate(Vector2.left * SpeedX);
                }
                else
                {
                    rigidbody2d.transform.Translate(Vector2.right * SpeedX);
                }

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

        protected void RunToGameObjetc(GameObject targetObject)
        {
            Rigidbody2D targetObjectRB = targetObject.GetComponent<Rigidbody2D>();
            float distance = rigidbody2d.transform.position.x - targetObjectRB.transform.position.x;
            if (distance > 0)
            {
                TurnLeft();
            }
            else
            {
                TurnRight();
            }

            MoveIfPossible();
        }

    }
}