using UnityEngine.Serialization;

namespace Models.Attributes
{
    [System.Serializable]
    public struct WeaponAttributes
    {
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
    }
}
