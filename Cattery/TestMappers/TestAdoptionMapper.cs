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

            Cat cat = new Cat(
                name: "Pippo",
                breed: "Siamese",
                gender: Gender.MALE,
                arrivalDate: new DateTime(2020, 6, 1),
                leaveDate: new DateTime(2020, 12, 1),
                birthDate: new DateTime(2020, 1, 1),
                description: "A friendly cat"
            );

            Assert.ThrowsException<ArgumentNullException>(() => dto.ToDomain(cat));
        }
        [TestMethod]
        public void TestToDomain_WithValidDto_ReturnsCorrectAdoption()
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
                Fc: new Domain.Model.ValueObjects.FiscalCode("RSSMRA85M01H501U"),
                Name: "Mimmo",
                Surname: "Rossi",
                Phone: new Domain.Model.ValueObjects.PhoneNumber("3534066278"),
                Email: new Domain.Model.ValueObjects.Email("utente.utente@gmail.it"),
                Address: "Via Roma 1",
                Cap: new Domain.Model.ValueObjects.Cap("00100"),
                City: "Roma"
            );

            AdoptionDto dto = new AdoptionDto(
                Cat: cat.ToDto(),
                AdoptionDate: new DateTime(2020, 12, 1),
                Adopter: adopterDto
            );
            
            Adoption expectedAdoption = new Adoption(
                cat: cat,
                adoptionDate: dto.AdoptionDate,
                adopter: adopterDto.ToDomain()
            );

            Assert.AreEqual(expectedAdoption, dto.ToDomain(cat));
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
                Fc: new Domain.Model.ValueObjects.FiscalCode("RSSMRA85M01H501U"),
                Name: "Mimmo",
                Surname: "Rossi",
                Phone: new Domain.Model.ValueObjects.PhoneNumber("3534066278"),
                Email: new Domain.Model.ValueObjects.Email("utente.utente@gmail.it"),
                Address: "Via Roma 1",
                Cap: new Domain.Model.ValueObjects.Cap("00100"),
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

            Assert.AreEqual(expectedDto, adoption.ToDto());
        }
    }
}
