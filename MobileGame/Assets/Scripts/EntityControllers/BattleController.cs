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

        protected float currentHealth;
        public float CurrentHealth => currentHealth;
        //Внитренние переменные
        public MovementController MovementController { get; set; }
        public AnimationController AnimationController { get; set; }

        public void SetHealth(float value) => currentHealth = value > MaxHealth ? MaxHealth : value;

        public void GetDamage(float damageAmount) => SetHealth(CurrentHealth - damageAmount);
    
        protected IEnumerator StrikePeriodCoroutine()
        {
            CanStrike = false;

            yield return new WaitForSeconds(StrikePeriod);

            CanStrike = true;
        }
    }
}
