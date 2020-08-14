using UnityEngine.Serialization;

namespace Models.Attributes
{
    [System.Serializable]
    public struct BattleAttributes
    {
        [FormerlySerializedAs("WeaponAttributes")]
        public WeaponAttributes weaponAttributes;

        [FormerlySerializedAs("MaxHealth")]
        public int maxHealth;

        [FormerlySerializedAs("CanStrike")]
        public bool canStrike;

        public bool IsDead { get; set; }
        public float CurrentHealth { get; set; }
    }
}