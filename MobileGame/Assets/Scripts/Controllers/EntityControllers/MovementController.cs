using Assets.Scripts.Singletones;
using UnityEditor.UIElements;
using UnityEngine;
using Assets.Scripts.Models;
using Assets.Scripts.Models.Attributes;

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

        /// <summary>
        /// Для дебага
        /// </summary>
        /// <returns></returns>
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
        /// Движение к кокнкретному обьекту
        /// </summary>
        /// <param name="movementAttributes"></param>
        public void RunToGameObject(MovementAttributes movementAttributes)
        {
            GameObject targetObject = movementAttributes.MovementTarget;
            float distance = Tools.GetHorizontalDistance(gameObject, targetObject);
            if (distance > 0)
            {
                TurnLeft();
            }
            else
            {
                TurnRight();
            }

            MoveHorizontal(movementAttributes);
        }

        /// <summary>
        /// Обычное движение
        /// </summary>
        /// <param name="movementAttributes"></param>
        public void MoveHorizontal(MovementAttributes movementAttributes)
        {
            float speed = movementAttributes.CurrentMovementSpeed;
            rigidbody2d.transform.Translate(Vector2.right * speed);
        }
    }
}