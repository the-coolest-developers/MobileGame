using UnityEngine;

namespace Assets.Scripts.Models
{
    public class EntityAttributes : MonoBehaviour
    {
        public float JumpPower;
        public float RunningSpeed;

        public float MaxHealth;
        public float CurrentHealth { get; set; }

        public float StrikePeriod;
        public float BaseDamage;
        //public int AttackedEnemiesAmount;
        //public float SplashDamageLossPercent;

        public bool IsStriking { get; set; }
        public bool CanStrike;
    }
}
