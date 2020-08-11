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
        /// Вызывается при получении уронаПо умолчанию вызывает и событие OnHealthChanged
        /// </summary>
        public event Action<float> OnDamaged;

        public event Action<int> OnEnemyKilled;

        private List<GameObject> TriggeredEnemies { get; set; }

        //Переменные из Editor
        [SerializeField]
        private string enemyTag;

        public string EnemyTag => enemyTag;

        //Внутренние
        public bool IsStriking { get; private set; }
        private float StrikePeriod { get; set; }

        public void Strike(Action<BattleAttributes> hitAction, BattleAttributes battleAttributes)
        {
            StrikePeriod = battleAttributes.StrikePeriod;

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
            var enemyBehaviorController = enemy.GetComponent<EnemyBehaviourController>();
            var enemyBattleController = enemy.GetComponent<BattleController>();

            enemyBattleController.GetDamage(damage);

            var isDead = enemy.GetComponent<EntityAttributes>().BattleAttributes.IsDead;
            if (isDead)
            {
                OnEnemyKilled(enemyBehaviorController.GivenExperience);
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

            IsStriking = false;
        }
    }
}