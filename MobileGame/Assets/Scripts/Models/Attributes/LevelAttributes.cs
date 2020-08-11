using System;
using Singletones;

namespace Models.Attributes
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
