using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain.Model.Entities
{
    public class Adoption
    {
        private Cat _cat;
        public Cat Cat
        {
            get { return _cat; }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Cat cannot be null.");
                }
                _cat = value;
            }
        }
        private DateTime _adoptionDate;
        public DateTime AdoptionDate
        {
            get { return _adoptionDate; }
            private set
            {
                /*
                if (value < Cat.ArrivalDate)
                {
                    throw new ArgumentException("Adoption date cannot be earlier than the cat's arrival date.");
                }
                */  
                _adoptionDate = value;
            }
        }
        private Adopter _adopter;
        public Adopter Adopter
        {
            get { return _adopter; }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Adopter cannot be null.");
                }
                _adopter = value;
            }
        }
        public Adoption(Cat cat, DateTime adoptionDate, Adopter adopter)
        {
            Cat = cat;
            AdoptionDate = adoptionDate;
            // quando il gatto viene adottato, settiamo la leave date
            Cat.LeaveDate = adoptionDate;
            Adopter = adopter;  
        }
        public void ManageFailAdoption()
        {
            Cat.LeaveDate = null;
            Cat.Description += " (Adoption failed)";
        }
    }
}
