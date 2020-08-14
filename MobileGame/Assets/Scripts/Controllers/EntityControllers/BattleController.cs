using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Assets.Scripts.Controllers.BehaviorControllers;
using Models.Attributes;
using UnityEngine.Serialization;

namespace Controllers.EntityControllers
{
    public class BattleController : MonoBehaviour
    {
        /// <summary>
        /// Вызывается при получении урона
        /// По умолчанию вызывает и событие OnHealthChanged
        /// </summary>
        public event Action<float> OnDamaged;

        /// <summary>
        /// Вызывается при убийстве врага
        /// </summary>
        public event Action<string> OnEnemyKilled;

        private List<GameObject> TriggeredEnemies { get; set; }

        //Переменные из Editor
        [FormerlySerializedAs("EnemyTag")]
        public string enemyTag;

        //Внутренние
        public bool IsStriking { get; private set; }
        private float StrikePeriod { get; set; }

        public void Strike(Action<BattleAttributes> hitAction, BattleAttributes battleAttributes)
        {
            StrikePeriod = battleAttributes.weaponAttributes.strikePeriod;

            StartCoroutine(StrikePeriodCoroutine());

            StartCoroutine(HitEnemyCoroutine(hitAction, battleAttributes));
        }

        private IEnumerator StrikePeriodCoroutine()
        {
            IsStriking = true;

            yield return new WaitForSeconds(StrikePeriod);

            IsStriking = false;
        }

        private IEnumerator HitEnemyCoroutine(Action<BattleAttributes> hitAction, BattleAttributes battleAttributes)
        {
            yield return new WaitForSeconds(battleAttributes.weaponAttributes.hitDelay);

            hitAction.Invoke(battleAttributes);
        }

        public void SingleEnemyStrike(BattleAttributes battleAttributes)
        {
            var damage = battleAttributes.weaponAttributes.damage;

            var attackedEnemies = TriggeredEnemies.Take(battleAttributes.weaponAttributes.attackedEnemiesAmount).ToList();

            float damageLoss = battleAttributes.weaponAttributes.splashDamageLossPercent;
            float multiplier = 0;

            foreach (var enemy in attackedEnemies)
            {
                float lostDamage = damage * damageLoss * multiplier / 100;
                float finalDamage = damage - lostDamage;

                multiplier++;

                DamageEnemy(enemy, finalDamage);
            }
        }

        public void AoeStrike(BattleAttributes battleAttributes)
        {
            foreach (var enemy in TriggeredEnemies)
            {
                DamageEnemy(enemy, battleAttributes.weaponAttributes.damage);
            }
        }

        private void DamageEnemy(GameObject enemy, float damage)
        {
            var enemyBattleController = enemy.GetComponent<BattleController>();
            enemyBattleController.GetDamage(damage);

            var isDead = enemy.GetComponent<EntityAttributes>().battleAttributes.IsDead;
            if (isDead)
            {
                OnEnemyKilled(enemy.name);
            }
        }

        private void GetDamage(float damage)
        {
            OnDamaged(damage);
        }

        public void AddTriggeredEnemy(GameObject enemy) => TriggeredEnemies.Add(enemy);
        public void RemoveTriggeredEnemy(GameObject enemy) => TriggeredEnemies.Remove(enemy);

        private void Start()
        {
            TriggeredEnemies = new List<GameObject>();

            OnDamaged = new Action<float>((float damage) => { });
            OnEnemyKilled = new Action<string>(s => { });

            IsStriking = false;
        }
    }
}