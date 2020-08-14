using UnityEngine.Serialization;

namespace Models.Attributes
{
    [System.Serializable]
    public struct WeaponAttributes
    {
        public int attackedEnemiesAmount;
        public float splashDamageLossPercent;
        public float strikePeriod;
        public float hitDelay;
        public float damage;
    }
}
