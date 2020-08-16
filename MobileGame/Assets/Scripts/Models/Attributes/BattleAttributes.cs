﻿namespace Models.Attributes
{
    [System.Serializable]
    public struct BattleAttributes
    {
        public WeaponAttributes weaponAttributes;
        public ArmorAttributes armorAttributes;
        
        public int maxHealth;
        public bool canStrike;

        public bool IsDead { get; set; }
        public float CurrentHealth { get; set; }
    }
}