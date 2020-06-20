using EntityControllers;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Parents
{
    public class BattleController : MonoBehaviour
    {
        //Внутренние переменные
        public MovementController MovementController { get; set; }
        public AnimationController AnimationController { get; set; }

        List<GameObject> Enemies { get; set; }

        public bool CanStrike;
        protected float currentHealth;
        public float CurrentHealth => currentHealth;

        //Переменные из Editor
        public int MaxHealth;
        public int Damage;
        public float HitDelay;
        public float StrikePeriod;
        public GameObject ThisObject;
        public string EnemyTag;

        public void SetHealth(float value) => currentHealth = value > MaxHealth ? MaxHealth : value;
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

                if(MovementController != null)
                {
                    MovementController.StopRunning();
                }
                if(AnimationController != null)
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

        protected virtual void Start()
        {
            CanStrike = true;

            SetHealth(MaxHealth);

            Enemies = new List<GameObject>();
        }
        protected virtual void FixedUpdate()
        {
            if (CurrentHealth <= 0)
            {
                Destroy(ThisObject);
            }
        }

        protected virtual void OnTriggerExit2D(Collider2D collision) => Enemies.Remove(collision.gameObject);
        protected virtual void OnTriggerEnter2D(Collider2D collision) => Enemies.Add(collision.gameObject);
    }
}