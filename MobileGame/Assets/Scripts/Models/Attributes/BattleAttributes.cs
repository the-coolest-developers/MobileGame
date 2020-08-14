using UnityEngine.Serialization;

namespace Models.Attributes
{
    [System.Serializable]
    public struct BattleAttributes
    {
        [FormerlySerializedAs("MaxHealth")]
        public int maxHealth;
        [FormerlySerializedAs("AttackedEnemiesAmount")]
        public int attackedEnemiesAmount;

        [FormerlySerializedAs("SplashDamageLossPercent")]
        public float splashDamageLossPercent;
        [FormerlySerializedAs("StrikePeriod")]
        public float strikePeriod;
        [FormerlySerializedAs("HitDelay")]
        public float hitDelay;
        [FormerlySerializedAs("Damage")]
        public float damage;

        [FormerlySerializedAs("CanStrike")]
        public bool canStrike;

        public bool IsDead { get; set; }
        public float CurrentHealth { get; set; }
    }
}