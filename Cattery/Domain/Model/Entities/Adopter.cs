using Domain.Model.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Domain.Model.Entities
{
    public class Adopter
    {
        private FiscalCode _fc;
        public FiscalCode Fc
        {
            get { return _fc; }
            private set { _fc = value; }
        }
        private string _name;
        public string Name
        {
            get { return _name; }
            private set
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentNullException("Invalid name.");
                _name = value;
            }
        }
        private string _surname;
        public string Surname
        {
            get { return _surname; }
            private set
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentNullException("Invalid surname.");
                _surname = value;
            }
        }
        private PhoneNumber _phone;
        public PhoneNumber Phone
        {
            get { return _phone; }
            private set { _phone = value; }
        }
        private Email _email;
        public Email Email
        {
            get { return _email; }
            private set { _email = value; }
        }
        private string _address;
        public string Address
        {
            get { return _address; }
            private set
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentNullException("Invalid address.");
                _address = value;
            }
        }
        private Cap _cap;
        public Cap Cap
        {
            get { return _cap; }
            private set { _cap = value; }
        }
        private string _city;
        public string City
        {
            get { return _city; }
            private set
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentNullException("Invalid city.");
                _city = value;
            }
        }
        public Adopter(FiscalCode fc, string name, string surname, PhoneNumber number, Email email, string address, Cap cap, string city)
        {
            Fc = fc;
            Name = name;
            Surname = surname;
            Phone = number;
            Email = email;
            Address = address;
            Cap = cap;
            City = city;
        }
        public override string ToString() => $"{Name} {Surname}";
    }
}
