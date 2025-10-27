using Domain.Model.Entities;
using Domain.Model.ValueObjects;

namespace TestEntities
{
    [TestClass]
    public sealed class TestCat
    {
        [TestMethod]
        public void TestConstructor_NameIsNull_ReturnArgumentNullException()
        {
            DateTime arrivalDate = new DateTime(2023, 1, 1);
            DateTime birthDate = new DateTime(2022, 1, 1);

            Assert.ThrowsException<ArgumentNullException>(() => { Cat c = new Cat(null, "razza", Gender.MALE, arrivalDate, null, birthDate, null, null); });
        }
        [TestMethod]
        public void TestConstructor_NameIsEmpty_ReturnArgumentNullException()
        {
            DateTime arrivalDate = new DateTime(2023, 1, 1);
            DateTime birthDate = new DateTime(2022, 1, 1);

            Assert.ThrowsException<ArgumentNullException>(() => { Cat c = new Cat("", "razza", Gender.MALE, arrivalDate, null, birthDate, null, null); });
        }
        [TestMethod]
        public void TestConstructor_WithValidName_CorrectConstruction()
        {
            DateTime arrivalDate = new DateTime(2023, 1, 1);
            DateTime birthDate = new DateTime(2022, 1, 1);
            Cat c = new Cat("luna", "razza", Gender.MALE, arrivalDate, null, birthDate, null, null);

            Assert.AreEqual("luna", c.Name);
        }
        [TestMethod]
        public void TestConstructor_BreedIsNull_ReturnArgumentNullException()
        {
            DateTime arrivalDate = new DateTime(2023, 1, 1);
            DateTime birthDate = new DateTime(2022, 1, 1);

            Assert.ThrowsException<ArgumentNullException>(() => { Cat c = new Cat("luna", null, Gender.MALE, arrivalDate, null, birthDate, null, null); });
        }
        [TestMethod]
        public void TestConstructor_BreedIsEmpty_ReturnArgumentNullException()
        {
            DateTime arrivalDate = new DateTime(2023, 1, 1);
            DateTime birthDate = new DateTime(2022, 1, 1);

            Assert.ThrowsException<ArgumentNullException>(() => { Cat c = new Cat("luna", "", Gender.MALE, arrivalDate, null, birthDate, null, null); });
        }
        [TestMethod]
        public void TestConstructor_WithValidBreed_CorrectConstruction()
        {
            DateTime arrivalDate = new DateTime(2023, 1, 1);
            DateTime birthDate = new DateTime(2022, 1, 1);
            Cat c = new Cat("luna", "razza", Gender.MALE, arrivalDate, null, birthDate, null, null);

            Assert.AreEqual("razza", c.Breed);
        }
        [TestMethod]
        public void TestConstructor_CatIsMale_CorrectConstruction()
        {
            DateTime arrivalDate = new DateTime(2023, 1, 1);
            DateTime birthDate = new DateTime(2022, 1, 1);
            Cat c = new Cat("luna", "razza", Gender.MALE, arrivalDate, null, birthDate, null, null);

            Assert.AreEqual(Gender.MALE, c.Gender);
        }
        [TestMethod]
        public void TestConstructor_CatIsFemale_CorrectConstruction()
        {
            DateTime arrivalDate = new DateTime(2023, 1, 1);
            DateTime birthDate = new DateTime(2022, 1, 1);
            Cat c = new Cat("luna", "razza", Gender.FEMALE, arrivalDate, null, birthDate, null, null);

            Assert.AreEqual(Gender.FEMALE, c.Gender);
        }
        [TestMethod]
        public void TestConstructor_ArrivalDateGreaterThanLeaveDate_ReturnArgumentException()
        {
            DateTime arrivalDate = new DateTime(2023, 1, 1);
            DateTime birthDate = new DateTime(2022, 1, 1);
            DateTime leaveDate = new DateTime(2020, 12, 31);

            Assert.ThrowsException<ArgumentException>(() => { Cat c = new Cat("luna", "razza", Gender.MALE, arrivalDate, leaveDate, birthDate, null, null); });
        }
        [TestMethod]
        public void TestConstructor_WithValidArrivalDate_CorrectConstruction()
        {
            DateTime arrivalDate = new DateTime(2023, 1, 1);
            DateTime birthDate = new DateTime(2022, 1, 1);
            Cat c = new Cat("luna", "razza", Gender.FEMALE, arrivalDate, null, birthDate, null, null);

            Assert.AreEqual(arrivalDate, c.ArrivalDate);
        }
        [TestMethod]
        public void TestConstructor_LeaveDateLowerThanArrivalDate_ReturnArgumentException()
        {
            DateTime arrivalDate = new DateTime(2023, 1, 1);
            DateTime birthDate = new DateTime(2022, 1, 1);
            DateTime leaveDate = new DateTime(2020, 12, 31);

            Assert.ThrowsException<ArgumentException>(() => { Cat c = new Cat("luna", "razza", Gender.MALE, arrivalDate, leaveDate, birthDate, null, null); });
        }
        [TestMethod]
        public void TestConstructor_WithValidLeaveDate_CorrectConstruction()
        {
            DateTime arrivalDate = new DateTime(2023, 1, 1);
            DateTime leaveDate = new DateTime(2023, 6, 1);
            DateTime birthDate = new DateTime(2022, 1, 1);
            Cat c = new Cat("luna", "razza", Gender.FEMALE, arrivalDate, leaveDate, birthDate, null, null);

            Assert.AreEqual(leaveDate, c.LeaveDate);
        }
        [TestMethod]
        public void TestConstructor_WithValidBirthday_CorrectConstruction()
        {
            DateTime arrivalDate = new DateTime(2023, 1, 1);
            DateTime leaveDate = new DateTime(2023, 6, 1);
            DateTime birthDate = new DateTime(2022, 1, 1);
            Cat c = new Cat("luna", "razza", Gender.FEMALE, arrivalDate, leaveDate, birthDate, null, null);

            Assert.AreEqual(birthDate, c.BirthDate);
        }
        [TestMethod]
        public void TestConstructor_BirthDateIsNull_ReturnArgumentNullException()
        {
            DateTime arrivalDate = new DateTime(2023, 1, 1);
            DateTime leaveDate = new DateTime(2023, 6, 1);
            DateTime birthDate = new DateTime(2022, 1, 1);

            Assert.ThrowsException<ArgumentNullException>(() => { Cat c = new Cat("luna", "razza", Gender.FEMALE, arrivalDate, leaveDate, null, null, null); } );
        }
        [TestMethod]
        public void TestConstructor_ProbablyYearLowerYhan1_CorrectConstruction()
        {
            DateTime arrivalDate = new DateTime(2023, 1, 1);
            DateTime leaveDate = new DateTime(2023, 6, 1);
            DateTime birthDate = new DateTime(2022, 1, 1);

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => { Cat c = new Cat("luna", "razza", Gender.FEMALE, arrivalDate, leaveDate, birthDate, 0, null, null); });
        }
        [TestMethod]
        public void TestConstructor_WithValidDescription_CorrectConstruction()
        {
            DateTime arrivalDate = new DateTime(2023, 1, 1);
            DateTime leaveDate = new DateTime(2023, 6, 1);
            DateTime birthDate = new DateTime(2022, 1, 1);
            string description = "This is a lovely cat.";
            Cat c = new Cat("luna", "razza", Gender.FEMALE, arrivalDate, leaveDate, birthDate, description, null);

            Assert.AreEqual(description, c.Description);
        }
        [TestMethod]
        public void TestEquals_ObjIsNull_ReturnFalse()
        {
            DateTime arrivalDate = new DateTime(2023, 1, 1);
            DateTime leaveDate = new DateTime(2023, 6, 1);
            DateTime birthDate = new DateTime(2022, 1, 1);
            string description = "This is a lovely cat.";
            Cat c = new Cat("luna", "razza", Gender.FEMALE, arrivalDate, leaveDate, birthDate, description, null);

            Assert.AreEqual(false, c.Equals(null));
        }
        [TestMethod]
        public void TestEquals_ObjIsNotACat_ReturnFalse()
        {
            DateTime arrivalDate = new DateTime(2023, 1, 1);
            DateTime leaveDate = new DateTime(2023, 6, 1);
            DateTime birthDate = new DateTime(2022, 1, 1);
            string description = "This is a lovely cat.";
            Cat c = new Cat("luna", "razza", Gender.FEMALE, arrivalDate, leaveDate, birthDate, description, null);
            FiscalCode fc = new FiscalCode("RSSMRA85M01H501U");
            PhoneNumber pn = new PhoneNumber("3534066278");
            Email email = new Email("utente@gmail.com");
            Cap cap = new Cap("00100");
            Adopter obj = new Adopter(fc, "nome", "cognome", pn, email, "via v", cap, "Rome");

            Assert.AreEqual(false, c.Equals(obj));
        }
        [TestMethod]
        public void TestAddAdoption_AdoptionIsNull_ReturnArgumentNullException()
        {
            DateTime arrivalDate = new DateTime(2023, 1, 1);
            DateTime leaveDate = new DateTime(2023, 6, 1);
            DateTime birthDate = new DateTime(2022, 1, 1);
            string description = "This is a lovely cat.";
            Cat c = new Cat("luna", "razza", Gender.FEMALE, arrivalDate, leaveDate, birthDate, description, null);
            Adoption a = null;

            Assert.ThrowsException<ArgumentNullException>(() => { c.AddAdoption(a); });
        }
        [TestMethod]
        public void TestAddAdoption_CatIsEqual_ReturnArgumentException()
        {
            DateTime arrivalDate = new DateTime(2023, 1, 1);
            DateTime leaveDate = new DateTime(2023, 6, 1);
            DateTime birthDate = new DateTime(2022, 1, 1);
            string description = "This is a lovely cat.";
            Cat c = new Cat("luna", "razza", Gender.FEMALE, arrivalDate, leaveDate, birthDate, description, null);
            DateTime arrivalDate2 = new DateTime(2023, 1, 1);
            DateTime leaveDate2 = new DateTime(2023, 6, 1);
            DateTime birthDate2 = new DateTime(2022, 1, 1);
            string description2 = "This is a lovely cat.";
            Cat c2 = new Cat("lexa", "razza", Gender.FEMALE, arrivalDate2, leaveDate2, birthDate2, description2, null);
            FiscalCode fc = new FiscalCode("QWERTYUIOPLKJHGF");
            PhoneNumber pn = new PhoneNumber("3534066278");
            Email email = new Email("utente@gmail.com");
            Cap cap = new Cap("00100");
            Adopter a = new Adopter(fc, "nome", "cognome", pn, email, "via v", cap, "Rome");
            Adoption ad = new Adoption(c2, arrivalDate, a);

            Assert.ThrowsException<ArgumentException>(() => { c.AddAdoption(ad); });
        }
    }
}
