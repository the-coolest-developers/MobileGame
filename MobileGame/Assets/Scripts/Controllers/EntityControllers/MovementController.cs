using UnityEngine;

namespace Controllers.EntityControllers
{
    public class MovementController : MonoBehaviour
    {
        //Внешние переменные
        public float JumpPower;
        public float RunningSpeed;

        public bool CanMove;

        //Внутренние переменные
        public bool FaceRight { get; set; }
        public bool IsOnTheGround { get; set; }

        Rigidbody2D rigidbody2d;

        public float SpeedX { get; set; }

        void Start()
        {
            RunningSpeed = RunningSpeed / 100;
            rigidbody2d = GetComponent<Rigidbody2D>();

            FaceRight = true;
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
        }
        public void TurnLeft()
        {
            if (FaceRight)
            {
                Flip();
            }
        }
        public void SetSpeedXToRight()
        {
            SpeedX = RunningSpeed;
        }
        public void SetSpeedXToLeft()
        {
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
            }
        }

        /// <summary>
        /// Returns if it's moving
        /// </summary>
        /// <returns></returns>
        public bool MoveIfPossible()
        {
            if (CanMove && SpeedX != 0)
            {
                if (SpeedX < 0)
                {
                    rigidbody2d.transform.Translate(Vector2.left * SpeedX);
                }
                else
                {
                    rigidbody2d.transform.Translate(Vector2.right * SpeedX);
                }

                return true;
            }

            return false;
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

        public void RunToGameObject(GameObject targetObject)
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