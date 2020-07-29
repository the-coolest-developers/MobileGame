using System.IO;
using Controllers.UI_Controllers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Assets.Scripts.Models.Attributes;
using Assets.Scripts.Controllers.UI_Controllers;
using UnityEditor.UIElements;

namespace Controllers.EntityControllers
{
    public class BattleController : MonoBehaviour
    {
        /// <summary>
        /// Вызывается при получении уронаПо умолчанию вызывает и событие OnHealthChanged
        /// </summary>
        public event Action<float> OnDamaged;

        protected List<GameObject> TriggeredEnemies { get; set; }

        //Переменные из Editor
        public string EnemyTag;

        //Внутренние
        public bool IsStriking { get; set; }
        public float StrikePeriod { get; set; }

        public void Strike(Action<BattleAttributes> hitAction, BattleAttributes battleAttributes)
        {
            StrikePeriod = battleAttributes.StrikePeriod;

            StartCoroutine(StrikePeriodCoroutine());

            StartCoroutine(HitEnemyCoroutine(hitAction, battleAttributes));
        }
        protected IEnumerator StrikePeriodCoroutine()
        {
            IsStriking = true;

            yield return new WaitForSeconds(StrikePeriod);

            IsStriking = false;
        }
        protected IEnumerator HitEnemyCoroutine(Action<BattleAttributes> hitAction, BattleAttributes battleAttributes)
        {
            yield return new WaitForSeconds(battleAttributes.HitDelay);

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
            OnDamaged(damage);
        }

        public void AddTriggeredEnemy(GameObject enemy) => TriggeredEnemies.Add(enemy);
        public void RemoveTriggeredEnemy(GameObject enemy) => TriggeredEnemies.Remove(enemy);

        void Start()
        {
            TriggeredEnemies = new List<GameObject>();

            OnDamaged = new Action<float>((float damage) => { });

            IsStriking = false;
        }
    }
}