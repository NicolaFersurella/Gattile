using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain.Model.Entities
{
    public enum Gender
    {
        MALE,
        FEMALE
    }
    public class Cat
    {
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
        private string _breed;
        public string Breed
        {
            get { return _breed; }
            private set
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentNullException("Invalid breed.");
                _breed = value;
            }
        }
        private Gender _gender;
        public Gender Gender
        {
            get { return _gender; }
            private set { _gender = value; }
        }
        private DateTime _arrivalDate;
        public DateTime ArrivalDate
        {
            get { return _arrivalDate; }
            set
            {
                if (LeaveDate != null && value > LeaveDate)
                {
                    throw new ArgumentException("Invalid arrival date.");
                }
                _arrivalDate = value;
            }
        }
        private DateTime? _leaveDate;
        public DateTime? LeaveDate
        {
            get { return _leaveDate; }
            set
            {
                if (value != null && value < ArrivalDate)
                {
                    throw new ArgumentException("Invalid leaving date.");
                }
                _leaveDate = value;
            }
        }
        private DateTime? _birthDate;
        public DateTime? BirthDate
        {
            get { return _birthDate; }
            set { _birthDate = value; }
        }
        private int _probablyYear;
        public int ProbablyYear
        {
            get { return _probablyYear; }
            private set
            {
                if (value < 1) throw new ArgumentOutOfRangeException("Invalid year.");
                _probablyYear = value;
            }
        }
        private string? _description;
        public string? Description
        {
            get { return _description; }
            set
            {
                _description = value;
            }
        }
        public string Id { get; private set; }
        /*
         * readonly protegge il riferimento alla lista, non il contenuto.
         * La mutabilità dei dati all’interno della lista è ancora
         * consentita.
         * Se fa parte dello stato mettiamo IReadOnlyList nella proprietà
         * Come il val in Kotlin sugli array
         */
        private readonly List<Adoption>? _adoptions;
        public IReadOnlyList<Adoption>? Adoptions => _adoptions;
        public Cat(string name, string breed, Gender gender, DateTime arrivalDate, DateTime? leaveDate, DateTime? birthDate, string? description, List<Adoption>? adoptions = null)
        {
            if (birthDate == null)
            {
                throw new ArgumentNullException("Birth date cannot be null.");
            }
            Name = name;
            Breed = breed;
            Gender = gender;
            ArrivalDate = arrivalDate;
            LeaveDate = leaveDate;
            BirthDate = birthDate;
            Description = description;

            Id = CreateId();

            for (int i = 0; i < adoptions?.Count; i++)
            {
                if (adoptions[i].Cat.Equals(this) == false)
                    throw new ArgumentException("Wrong cat.");
            }
            //ordino prima di salvare la lista
            _adoptions = adoptions ?? new List<Adoption>();
        }
        public Cat(string name, string breed, Gender gender, DateTime arrivalDate, DateTime? leaveDate, DateTime? birthDate, int probablyYera, string? description, List<Adoption> adoptions = null) : this(name, breed, gender, arrivalDate, leaveDate, birthDate, description, adoptions)
        {
            ProbablyYear = probablyYera;
        }
        private string CreateId()
        {
            Random random = new Random();
            // 1. Numero random di 5 cifre
            int number = random.Next(10000, 100000);

            // 2. Prima lettera del mese di registrazione
            string firstMonthLetter = ArrivalDate.ToString("MMMM")[0].ToString().ToUpper();
            // .ToString("MMMM")[0] --> prende il nome completo del mese
            // .ToString().ToUpper() --> prende la prima lettera e la mette maiuscola

            // 3. Anno della data di registrazione
            string year = ArrivalDate.Year.ToString();

            // 4. Tre lettere casuali
            string casualLetters = GenerateCasualLetters(3);

            return $"{number}{firstMonthLetter}{year}{casualLetters}";
        }
        private string GenerateCasualLetters(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                int indexNumber = random.Next(chars.Length);
                sb.Append(chars[indexNumber]);
            }
            return sb.ToString();
        }
        public void AddAdoption(Adoption a)
        {
            if (a == null) throw new ArgumentNullException(nameof(a));

            if (a.Cat.Equals(this))
                _adoptions.Add(a);

            //ordino dopo aver aggiunto
            else throw new ArgumentException("cat is wrong.");
        }
        /// <summary>
        /// consideriamo uguali due gatti se hanno lo stesso ID
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object? obj)
        {
            if (obj == null || obj is not Cat) return false;
            Cat other = obj as Cat;

            return Id.Equals(other.Id);
        }
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
        public override string ToString()
        {
            return $"Id: {Id} - Name: {Name} - Breed: {Breed} - Gender: {Gender} - Arrival date: {ArrivalDate} - Leave date: {LeaveDate} - Birthday: {BirthDate} - Description: {Description}";
        }
    }
}
