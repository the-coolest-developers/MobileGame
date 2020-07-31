using Assets.Scripts.Singletones;
using UnityEditor.UIElements;
using UnityEngine;

namespace Controllers.EntityControllers
{
    public class MovementController : MonoBehaviour
    {
        //Внутренние переменные
        public bool FaceRight { get; set; }
        public RaycastHit2D IsOnTheGround => Physics2D.Raycast(transform.position, Vector3.down, 2.75f, 256);

        Rigidbody2D rigidbody2d;

        void Start()
        {
            rigidbody2d = GetComponent<Rigidbody2D>();

            FaceRight = true;
        }

        public bool IsGroundedWithRaycast()
        {
            RaycastHit2D res = IsOnTheGround;

            var color = (res) ? Color.green : Color.red;
            Debug.DrawRay(transform.position, Vector3.down * 2.75f, color);

            print(res.collider);

            return res;
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
        /// Возвращает если двигается. В будущем надо переделать
        /// </summary>
        /// <param name="canMove"></param>
        /// <param name="speedX"></param>
        /// <returns></returns>
        public bool MoveIfPossible(bool canMove, float speedX)
        {
            if (canMove && speedX != 0)
            {
                rigidbody2d.transform.Translate(Vector2.right * speedX);

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
    }
}