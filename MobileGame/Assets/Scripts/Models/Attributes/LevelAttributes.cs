using System;
using Singletones;
using UnityEngine.Serialization;

namespace Models.Attributes
{
    [System.Serializable]
    public struct LevelAttributes
    {
        [FormerlySerializedAs("CurrentLevel")]
        public int currentLevel;
        [FormerlySerializedAs("SkillPoints")]
        public int skillPoints;
        [FormerlySerializedAs("ExperiencePoints")]
        public int experiencePoints;
        public int NextLevelExperiencePoints => (int)(GlobalValues.BaseXp * Math.Pow(currentLevel, GlobalValues.LevelFactor));
    }
}
