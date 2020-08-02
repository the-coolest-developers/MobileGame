using Assets.Scripts.Controllers.UI_Controllers.ButtonControllers;
using UnityEngine;
using Controllers;
using Assets.Scripts.Controllers.UI_Controllers;
using UnityEngine.UI;

namespace Assets.Scripts.Controllers.BehaviorControllers
{
    public class PlayerBehaviourController : BehaviorController
    {
        public GameObject RespawnButton { get; set; }

        LevelController LevelController { get; set; }
        HoldButtonController StrikeButtonController;

        ProgressBarController ExperienceBarController => ProgressBarControllers["ExperienceBar"];

        void Start()
        {
            InitializeControllers();
            InitializeAttributes();
            SubscribeToEvents();
            SetHealthToMax();

            RespawnButton = GameObject.Find("RespawnButton");
            RespawnButton.gameObject.SetActive(false);

            AnimationController.SetIsNotRunning();

            StrikeButtonController = GameObject.Find("PlayerStrikeButton").GetComponent<HoldButtonController>();
            StrikeButtonController.Button_Click += StrikeButton_Click;
            //Тестовая часть
            StrikeButtonController.Button_Hold += StrikeButton_Hold;

            LevelController = GetComponent<LevelController>();
            LevelController.OnExperienceChanged += HandleExperienceChanged;
            LevelController.OnLevelChanged += HandleLevelChanged;
        }

        void Update()
        {
            if (CurrentHealth <= 0)
            {
                GameController.PauseGame();

                RespawnButton.gameObject.SetActive(true);
            }
        }
        void FixedUpdate()
        {
            LevelController.AddExperience(10);

            if (!IsStriking && CanMove & EntityAttributes.MovementAttributes.CurrentMovementSpeed != 0)
            {
                Move(MovementController.MoveHorizontal, EntityAttributes);
                AnimationController.SetIsRunning();
            }
        }

        public void RespawnButton_Click()
        {
            HealthBarController.TipGameObject.SetActive(true);
            SetHealthToMax();

            gameObject.transform.position = GameController.GetRespawnPosition();

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
            GameObject.Find("LevelText").GetComponent<Text>().text = $"Level {level}";
        }
        void HandleExperienceChanged(int experience, int newLevelExperience)
        {
            ExperienceBarController.UpdateLine(experience, newLevelExperience);
        }
    }
}