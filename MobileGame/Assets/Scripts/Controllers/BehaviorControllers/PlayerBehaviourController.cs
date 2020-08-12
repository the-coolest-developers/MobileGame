using Assets.Scripts.Controllers.UI_Controllers;
using Assets.Scripts.Controllers.UI_Controllers.ButtonControllers;
using Singletones;
using UnityEngine;
using UnityEngine.UI;

namespace Controllers.BehaviorControllers
{
    public class PlayerBehaviourController : BehaviorController
    {
        private GameObject RespawnButton { get; set; }

        private LevelController LevelController { get; set; }
        private HoldButtonController StrikeButtonController { get; set; }

        private ProgressBarController ExperienceBarController => ProgressBarControllers["ExperienceBar"];

        private void Start()
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
            LevelController.SetExperience(0);
            LevelController.SetLevel(0);

            BattleController.OnEnemyKilled += HandleOnEnemyKilled;
        }

        private void FixedUpdate()
        {
            if (!IsStriking && CanMove & EntityAttributes.MovementAttributes.CurrentMovementSpeed != 0)
            {
                Move(MovementController.MoveHorizontal, EntityAttributes.MovementAttributes);
                AnimationController.SetIsRunning();
            }
        }

        public void RespawnButton_Click()
        {
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


        private void StrikeButton_Click()
        {
            Strike(BattleController.SingleEnemyStrike, EntityAttributes.BattleAttributes);
        }

        //Это тестовый код. В будущем его обязательно нужно будет переделать. Только для проверки
        private void StrikeButton_Hold()
        {
            var attributes = EntityAttributes.BattleAttributes;
            attributes.Damage += 5;

            Strike(BattleController.SingleEnemyStrike, attributes);
        }

        private void HandleLevelChanged(int level)
        {
            GameObject.Find("LevelText").GetComponent<Text>().text = $"Level {level}";
        }

        private void HandleExperienceChanged(int experience, int newLevelExperience)
        {
            ExperienceBarController.UpdateLine(experience, newLevelExperience);
        }

        private void HandleOnEnemyKilled(string enemyName)
        {
            var givenExperience = GlobalValues.GetEnemyExeprience(enemyName);
            LevelController.AddExperience(givenExperience);
        }

        protected override void HandleDeath()
        {
            GameController.PauseGame();

            RespawnButton.gameObject.SetActive(true);
        }
    }
}