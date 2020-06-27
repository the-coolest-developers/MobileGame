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
        public GameObject Player;
        public float HorizontalPower;


        //Внутренние переменные
        protected Rigidbody2D rigidbody2d;
        protected Rigidbody2D PlayerRb;
        protected float LastSpeedX;
        public AnimationController AnimationController { get; set; }
        public BattleController BattleController { get; set; }

        public bool IsOnTheGround { get; set; }
        protected float SpeedX { get; set; }
        protected bool FaceRight { get; set; }


        protected virtual void Start()
        {
            RunningSpeed = RunningSpeed / 100;
            PlayerRb = Player.GetComponent<Rigidbody2D>();
            rigidbody2d = GetComponent<Rigidbody2D>();

            BattleController = GetComponent<BattleController>();
            AnimationController = GetComponent<AnimationController>();

            FaceRight = true;
        }
        protected virtual void FixedUpdate()
        {
            CanMove = !BattleController.IsStriking && SpeedX != 0 && IsOnTheGround;
            Debug.Log(IsOnTheGround);
            MoveIfPossible();

            /*if (SpeedX != 0 & CanMove)
            {
                rigidbody2d.MovePosition(rigidbody2d.position + Vector2.right * SpeedX);

                if (AnimationController != null)
                {
                    AnimationController.SetIsRunning();
                }
            }*/
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
            LastSpeedX = 0;
        }
        public void TurnLeft()
        {
            if (FaceRight)
            {
                Flip();
            }
            SpeedX = -RunningSpeed;
            LastSpeedX = 0;
        }
        public void StopRunning()
        {
            LastSpeedX = SpeedX;
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

        public void MoveIfPossible()
        {
            if (CanMove)
            {
                rigidbody2d.MovePosition(rigidbody2d.position + Vector2.right * SpeedX);
                if(SpeedX == 0)
                {
                    print("It is 0!");
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
                    Debug.Log(IsOnTheGround);
 
                    break;
            }
        }
        /*protected virtual void OnTriggerExit2D(Collider2D collision)
        {
            switch (collision.gameObject.tag)
            {
                case "Ground":
                    IsOnTheGround = false;
                    break;
            }
        }*/
    }
}