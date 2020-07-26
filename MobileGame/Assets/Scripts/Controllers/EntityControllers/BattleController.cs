using System.IO;
using Controllers.UI_Controllers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Assets.Scripts.Models.Attributes;

namespace Controllers.EntityControllers
{
    public class BattleController : MonoBehaviour
    {
        public HealthBarController HealthBarController { get; protected set; }

        public event Action HealthChanged;

        protected List<GameObject> TriggeredEnemies { get; set; }


        //Переменные из Editor
        public int MaxHealth;
        public float HitDelay;
        public string EnemyTag;

        //Внутренние
        public float CurrentHealth { get; set; }
        public bool IsStriking { get; set; }
        public float StrikePeriod { get; set; }

        //Для делегата с GetDamage
        public event Action<float> Damaged;

        public bool Strike(Action<BattleAttributes> hitAction, BattleAttributes battleAttributes)
        {
            if (battleAttributes.CanStrike && !IsStriking)
            {
                StrikePeriod = battleAttributes.StrikePeriod;

                StartCoroutine(StrikePeriodCoroutine());

                StartCoroutine(HitEnemyCoroutine(hitAction, battleAttributes));

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
        protected IEnumerator HitEnemyCoroutine(Action<BattleAttributes> hitAction, BattleAttributes battleAttributes)
        {
            yield return new WaitForSeconds(HitDelay);

            hitAction.Invoke(battleAttributes);
        }
        public void SingleEnemyStrike(BattleAttributes battleAttributes)
        {
            var damage = battleAttributes.Damage;

            var attackedEnemies = TriggeredEnemies.Take(battleAttributes.AttackedEnemiesAmount).ToList();

            float damageLoss = battleAttributes.SplashDamageLossPercent;
            float multiplier = 0;

            foreach (var enemy in attackedEnemies)
            {
                float lostDamage = damage * damageLoss * multiplier / 100;
                float finalDamage = damage - lostDamage;

                multiplier++;

                DamageEnemy(enemy, finalDamage);
            }
        }
        public void AOEStrike(BattleAttributes battleAttributes)
        {
            foreach (var enemy in TriggeredEnemies)
            {
                DamageEnemy(enemy, battleAttributes.Damage);
            }
        }

        private void DamageEnemy(GameObject enemy, float damage)
        {
            var enemyBattleController = enemy.GetComponent<BattleController>();

            enemyBattleController.GetDamage(damage);
        }

        private void GetDamage(float damage)
        {
            Damaged(damage);
            HealthChanged();
        }

        public void AddTriggeredEnemy(GameObject enemy) => TriggeredEnemies.Add(enemy);
        public void RemoveTriggeredEnemy(GameObject enemy) => TriggeredEnemies.Remove(enemy);

        void Start()
        {
            CurrentHealth = MaxHealth;
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

            Damaged = new Action<float>((float damage) => { });

            IsStriking = false;
            HealthChanged();
        }
    }
}