using Assets.Scripts.Singletones;
using UnityEditor.UIElements;
using UnityEngine;
using Assets.Scripts.Models;

namespace Assets.Scripts.Models.Attributes
{
    [System.Serializable]
    public struct BattleAttributes
    {
        public int MaxHealth;
        public float CurrentHealth { get; set; }

        public int AttackedEnemiesAmount;
        public float SplashDamageLossPercent;
        public float StrikePeriod;
        public float HitDelay;
        public float Damage;
        public bool CanStrike;
    
        public GameObject MainEnemy;
    }
}
