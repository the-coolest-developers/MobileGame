namespace Assets.Scripts.Models
{
    public class Characteristic
    {
        public float Value;
        public float InitialValue;
        private float Modificator;
        private float Multiplier;

        public float SetValueToDefault()
        {
            Value = Value / Multiplier - Modificator; 
        
            Multiplier = 1;
            Modificator = 0; 
            return Value;
        }

        public float ModifyValue(float modificator)
        {
            Modificator = modificator;
            Value += Modificator;
        }

        public float MultiplyValue(float multiplier)
        {
            Multiplier = multiplier;
            Value *= Multiplier;
        }

        public Characteristic()
        {
            InitialValue = Value;
        }
    }
}