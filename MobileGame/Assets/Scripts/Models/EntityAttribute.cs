using UnityEngine;

namespace Assets.Scripts.Models
{
    [System.Serializable]
    public class EntityAttribute
    {
        //Из редактора
        [SerializeField]
        public float CurrentValue;
        public float InitialValue;

        public void ResetValue()
        {
            CurrentValue = InitialValue;
        }

        public float GetIncreasedValue(float modificator)
        {
            return CurrentValue + modificator;
        }
        public float GetDecreasedValue(float modificator)
        {
            return CurrentValue - modificator;
        }
        public float GetMultipliedValue(float multiplier)
        {
            return CurrentValue * multiplier;
        }

        public void IncreaseValueBy(float modificator)
        {
            CurrentValue += modificator;
        }
        public void DecreaseValueBy(float modificator)
        {
            CurrentValue -= modificator;
        }

        public EntityAttribute()
        {
            CurrentValue = InitialValue;
        }
        public EntityAttribute(float initialValue)
        {
            InitialValue = initialValue;
            CurrentValue = initialValue;
        }
    }
}