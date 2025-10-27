using Domain.Model.Entities;
using Domain.Model.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEntities
{
    [TestClass]
    public sealed class TestAdoption
    {
        [TestMethod]
        public void TestConstructor_CatIsNull_ReturnArgumentNullException()
        {
            DateTime d = new DateTime(2023, 1, 1);
            FiscalCode fc = new FiscalCode("QWERTYUIOPLKJHGF");
            PhoneNumber pn = new PhoneNumber("3534066278");
            Email email = new Email("utente@gmail.com");
            Cap cap = new Cap("00100");
            Adopter a = new Adopter(fc, "nome", "cognome", pn, email, "via v", cap, "Rome");

            Assert.ThrowsException<ArgumentNullException>(() => { Adoption ad = new Adoption(null, d, a); });
        }
        [TestMethod]
        public void TestConstructor_CatIsValid_CorretConsrtruction()
        {
            DateTime d = new DateTime(2023, 1, 1);
            FiscalCode fc = new FiscalCode("QWERTYUIOPLKJHGF");
            PhoneNumber pn = new PhoneNumber("3534066278");
            Email email = new Email("utente@gmail.com");
            Cap cap = new Cap("00100");
            Adopter a = new Adopter(fc, "nome", "cognome", pn, email, "via v", cap, "Rome");
            DateTime arrivalDate = new DateTime(2023, 1, 1);
            DateTime leaveDate = new DateTime(2023, 6, 1);
            DateTime birthDate = new DateTime(2022, 1, 1);
            string description = "This is a lovely cat.";
            Cat c = new Cat("luna", "razza", Gender.FEMALE, arrivalDate, leaveDate, birthDate, description, null);
            Adoption ad = new Adoption(c, d, a);

            Assert.AreEqual(c, ad.Cat);
        }
        [TestMethod]
        public void TestConstructor_AdoptionDateIsValid_CorretConstruction()
        {
            DateTime d = new DateTime(2023, 1, 1);
            FiscalCode fc = new FiscalCode("QWERTYUIOPLKJHGF");
            PhoneNumber pn = new PhoneNumber("3534066278");
            Email email = new Email("utente@gmail.com");
            Cap cap = new Cap("00100");
            Adopter a = new Adopter(fc, "nome", "cognome", pn, email, "via v", cap, "Rome");
            DateTime arrivalDate = new DateTime(2020, 1, 1);
            DateTime leaveDate = new DateTime(2023, 1, 1);
            DateTime birthDate = new DateTime(2022, 1, 1);
            string description = "This is a lovely cat.";
            Cat c = new Cat("luna", "razza", Gender.FEMALE, arrivalDate, leaveDate, birthDate, description, null);
            Adoption ad = new Adoption(c, d, a);

            Assert.AreEqual(d, ad.AdoptionDate);
        }
        [TestMethod]
        public void TestConstructor_AdopterIsNull_ReturnNullArgumentException()
        {
            DateTime d = new DateTime(2023, 1, 1);
            DateTime arrivalDate = new DateTime(2020, 1, 1);
            DateTime leaveDate = new DateTime(2023, 1, 1);
            DateTime birthDate = new DateTime(2022, 1, 1);
            string description = "This is a lovely cat.";
            Cat c = new Cat("luna", "razza", Gender.FEMALE, arrivalDate, leaveDate, birthDate, description, null);

            Assert.ThrowsException<ArgumentNullException>(() => { Adoption ad = new Adoption(c, d, null); });
        }
        [TestMethod]
        public void TestConstructor_AdopterIsValid_CorrectConstruction()
        {
            DateTime d = new DateTime(2023, 1, 1);
            FiscalCode fc = new FiscalCode("QWERTYUIOPLKJHGF");
            PhoneNumber pn = new PhoneNumber("3534066278");
            Email email = new Email("utente@gmail.com");
            Cap cap = new Cap("00100");
            Adopter a = new Adopter(fc, "nome", "cognome", pn, email, "via v", cap, "Rome");
            DateTime arrivalDate = new DateTime(2020, 1, 1);
            DateTime leaveDate = new DateTime(2023, 1, 1);
            DateTime birthDate = new DateTime(2022, 1, 1);
            string description = "This is a lovely cat.";
            Cat c = new Cat("luna", "razza", Gender.FEMALE, arrivalDate, leaveDate, birthDate, description, null);
            Adoption ad = new Adoption(c, d, a);

            Assert.AreEqual(a, ad.Adopter);
        }
    }
}
