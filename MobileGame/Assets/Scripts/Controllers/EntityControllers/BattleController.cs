using System.IO;
using Controllers.UI_Controllers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine; 
using Assets.Scripts.Controllers.BehaviorControllers;

namespace Controllers.EntityControllers
{
    public class BattleController : MonoBehaviour
    {
        public HealthBarController HealthBarController { get; protected set; }
        public MovementController MovementController { get; protected set; }
        public AnimationController AnimationController { get; protected set; }
        BehaviorController BehaviorController;

        public event Action HealthChanged;

        protected List<GameObject> TriggeredEnemies { get; set; }


        //Переменные из Editor
        public int MaxHealth;
        public int Damage;
        public int AttackedEnemiesAmount;
        public float SplashDamageLossPercent;
        public float HitDelay;
        public float StrikePeriod;
        public string EnemyTag;

        public void SetHealthToMax()
        {
            SetHealth(MaxHealth);
        }
        public void SetHealthToZero()
        {
            SetHealth(0);
        }
        public void SetHealth(float value)
        {
            BehaviorController.CurrentHealth = value > MaxHealth ? MaxHealth : value;

            HealthChanged();
        }
        public void GetDamage(float damageAmount) => SetHealth(BehaviorController.CurrentHealth - damageAmount);

        public void AOEStrike()
        {
            if (BehaviorController.CanStrike && !BehaviorController.IsStriking && BehaviorController.IsOnTheGround)
            {
                StartCoroutine(StrikePeriodCoroutine());

                MovementController.StopRunning();
                AnimationController.PlayStrikeAnimation();

                StartCoroutine(HitEnemyCoroutine(AOEHit));
            }
        }
        public void Strike()
        {
            if (BehaviorController.CanStrike && ! BehaviorController.IsStriking && BehaviorController.IsOnTheGround)
            {
                StartCoroutine(StrikePeriodCoroutine());

                MovementController.StopRunning();
                AnimationController.PlayStrikeAnimation();

                StartCoroutine(HitEnemyCoroutine(HitEnemy));
            }
        }
        protected IEnumerator StrikePeriodCoroutine()
        {
            BehaviorController.IsStriking = true;

            yield return new WaitForSeconds(StrikePeriod);

            BehaviorController.IsStriking = false;
        }
        protected IEnumerator HitEnemyCoroutine(Action hitAction)
        {
            yield return new WaitForSeconds(HitDelay);

            hitAction.Invoke();
        }
        void HitEnemy()
        {
            var attackedEnemies = TriggeredEnemies.Take(AttackedEnemiesAmount).ToList();

            float damageLoss = SplashDamageLossPercent;
            float multiplier = 0;

            foreach (var enemy in attackedEnemies)
            {
                float lostDamage = Damage * damageLoss * multiplier / 100;
                float finalDamage = Damage - lostDamage;

                multiplier++;

                var enemyBattleController = enemy.GetComponent<BattleController>();
                enemyBattleController.GetDamage(finalDamage);
            }
        }
        void AOEHit()
        {
            foreach (var enemy in TriggeredEnemies)
            {
                var enemyBattleController = enemy.GetComponent<BattleController>();
                enemyBattleController.GetDamage(Damage);
            }
        }

        public void AddTriggeredEnemy(GameObject enemy) => TriggeredEnemies.Add(enemy);
        public void RemoveTriggeredEnemy(GameObject enemy) => TriggeredEnemies.Remove(enemy);

        void Start()
        {
            BehaviorController = GetComponent<BehaviorController>();
            TriggeredEnemies = new List<GameObject>();

            AnimationController = GetComponent<AnimationController>();
            HealthBarController = GetComponent<HealthBarController>();
            MovementController = GetComponent<MovementController>();

            if (HealthBarController != null)
            {
                HealthChanged = new Action(HealthBarController.UpdateHealthBarLine);
            }
            else
            {
                HealthChanged = new Action(() => { });
            }

            BehaviorController.IsStriking = false;

            SetHealth(MaxHealth);
        }
    }
}