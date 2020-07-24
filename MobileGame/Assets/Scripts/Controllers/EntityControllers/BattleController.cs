using System.IO;
using Controllers.UI_Controllers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Controllers.EntityControllers
{
    public class BattleController : MonoBehaviour
    {
        public HealthBarController HealthBarController { get; protected set; }

        public event Action HealthChanged;

        protected List<GameObject> TriggeredEnemies { get; set; }


        //Переменные из Editor
        public int MaxHealth;
        public float BaseDamage;
        public int AttackedEnemiesAmount;
        public float SplashDamageLossPercent;
        public float HitDelay;
        public float StrikePeriod;
        public string EnemyTag;

        public bool CanStrike;

        //Внутренние
        public float CurrentHealth { get; set; }
        public bool IsStriking { get; set; }


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
            CurrentHealth = value > MaxHealth ? MaxHealth : value;

            HealthChanged();
        }
        public void GetDamage(float damageAmount) => SetHealth(CurrentHealth - damageAmount);

        public bool Strike(Action<float> hitAction, float additionalDamage = 0)
        {
            if (CanStrike && !IsStriking)
            {
                StartCoroutine(StrikePeriodCoroutine());

                StartCoroutine(HitEnemyCoroutine(hitAction, additionalDamage));

                return true;
            }

            return false;
        }
        protected IEnumerator StrikePeriodCoroutine()
        {
            IsStriking = true;

            yield return new WaitForSeconds(StrikePeriod);

            IsStriking = false;
        }
        protected IEnumerator HitEnemyCoroutine(Action<float> hitAction, float additionalDamage)
        {
            yield return new WaitForSeconds(HitDelay);

            hitAction.Invoke(BaseDamage + additionalDamage);
        }
        public void SingleEnemyStrike(float damage)
        {
            var attackedEnemies = TriggeredEnemies.Take(AttackedEnemiesAmount).ToList();

            float damageLoss = SplashDamageLossPercent;
            float multiplier = 0;

            foreach (var enemy in attackedEnemies)
            {
                float lostDamage = damage * damageLoss * multiplier / 100;
                float finalDamage = damage - lostDamage;

                multiplier++;

                DamageEnemy(enemy, finalDamage);
            }
        }
        public void AOEStrike(float damage)
        {
            foreach (var enemy in TriggeredEnemies)
            {
                DamageEnemy(enemy, damage);
            }
        }

        private void DamageEnemy(GameObject enemy, float damage)
        {
            var enemyBattleController = enemy.GetComponent<BattleController>();
            enemyBattleController.GetDamage(damage);
        }

        public void AddTriggeredEnemy(GameObject enemy) => TriggeredEnemies.Add(enemy);
        public void RemoveTriggeredEnemy(GameObject enemy) => TriggeredEnemies.Remove(enemy);

        void Start()
        {
            TriggeredEnemies = new List<GameObject>();

            HealthBarController = GetComponent<HealthBarController>();

            if (HealthBarController != null)
            {
                HealthChanged = new Action(() =>
                {
                    HealthBarController.UpdateHealthBarLine(CurrentHealth, MaxHealth);
                });
            }
            else
            {
                HealthChanged = new Action(() => { });
            }

            IsStriking = false;

            SetHealth(MaxHealth);
        }
    }
}