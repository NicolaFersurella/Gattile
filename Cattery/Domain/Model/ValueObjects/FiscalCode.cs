using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.ValueObjects
{
    public record FiscalCode
    {
        /// <summary>
        /// Codice Fiscale accettabile se è lungo 16 caratteri
        /// </summary>
        /// <param name="value"></param>
        /// <exception cref="ArgumentException"></exception>
        private string _value;
        public string Value
        {
            get { return _value; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length != 16) throw new ArgumentException("Invalid fiscal code.");
                _value = value;
            }
        }
        public FiscalCode(string value)
        {
            Value = value;
        }
        public override string ToString() => Value;
    }
}
