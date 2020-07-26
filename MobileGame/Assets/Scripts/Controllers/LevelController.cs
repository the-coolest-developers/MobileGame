using Assets.Scripts.Models.Attributes;
using Assets.Scripts.Singletones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class LevelController : MonoBehaviour
    {
        public LevelAttributes LevelAttributes;

        public event Action<int> OnExperienceChanged;
        public event Action<int> OnLevelChanged;

        public event EventHandler ExperienceChanged;
        public event EventHandler LevelChanged;

        public void Start()
        {
            OnExperienceChanged = new Action<int>((int experience) => { });
            OnLevelChanged = new Action<int>((int level) => { });
        }

        public void SetLevel(int newLevel)
        {
            if (newLevel > GlobalValues.MaxLevel)
            {
                LevelAttributes.CurrentLevel = GlobalValues.MaxLevel;
            }
            else if (newLevel < 0)
            {
                LevelAttributes.CurrentLevel = 0;
            }
            else
            {
                LevelAttributes.CurrentLevel = newLevel;
            }
        }
        public void LevelUp()
        {
            SetLevel(LevelAttributes.CurrentLevel + 1);
            LevelAttributes.SkillPoints++;
        }

        public void AddExperience(int experience)
        {
            LevelAttributes.ExperiencePoints += experience;
            while (LevelAttributes.ExperiencePoints > LevelAttributes.NextLevelExperiencePoints)
            {
                LevelAttributes.ExperiencePoints -= LevelAttributes.NextLevelExperiencePoints;
                LevelUp();

                OnLevelChanged(LevelAttributes.CurrentLevel);
            }

            OnExperienceChanged(LevelAttributes.ExperiencePoints);
        }
    }
}
