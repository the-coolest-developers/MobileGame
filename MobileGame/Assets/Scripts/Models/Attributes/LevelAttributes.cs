using System;
using Singletones;

namespace Models.Attributes
{
    [System.Serializable]
    public struct LevelAttributes
    {
        public int currentLevel;
        public int skillPoints;
        public int experiencePoints;
        public int NextLevelExperiencePoints => (int)(GlobalValues.BaseXp * Math.Pow(currentLevel, GlobalValues.LevelFactor));
    }
}
