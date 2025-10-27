using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.ValueObjects
{
    public record PhoneNumber
    {
        private string _value;
        public string Value
        {
            get { return _value; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("Phone number not valid");
                if (!value.All(char.IsDigit) || value.Length < 7)
                    throw new ArgumentException("Invalid phone number format");

                _value = value;
            }
        }
        public PhoneNumber(string value)
        {
            Value = value;
        }
        public override string ToString() => Value;
    }
}
