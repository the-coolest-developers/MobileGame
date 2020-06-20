using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Parents
{
    public class BattleController : MonoBehaviour
    {
        //Переменные из Editor
        public int MaxHealth;
        public int Damage;
        public float HitDelay;
        public float StrikePeriod;
        public GameObject ThisObject;

        //Всякие boolean-ы
        public bool CanStrike;

        //Внитренние переменные
        public MovementController movementController { get; set; }
        public AnimationController animationController { get; set; }
        protected float currentHealth;
        public float CurrentHealth => currentHealth;

        public void SetHealth(float value) => currentHealth = value > MaxHealth ? MaxHealth : value;
        public void GetDamage(float damageAmount) => SetHealth(CurrentHealth - damageAmount);

        protected virtual void Start()
        {
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

        public void Strike(GameObject enemy)
        {
            if (CanStrike)
            {
                StartCoroutine(StrikePeriodCoroutine());

                movementController.StopRunning();
                animationController.PlayStrikeAnimation();

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
    }
}