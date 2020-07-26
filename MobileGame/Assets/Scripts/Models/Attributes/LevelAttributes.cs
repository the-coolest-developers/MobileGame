using Assets.Scripts.Singletones;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Models.Attributes
{
    [System.Serializable]
    public struct LevelAttributes
    {
        public int CurrentLevel;
        public int SkillPoints;
        public int ExperiencePoints;
        public int NextLevelExperiencePoints => (int)(GlobalValues.BaseXp * Math.Pow(CurrentLevel, GlobalValues.LevelFactor));
    }
}
