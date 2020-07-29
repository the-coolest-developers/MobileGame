using Assets.Scripts.Singletones;
using UnityEngine;

namespace Controllers.EntityControllers
{
    public class MovementController : MonoBehaviour
    {
        //Внутренние переменные
        public bool FaceRight { get; set; }
        public bool IsOnTheGround { get; set; }

        Rigidbody2D rigidbody2d;


        void Start()
        {
            rigidbody2d = GetComponent<Rigidbody2D>();

            FaceRight = true;
        }

        void Flip()
        {
            FaceRight = !FaceRight;
            Tools.FlipGameObject(gameObject);
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

        public void Jump(float jumpPower)
        {
            if (IsOnTheGround)
            {
                rigidbody2d.AddForce(Vector2.up * jumpPower);
            }
        }

        /// <summary>
        /// Returns if it's moving
        /// </summary>
        /// <returns></returns>
        public bool MoveIfPossible(bool canMove, float speedX)
        {
            if (canMove && speedX != 0)
            {
                if (speedX < 0)
                {
                    rigidbody2d.transform.Translate(Vector2.left * speedX);
                }
                else
                {
                    rigidbody2d.transform.Translate(Vector2.right * speedX);
                }

                return true;
            }

            return false;
        }

        public void RunToGameObject(GameObject targetObject, bool canMove, float speedX)
        {
            float distance = Tools.GetHorizontalDistance(gameObject, targetObject);
            if (distance > 0)
            {
                TurnLeft();
            }
            else
            {
                TurnRight();
            }

            MoveIfPossible(canMove, speedX);
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