using System;

namespace Attributes
{
    [System.AttributeUsage(AttributeTargets.Class)]
    public class RegisterItemAttribute : System.Attribute
    {
        private string _name;

        public RegisterItemAttribute()
        {
        }

        public RegisterItemAttribute(string name)
        {
            _name = name;
        }
    }
}