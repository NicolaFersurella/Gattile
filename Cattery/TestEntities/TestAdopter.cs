using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model.Entities;
using Domain.Model.ValueObjects;

namespace TestEntities
{
    [TestClass]
    public sealed class TestAdopter
    {
        [TestMethod]
        public void TestConstructor_FiscalCodeIsNull_ReturnArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() => { FiscalCode fc = new FiscalCode(null); });
        }
        [TestMethod]
        public void TestConstructor_FiscalCodeWithWhiteSpace_ReturnArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() => { FiscalCode fc = new FiscalCode(" "); });
        }
        [TestMethod]
        public void TestConstructor_FiscalCodeGreaterOrLowerThan16_ReturnArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() => { FiscalCode fc = new FiscalCode("ABCDEFGHTYUHJFNDKSBFDBXKCKDB"); });
        }
        [TestMethod]
        public void TestConstructor_WithValidFiscalCode_CorretConstructor()
        {
            FiscalCode fc = new FiscalCode("QWERTYUIOPLKJHGF");
            PhoneNumber pn = new PhoneNumber("3534066278");
            Email email = new Email("utente@gmail.com");
            Cap cap = new Cap("00100");
            Adopter a = new Adopter(fc, "nome", "cognome", pn, email, "via v", cap, "Rome");

            Assert.AreEqual(fc, a.Fc);
        }
        [TestMethod]
        public void TestConstructor_NameIsNull_ReturnArgumentNullException()
        {
            FiscalCode fc = new FiscalCode("QWERTYUIOPLKJHGF");
            PhoneNumber pn = new PhoneNumber("3534066278");
            Email email = new Email("utente@gmail.com");
            Cap cap = new Cap("00100");

            Assert.ThrowsException<ArgumentNullException>(() => { Adopter a = new Adopter(fc, null, "cognome", pn, email, "via v", cap, "Rome"); });
        }
        [TestMethod]
        public void TestConstructor_NameIsEmpty_ReturnArgumentNullException()
        {
            FiscalCode fc = new FiscalCode("QWERTYUIOPLKJHGF");
            PhoneNumber pn = new PhoneNumber("3534066278");
            Email email = new Email("utente@gmail.com");
            Cap cap = new Cap("00100");

            Assert.ThrowsException<ArgumentNullException>(() => { Adopter a = new Adopter(fc, "", "cognome", pn, email, "via v", cap, "Rome"); });
        }
        [TestMethod]
        public void TestConstructor_WithValidName_CorrectConstruction()
        {
            FiscalCode fc = new FiscalCode("QWERTYUIOPLKJHGF");
            PhoneNumber pn = new PhoneNumber("3534066278");
            Email email = new Email("utente@gmail.com");
            Cap cap = new Cap("00100");
            Adopter a = new Adopter(fc, "nome", "cognome", pn, email, "via v", cap, "Rome");

            Assert.AreEqual("nome", a.Name);
        }
        [TestMethod]
        public void TestConstructor_SurnameIsNull_ReturnArgumentNullException()
        {
            FiscalCode fc = new FiscalCode("QWERTYUIOPLKJHGF");
            PhoneNumber pn = new PhoneNumber("3534066278");
            Email email = new Email("utente@gmail.com");
            Cap cap = new Cap("00100");

            Assert.ThrowsException<ArgumentNullException>(() => { Adopter a = new Adopter(fc, "nome", null, pn, email, "via v", cap, "Rome"); });
        }
        [TestMethod]
        public void TestConstructor_SurnameIsEmpty_ReturnArgumentNullException()
        {
            FiscalCode fc = new FiscalCode("QWERTYUIOPLKJHGF");
            PhoneNumber pn = new PhoneNumber("3534066278");
            Email email = new Email("utente@gmail.com");
            Cap cap = new Cap("00100");

            Assert.ThrowsException<ArgumentNullException>(() => { Adopter a = new Adopter(fc, "nome", "", pn, email, "via v", cap, "Rome"); });
        }
        [TestMethod]
        public void TestConstructor_WithValidSurname_CorrectConstruction()
        {
            FiscalCode fc = new FiscalCode("QWERTYUIOPLKJHGF");
            PhoneNumber pn = new PhoneNumber("3534066278");
            Email email = new Email("utente@gmail.com");
            Cap cap = new Cap("00100");
            Adopter a = new Adopter(fc, "nome", "cognome", pn, email, "via v", cap, "Rome");

            Assert.AreEqual("cognome", a.Surname);
        }
        [TestMethod]
        public void TestConstructor_PhoneNumberIsNull_ReturnArgumentNullException()
        {
            Assert.ThrowsException<ArgumentNullException>(() => { PhoneNumber pn = new PhoneNumber(null); });
        }
        [TestMethod]
        public void TestConstructor_PhoneNumberWithWhiteSpace_ReturnArgumentNullException()
        {
            Assert.ThrowsException<ArgumentNullException>(() => { PhoneNumber pn = new PhoneNumber(" "); });
        }
        [TestMethod]
        public void TestConstructor_PhoneNumberWithInvalidFormat_ReturnArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() => { PhoneNumber pn = new PhoneNumber("+303534066278"); });
        }
        [TestMethod]
        public void TestConstructor_PhoneNumberLowerThan7_ReturnArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() => { PhoneNumber pn = new PhoneNumber("353405"); });
        }
        [TestMethod]
        public void TestConstructor_WithValidPhoneNumber_CorretConstructor()
        {
            FiscalCode fc = new FiscalCode("QWERTYUIOPLKJHGF");
            PhoneNumber pn = new PhoneNumber("3534066278");
            Email email = new Email("utente@gmail.com");
            Cap cap = new Cap("00100");
            Adopter a = new Adopter(fc, "nome", "cognome", pn, email, "via v", cap, "Rome");

            Assert.AreEqual(pn, a.Phone);
        }
        [TestMethod]
        public void TestConstructor_AddressIsNull_ReturnArgumentNullException()
        {
            FiscalCode fc = new FiscalCode("QWERTYUIOPLKJHGF");
            PhoneNumber pn = new PhoneNumber("3534066278");
            Email email = new Email("utente@gmail.com");
            Cap cap = new Cap("00100");

            Assert.ThrowsException<ArgumentNullException>(() => { Adopter a = new Adopter(fc, "nome", "cognome", pn, email, null, cap, "Rome"); });
        }
        [TestMethod]
        public void TestConstructor_AddressIsEmpty_ReturnArgumentNullException()
        {
            FiscalCode fc = new FiscalCode("QWERTYUIOPLKJHGF");
            PhoneNumber pn = new PhoneNumber("3534066278");
            Email email = new Email("utente@gmail.com");
            Cap cap = new Cap("00100");

            Assert.ThrowsException<ArgumentNullException>(() => { Adopter a = new Adopter(fc, "nome", "cognome", pn, email, "", cap, "Rome"); });
        }
        [TestMethod]
        public void TestConstructor_WithValidAddress_CorrectConstruction()
        {
            FiscalCode fc = new FiscalCode("QWERTYUIOPLKJHGF");
            PhoneNumber pn = new PhoneNumber("3534066278");
            Email email = new Email("utente@gmail.com");
            Cap cap = new Cap("00100");
            Adopter a = new Adopter(fc, "nome", "cognome", pn, email, "via v", cap, "Rome");

            Assert.AreEqual("via v", a.Address);
        }
        [TestMethod]
        public void TestConstructor_CapIsNull_ReturnArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() => { Cap cap = new Cap(null); });
        }
        [TestMethod]
        public void TestConstructor_CapWithWhiteSpace_ReturnArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() => { Cap cap = new Cap(" "); });
        }
        [TestMethod]
        public void TestConstructor_CapGreaterOrLowerThan5_ReturnArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() => { Cap cap = new Cap("123456789"); });
        }
        [TestMethod]
        public void TestConstructor_CapWithInvalidFormat_ReturnArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() => { Cap cap = new Cap("Ab123"); });
        }
        [TestMethod]
        public void TestConstructor_WithValidCap_CorrectConstruction()
        {
            FiscalCode fc = new FiscalCode("QWERTYUIOPLKJHGF");
            PhoneNumber pn = new PhoneNumber("3534066278");
            Email email = new Email("utente@gmail.com");
            Cap cap = new Cap("00100");
            Adopter a = new Adopter(fc, "nome", "cognome", pn, email, "via v", cap, "Rome");

            Assert.AreEqual(cap, a.Cap);
        }
        [TestMethod]
        public void TestConstructor_CityIsNull_ReturnArgumentNullException()
        {
            FiscalCode fc = new FiscalCode("QWERTYUIOPLKJHGF");
            PhoneNumber pn = new PhoneNumber("3534066278");
            Email email = new Email("utente@gmail.com");
            Cap cap = new Cap("00100");

            Assert.ThrowsException<ArgumentNullException>(() => { Adopter a = new Adopter(fc, "nome", "cognome", pn, email, "via v", cap, null); });
        }
        [TestMethod]
        public void TestConstructor_CityIsEmpty_ReturnArgumentNullException()
        {
            FiscalCode fc = new FiscalCode("QWERTYUIOPLKJHGF");
            PhoneNumber pn = new PhoneNumber("3534066278");
            Email email = new Email("utente@gmail.com");
            Cap cap = new Cap("00100");

            Assert.ThrowsException<ArgumentNullException>(() => { Adopter a = new Adopter(fc, "nome", "cognome", pn, email, "via v", cap, ""); });
        }
        [TestMethod]
        public void TestConstructor_WithValidCity_CorrectConstruction()
        {
            FiscalCode fc = new FiscalCode("QWERTYUIOPLKJHGF");
            PhoneNumber pn = new PhoneNumber("3534066278");
            Email email = new Email("utente@gmail.com");
            Cap cap = new Cap("00100");
            Adopter a = new Adopter(fc, "nome", "cognome", pn, email, "via v", cap, "Rome");

            Assert.AreEqual("Rome", a.City);
        }
        [TestMethod]
        public void TestToString_WithValidNameAndSurname_ReturnString()
        {
            FiscalCode fc = new FiscalCode("QWERTYUIOPLKJHGF");
            PhoneNumber pn = new PhoneNumber("3534066278");
            Email email = new Email("utente@gmail.com");
            Cap cap = new Cap("00100");
            Adopter a = new Adopter(fc, "nome", "cognome", pn, email, "via v", cap, "Rome");
            
            Assert.AreEqual("nome cognome", a.ToString());  
        }
    }
}
