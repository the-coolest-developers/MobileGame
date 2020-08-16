namespace Models.Attributes
{
    [System.Serializable]
    public struct WeaponAttributes
    {

        public bool canStrike;

        public int attackedEnemiesAmount;
        public float splashDamageLossPercent;
        public float strikePeriod;
        public float hitDelay;
        public float damage;
    }
}
