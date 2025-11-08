using Application.Dto;
using Application.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model.Entities;
using Application.Dto;


namespace TestMappers
{
    [TestClass]
    public sealed class TestAdoptionMapper
    {
        [TestMethod]
        public void TestToDomain_WithDtoNull_ThrowsArgumentNullException()
        {
            AdoptionDto dto = null;

            Assert.ThrowsException<ArgumentNullException>(() => dto.ToDomain());
        }
        [TestMethod]
        public void TestToDomain_WithValidDto_ReturnsCorrectAdoption()
        {
            Cat cat = new Cat(
                "Pippo",
                "Siamese",
                Gender.MALE,
                new DateTime(2020, 6, 1),
                new DateTime(2020, 12, 1),
                new DateTime(2020, 1, 1),
                "A friendly cat"
            );

            AdopterDto adopterDto = new AdopterDto(
                "RSSMRA85M01H501U",
                "Luca",
                "Diddi",
                "3534066278",
                "utente.utente@gmail.it",
                "Via Franco 1",
                "00100",
                "Roma"
            );

            AdoptionDto dto = new AdoptionDto(
                cat.ToDto(),
                new DateTime(2020, 12, 1),
                adopterDto
            );
            
            Adoption expectedAdoption = new Adoption(
                cat,
                dto.AdoptionDate,
                adopterDto.ToDomain()
            );

            Assert.AreEqual(expectedAdoption.Cat.Name, dto.ToDomain().Cat.Name);
            Assert.AreEqual(expectedAdoption.Cat.Breed, dto.ToDomain().Cat.Breed);
            Assert.AreEqual(expectedAdoption.Cat.Gender, dto.ToDomain().Cat.Gender);
            Assert.AreEqual(expectedAdoption.Cat.ArrivalDate, dto.ToDomain().Cat.ArrivalDate);
            Assert.AreEqual(expectedAdoption.Cat.LeaveDate, dto.ToDomain().Cat.LeaveDate);
            Assert.AreEqual(expectedAdoption.Cat.BirthDate, dto.ToDomain().Cat.BirthDate);
            Assert.AreEqual(expectedAdoption.Cat.Description, dto.ToDomain().Cat.Description);
            Assert.AreEqual(expectedAdoption.AdoptionDate, dto.ToDomain().AdoptionDate);
            Assert.AreEqual(expectedAdoption.Adopter.Fc, dto.ToDomain().Adopter.Fc);
            Assert.AreEqual(expectedAdoption.Adopter.Name, dto.ToDomain().Adopter.Name);
            Assert.AreEqual(expectedAdoption.Adopter.Surname, dto.ToDomain().Adopter.Surname);
            Assert.AreEqual(expectedAdoption.Adopter.Phone, dto.ToDomain().Adopter.Phone);
            Assert.AreEqual(expectedAdoption.Adopter.Email, dto.ToDomain().Adopter.Email);
            Assert.AreEqual(expectedAdoption.Adopter.Address, dto.ToDomain().Adopter.Address);
            Assert.AreEqual(expectedAdoption.Adopter.Cap, dto.ToDomain().Adopter.Cap);
            Assert.AreEqual(expectedAdoption.Adopter.City, dto.ToDomain().Adopter.City);
        }
        [TestMethod]
        public void TestToDto_WithEntityNull_ThrowsArgumentNullException()
        {
            Adoption entity = null;

            Cat cat = new Cat(
                name: "Pippo",
                breed: "Siamese",
                gender: Gender.MALE,
                arrivalDate: new DateTime(2020, 6, 1),
                leaveDate: new DateTime(2020, 12, 1),
                birthDate: new DateTime(2020, 1, 1),
                description: "A friendly cat"
            );

            Assert.ThrowsException<ArgumentNullException>(() => entity.ToDto());
        }
        [TestMethod]
        public void TestToDto_WithValidEntity_ReturnsCorrectAdoptionDto()
        {
            Cat cat = new Cat(
                name: "Pippo",
                breed: "Siamese",
                gender: Gender.MALE,
                arrivalDate: new DateTime(2020, 6, 1),
                leaveDate: new DateTime(2020, 12, 1),
                birthDate: new DateTime(2020, 1, 1),
                description: "A friendly cat"
            );

            AdopterDto adopterDto = new AdopterDto(
                Fc: "RSSMRA85M01H501U",
                Name: "Luca",
                Surname: "Diddi",
                Phone: "3534066278",
                Email: "utente.utente@gmail.it",
                Address: "Via Franco 1",
                Cap: "00100",
                City: "Roma"
            );

            Adoption adoption = new Adoption(
                cat: cat,
                adoptionDate: new DateTime(2020, 12, 1),
                adopter: adopterDto.ToDomain()
            );

            AdoptionDto expectedDto = new AdoptionDto(
                Cat: cat.ToDto(),
                AdoptionDate: new DateTime(2020, 12, 1),
                Adopter: adopterDto
            );

            Assert.AreEqual(expectedDto.Cat.Name, adoption.ToDto().Cat.Name);
            Assert.AreEqual(expectedDto.Cat.Breed, adoption.ToDto().Cat.Breed);
            Assert.AreEqual(expectedDto.Cat.Gender, adoption.ToDto().Cat.Gender);
            Assert.AreEqual(expectedDto.Cat.ArrivalDate, adoption.ToDto().Cat.ArrivalDate);
            Assert.AreEqual(expectedDto.Cat.LeaveDate, adoption.ToDto().Cat.LeaveDate);
            Assert.AreEqual(expectedDto.Cat.BirthDate, adoption.ToDto().Cat.BirthDate);
            Assert.AreEqual(expectedDto.Cat.Description, adoption.ToDto().Cat.Description);
            Assert.AreEqual(expectedDto.AdoptionDate, adoption.ToDto().AdoptionDate);
            Assert.AreEqual(expectedDto.Adopter.Fc, adoption.ToDto().Adopter.Fc);
            Assert.AreEqual(expectedDto.Adopter.Name, adoption.ToDto().Adopter.Name);
            Assert.AreEqual(expectedDto.Adopter.Surname, adoption.ToDto().Adopter.Surname);
            Assert.AreEqual(expectedDto.Adopter.Phone, adoption.ToDto().Adopter.Phone);
            Assert.AreEqual(expectedDto.Adopter.Email, adoption.ToDto().Adopter.Email);
            Assert.AreEqual(expectedDto.Adopter.Address, adoption.ToDto().Adopter.Address);
            Assert.AreEqual(expectedDto.Adopter.Cap, adoption.ToDto().Adopter.Cap);
            Assert.AreEqual(expectedDto.Adopter.City, adoption.ToDto().Adopter.City);
        }
    }
}
