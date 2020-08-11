using Models.Attributes;
using Singletones;
using UnityEngine;

namespace Controllers.EntityControllers
{
    public class MovementController : MonoBehaviour
    {
        //Внутренние переменные
        public bool FaceRight { get; private set; }
        public RaycastHit2D IsOnTheGround => Physics2D.Raycast(transform.position, Vector2.down, 2.75f, 256);

        private Rigidbody2D Rigidbody2d { get; set; }

        private void Start()
        {
            Rigidbody2d = GetComponent<Rigidbody2D>();

            FaceRight = true;
        }

        private void Update()
        {
            //var pos = GetComponent<Collider2D>().bounds.extents.x + 0.1f;
            //DebugRaycastHit((Vector2)transform.position + new Vector2(pos, 0), Vector2.right, 1);
        }

        public bool DebugRaycastHit(Vector2 position, Vector2 direction, float distance)
        {
            var res = Physics2D.Raycast(position, direction, distance);

            var color = (res) ? Color.green : Color.red;
            Debug.DrawRay(position, direction * distance, color);

            print(res.collider);

            return res;
        }

        public bool DebugRaycastHit(Vector2 position, Vector2 direction, float distance, int layerMask)
        {
            RaycastHit2D res = Physics2D.Raycast(position, direction, distance, layerMask);

            var color = (res) ? Color.green : Color.red;
            Debug.DrawRay(position, direction * distance, color);

            print(res.collider);

            return res;
        }

        private void Flip()
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
                Rigidbody2d.AddForce(Vector2.up * jumpPower);
            }
        }

        /// <summary>
        /// Движение к конкретному обьекту
        /// </summary>
        /// <param name="movementAttributes"></param>
        public void RunToGameObject(MovementAttributes movementAttributes)
        {
            var targetObject = movementAttributes.MovementTarget;
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
            transform.Translate(Vector2.right * speed);
        }
    }
}