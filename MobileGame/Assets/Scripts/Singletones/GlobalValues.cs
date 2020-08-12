using System.Collections.Generic;

namespace Singletones
{
    public static class GlobalValues
    {
        public static int MaxLevel => 5;
        public static int BaseXp => 100;
        public static int LevelFactor => 2;

        private static readonly Dictionary<string, int> EnemiesGivenExperience = new Dictionary<string, int>()
        {
            {"Enemy", 90}
        };

        public static int GetEnemyExeprience(string enemyName) => EnemiesGivenExperience[enemyName];
    }
}