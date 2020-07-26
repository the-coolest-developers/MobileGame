using Controllers.UI_Controllers;
using Assets.Scripts.Controllers.UI_Controllers.ButtonControllers;
using UnityEngine;
using Controllers;
using Assets.Scripts.Models.Attributes;

namespace Assets.Scripts.Controllers.BehaviorControllers
{
    public class PlayerBehaviourController : BehaviorController
    {
        public LevelController LevelController { get; set; }

        public GameController GameController { get; set; }
        public GameObject RespawnButton { get; set; }
        HealthBarController HealthBarController;
        HoldButtonController StrikeButtonController;

        void Start()
        {
            InitializeControllers();
            InitializeAttributes();

            SetHealthToMax();

            HealthBarController = GetComponent<HealthBarController>();

            GameController = GameObject.Find("GameControllerObject").GetComponent<GameController>();
            RespawnButton = GameObject.Find("RespawnButton");
            RespawnButton.gameObject.SetActive(false);

            AnimationController.SetIsNotRunning();

            StrikeButtonController = GameObject.Find("PlayerStrikeButton").GetComponent<HoldButtonController>();
            StrikeButtonController.Button_Click += StrikeButton_Click;
            //Тестовая часть
            StrikeButtonController.Button_Hold += StrikeButton_Hold;

            BattleController.Damaged += GetDamage;


            LevelController = GetComponent<LevelController>();
            LevelController.OnExperienceChanged += HandleExperienceChanged;
            LevelController.OnLevelChanged += HandleLevelChanged;
        }

        void Update()
        {
            if (CurrentHealth <= 0)
            {
                GameController.PauseGame();

                HealthBarController.HealthBarTip.SetActive(false);
                RespawnButton.gameObject.SetActive(true);
            }
        }
        void FixedUpdate()
        {
            if (!IsStriking && MovementController.MoveIfPossible(CanMove, CurrentRunningSpeed))
            {
                AnimationController.SetIsRunning();
            }

            LevelController.AddExperience(105);
        }

        public void RespawnButton_Click()
        {
            HealthBarController.HealthBarTip.SetActive(true);
            SetHealthToMax();

            gameObject.transform.position = GameController.RespawnPoint.transform.position;

            RespawnButton.gameObject.SetActive(false);
            GameController.ResumeGame();
        }

        public void MoveRightButton_Click()
        {
            MoveRight();
        }
        public void MoveLeftButton_Click()
        {
            MoveLeft();
        }
        public void StopMovingButton_Click()
        {
            StopRunning();
        }
        public void JumpButton_Clicked()
        {
            MovementController.Jump(JumpPower);
        }

        public void StrikeButton_Click()
        {
            Strike(BattleController.SingleEnemyStrike, EntityAttributes.BattleAttributes);
        }
        //Это тестовый код. В будущем его обязательно нужно будет переделать. Только для проверки
        public void StrikeButton_Hold()
        {
            var attributes = EntityAttributes.BattleAttributes;
            attributes.Damage += 5;

            Strike(BattleController.SingleEnemyStrike, attributes);
        }

        void HandleLevelChanged(int level)
        {
            print(level);
        }
        void HandleExperienceChanged(int experience)
        {
            //print(experience);
        }
    }
}