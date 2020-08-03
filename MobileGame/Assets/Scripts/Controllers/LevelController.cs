using Assets.Scripts.Models.Attributes;
using Assets.Scripts.Singletones;
using System;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class LevelController : MonoBehaviour
    {
        public LevelAttributes LevelAttributes;

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
                LevelAttributes.CurrentLevel = GlobalValues.MaxLevel;
            }
            else if (newLevel < 1)
            {
                LevelAttributes.CurrentLevel = 1;
            }
            else
            {
                LevelAttributes.CurrentLevel = newLevel;
            }

            OnLevelChanged(LevelAttributes.CurrentLevel);
        }
        public void LevelUp()
        {
            SetLevel(LevelAttributes.CurrentLevel + 1);
            LevelAttributes.SkillPoints++;
        }

        public void SetExperience(int experience)
        {
            LevelAttributes.ExperiencePoints = experience;
            OnExperienceChanged(experience, LevelAttributes.NextLevelExperiencePoints);
        }
        public void AddExperience(int experience)
        {
            LevelAttributes.ExperiencePoints += experience;
            if (LevelAttributes.CurrentLevel >= GlobalValues.MaxLevel)
            {
                LevelAttributes.ExperiencePoints = 0;
            }

            while (LevelAttributes.ExperiencePoints > LevelAttributes.NextLevelExperiencePoints)
            {
                LevelAttributes.ExperiencePoints -= LevelAttributes.NextLevelExperiencePoints;
                LevelUp();

                OnLevelChanged(LevelAttributes.CurrentLevel);
            }

            OnExperienceChanged(LevelAttributes.ExperiencePoints, LevelAttributes.NextLevelExperiencePoints);
        }
    }
}
