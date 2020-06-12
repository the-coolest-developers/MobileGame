using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Parents
{
    public class BattleController : MonoBehaviour
    {
        //Переменные из Editor
        public int MaxHealth = 10;
        public int Damage;
        public float HitDelay;
    
        //Всякие boolean-ы
        public float StrikePeriod;

        public bool CanStrike ;//{ get; private set; }
    
        protected float currentHealth;
        public float CurrentHealth => currentHealth;
        //Внитренние переменные
        public PlayerMovementController MovementController { get; set; }
        public PlayerAnimationController AnimationController { get; set; }

        public void SetHealth(float value) => currentHealth = value > MaxHealth ? MaxHealth : value;

        public void GetDamage(float damageAmount) => SetHealth(CurrentHealth - damageAmount);
        
    }

}
