using Assets.Scripts.Models;
using Assets.Scripts.Singletones;
using Assets.Scripts.UI_Controllers;
using EntityControllers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

namespace EntityControllers
{
    public abstract class BattleController : MonoBehaviour
    {
        public HealthBarController HealthBarController { get; protected set; }
        public MovementController MovementController { get; protected set; }
        public AnimationController AnimationController { get; protected set; }

        public event Action HealthChanged;

        protected List<GameObject> TriggeredEnemies { get; set; }

        public bool CanStrike;
        public bool IsStriking { get; set; }
        public float CurrentHealth { get; private set; }

        //Переменные из Editor
        public int MaxHealth;
        public int Damage;
        public int AttackedEnemiesAmount;
        public float SplashDamageLossPercent;
        public float HitDelay;
        public float StrikePeriod;
        public GameObject ThisObject;
        public string EnemyTag;

        public void SetHealth(float value)
        {
            CurrentHealth = value > MaxHealth ? MaxHealth : value;

            HealthChanged();
        }
        public void GetDamage(float damageAmount) => SetHealth(CurrentHealth - damageAmount);

        public void Strike()
        {
            if (CanStrike && !IsStriking && MovementController.IsOnTheGround)
            {
                StartCoroutine(StrikePeriodCoroutine());

                MovementController.StopRunning();
                AnimationController.PlayStrikeAnimation();

                StartCoroutine(HitEnemyCoroutine());
            }
        }
        protected IEnumerator StrikePeriodCoroutine()
        {
            IsStriking = true;

            yield return new WaitForSeconds(StrikePeriod);

            IsStriking = false;
        }
        protected IEnumerator HitEnemyCoroutine()
        {
            yield return new WaitForSeconds(HitDelay);

            HitEnemy();
        }
        void HitEnemy()
        {
            var attackedEnemies = TriggeredEnemies.Take(AttackedEnemiesAmount);

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

        public void AddTriggeredEnemy(GameObject enemy) => TriggeredEnemies.Add(enemy);
        public void RemoveTriggeredEnemy(GameObject enemy) => TriggeredEnemies.Remove(enemy);

        protected virtual void Start()
        {
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

            IsStriking = false;

            SetHealth(MaxHealth);
        }
        protected virtual void FixedUpdate()
        {
            if (CurrentHealth <= 0)
            {
                Destroy(ThisObject);
            }
        }
    }
}