using Assets.Scripts.UI_Controllers;
using EntityControllers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace EntityControllers
{
    public abstract class BattleController : MonoBehaviour
    {
        public HealthBarController HealthBarController { get; protected set; }
        public MovementController MovementController { get; protected set; }
        public AnimationController AnimationController { get; protected set; }

        public event Action HealthChanged;

        List<GameObject> TriggeredEnemies { get; set; }

        public bool CanStrike;
        public float CurrentHealth { get; private set; }

        //Переменные из Editor
        public int MaxHealth;
        public int Damage;
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
            if (CanStrike)
            {
                StartCoroutine(StrikePeriodCoroutine());

                MovementController.StopRunning();
                AnimationController.PlayStrikeAnimation();

                var enemy = TriggeredEnemies.FirstOrDefault(c => c.gameObject.tag == EnemyTag);

                StartCoroutine(HitEnemyCoroutine(enemy));
            }
        }
        //Надо будет убрать, но это не точно
        public void Strike(GameObject enemy)
        {
            if (CanStrike)
            {
                StartCoroutine(StrikePeriodCoroutine());

                if (MovementController != null)
                {
                    MovementController.StopRunning();
                }
                if (AnimationController != null)
                {
                    AnimationController.PlayStrikeAnimation();
                }

                StartCoroutine(HitEnemyCoroutine(enemy));
            }
        }
        protected IEnumerator StrikePeriodCoroutine()
        {
            CanStrike = false;

            yield return new WaitForSeconds(StrikePeriod);

            CanStrike = true;
        }
        IEnumerator HitEnemyCoroutine(GameObject enemy)
        {
            yield return new WaitForSeconds(HitDelay);

            if (enemy != null)
            {
                var enemyBattleController = enemy.GetComponent<BattleController>();
                enemyBattleController.GetDamage(Damage);
            }
        }

        public void AddTriggeredEnemy(GameObject enemy)
        {
            TriggeredEnemies.Add(enemy);
        }
        public void RemoveTriggeredEnemy(GameObject enemy)
        {
            TriggeredEnemies.Remove(enemy);
        }

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

            CanStrike = true;

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