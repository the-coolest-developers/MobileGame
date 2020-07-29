using UnityEngine;
using Unity.Mathematics;

namespace Assets.Scripts.Controllers.BehaviorControllers
{
    public class EnemyBehaviourController : BehaviorController
    {
        public GameObject Player { get; set; }

        //Переменные из Unity Editor
        public float MinDistance;
        public float StrikeDistance;

        //Внутренние переменные
        public double PlayerDistance { get; set; }
        Rigidbody2D PlayerRb;
        Rigidbody2D rigidbody2d;

        void Start()
        {
            InitializeControllers();
            InitializeAttributes();
            SubscribeToEvents();
            SetHealthToMax();

            Player = GameController.PlayerGameObject;

            PlayerRb = Player.GetComponent<Rigidbody2D>();
            rigidbody2d = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            if (CurrentHealth <= 0)
            {
                Destroy(gameObject);
                //Анимация смерти
            }
        }

        void FixedUpdate()
        {
            if (PlayerRb != null && !IsStriking)
            {
                PlayerDistance = rigidbody2d.transform.position.x - PlayerRb.transform.position.x;
                var absoluteDistance = math.abs(PlayerDistance);

                if (absoluteDistance <= MinDistance && absoluteDistance >= StrikeDistance)
                {
                    SetIsRunning();

                    MovementController.RunToGameObject(Player, CanMove, CurrentRunningSpeed);
                    AnimationController.SetIsRunning();
                }
                else
                {
                    StopRunning();
                }

                if (absoluteDistance <= StrikeDistance)
                {
                    StopRunning();
                    Strike(BattleController.AOEStrike, EntityAttributes.BattleAttributes);
                }
            }
        }
    }
}