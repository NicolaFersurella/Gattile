using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.ValueObjects
{
    public record Cap
    {
        /// <summary>
        /// CAP accettabile se è lungo 5 caratteri numerici
        /// </summary>
        /// <param name="value"></param>
        /// <exception cref="ArgumentException"></exception>
        private string _value;
        public string Value
        {
            get { return _value; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length != 5 || !value.All(char.IsDigit)) throw new ArgumentException("Invalid CAP.");
                _value = value;
            }
        }
        public Cap(string value)
        {
            Value = value;
        }
        public override string ToString() => Value;
    }
}
