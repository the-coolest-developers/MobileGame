using System;
using Models.Attributes;
using Singletones;
using UnityEngine;
using UnityEngine.Serialization;

namespace Controllers
{
    public class LevelController : MonoBehaviour
    {
        public LevelAttributes levelAttributes;

        /// <summary>
        ///Вызывается при начислении опыта. Параметры - текущий опыт и опыт для следующего уровня
        /// </summary>
        public event Action<int, int> OnExperienceChanged;
        /// <summary>
        ///Вызывается при получении нового уровня
        /// </summary>
        public event Action<int> OnLevelChanged;

        public void Start()
        {
            OnExperienceChanged = new Action<int, int>((int experience, int newLevelExperience) => { });
            OnLevelChanged = new Action<int>((int level) => { });
        }

        public void SetLevel(int newLevel)
        {
            if (newLevel > GlobalValues.MaxLevel)
            {
                levelAttributes.currentLevel = GlobalValues.MaxLevel;
            }
            else if (newLevel < 1)
            {
                levelAttributes.currentLevel = 1;
            }
            else
            {
                levelAttributes.currentLevel = newLevel;
            }

            OnLevelChanged(levelAttributes.currentLevel);
        }
        public void LevelUp()
        {
            SetLevel(levelAttributes.currentLevel + 1);
            levelAttributes.skillPoints++;
        }

        public void SetExperience(int experience)
        {
            levelAttributes.experiencePoints = experience;
            OnExperienceChanged(experience, levelAttributes.NextLevelExperiencePoints);
        }
        public void AddExperience(int experience)
        {
            levelAttributes.experiencePoints += experience;
            if (levelAttributes.currentLevel >= GlobalValues.MaxLevel)
            {
                levelAttributes.experiencePoints = 0;
            }

            while (levelAttributes.experiencePoints >= levelAttributes.NextLevelExperiencePoints)
            {
                levelAttributes.experiencePoints -= levelAttributes.NextLevelExperiencePoints;
                LevelUp();

                OnLevelChanged(levelAttributes.currentLevel);
            }

            OnExperienceChanged(levelAttributes.experiencePoints, levelAttributes.NextLevelExperiencePoints);
        }
    }
}
