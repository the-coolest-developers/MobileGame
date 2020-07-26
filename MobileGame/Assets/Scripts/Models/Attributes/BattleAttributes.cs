using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Models.Attributes
{
    [System.Serializable]
    public struct BattleAttributes
    {
        public int MaxHealth;
        public float CurrentHealth ;//{ get; set; }

        public int AttackedEnemiesAmount;
        public float SplashDamageLossPercent;
        public float StrikePeriod;

        public float Damage;

        public bool CanStrike;
    }
}
