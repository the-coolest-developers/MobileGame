namespace Models.Attributes
{
    [System.Serializable]
    public struct BattleAttributes
    {
        public int MaxHealth;
        public int AttackedEnemiesAmount;

        public float SplashDamageLossPercent;
        public float StrikePeriod;
        public float HitDelay;
        public float Damage;

        public bool CanStrike;

        public bool IsDead { get; set; }
        public float CurrentHealth { get; set; }
    }
}