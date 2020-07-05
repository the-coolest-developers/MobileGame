using UnityEngine;
using Assets.Scripts.Controllers;
using Assets.Scripts.Controllers.BehaviorControllers;

namespace Controllers.EntityControllers
{
    public class MovementController : MonoBehaviour
    {
        //Внешние переменные
        public float JumpPower;
        public float RunningSpeed;

        //Внутренние переменные
        protected BehaviorController BehaviorController;
        protected Rigidbody2D rigidbody2d;
        public AnimationController AnimationController { get; set; }
        
        //protected float SpeedX { get; set; }
        public float SpeedX;

        void Start()
        {
            RunningSpeed = RunningSpeed / 100;
            rigidbody2d = GetComponent<Rigidbody2D>();

            AnimationController = GetComponent<AnimationController>();

            AnimationController.SetIsNotRunning();
            BehaviorController.FaceRight = true;
            BehaviorController = GetComponent<BehaviorController>();
        }

        void Flip()
        {
            BehaviorController.FaceRight = !BehaviorController.FaceRight;
            rigidbody2d.transform.Rotate(0f, 180f, 0f);
        }
        public void TurnRight()
        {
            if (!BehaviorController.FaceRight)
            {
                Flip();
            }
            SpeedX = RunningSpeed;
        }
        public void TurnLeft()
        {
            if (BehaviorController.FaceRight)
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
            if (BehaviorController.IsOnTheGround)
            {
                rigidbody2d.AddForce(Vector2.up * JumpPower);
            }
        }

        public void MoveIfPossible()
        {
            
            if (BehaviorController.CanMove && !BehaviorController.IsStriking && SpeedX != 0)
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
                    BehaviorController.IsOnTheGround = true;
                    break;
            }
        }
        protected virtual void OnTriggerExit2D(Collider2D collision)
        {
            switch (collision.gameObject.tag)
            {
                case "Ground":
                    BehaviorController.IsOnTheGround = false;
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