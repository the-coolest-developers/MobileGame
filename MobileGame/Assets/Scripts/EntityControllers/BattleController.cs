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
<<<<<<< Updated upstream
        //Внутренние переменные
        public abstract HealthBarController HealthBarController { get; protected set; }

=======
        public HealthBarController HealthBarController { get; protected set; }
>>>>>>> Stashed changes
        public MovementController MovementController { get; protected set; }
        public AnimationController AnimationController { get; protected set; }

        public event Action HealthChanged;

        List<GameObject> Enemies { get; set; }

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

                var enemy = Enemies.FirstOrDefault(c => c.gameObject.tag == EnemyTag);

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

<<<<<<< Updated upstream
=======
        public void AddTriggeredEnemy(GameObject enemy)
        {
            TriggeredEnemies.Add(enemy);
        }
        public void RemoveTriggeredEnemy(GameObject enemy)
        {
            TriggeredEnemies.Remove(enemy);
        }

>>>>>>> Stashed changes
        protected virtual void Start()
        {
            Enemies = new List<GameObject>();

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
<<<<<<< Updated upstream

        protected virtual void OnTriggerExit2D(Collider2D collision) => Enemies.Remove(collision.gameObject);
        protected virtual void OnTriggerEnter2D(Collider2D collision) => Enemies.Add(collision.gameObject);
=======
>>>>>>> Stashed changes
    }
}