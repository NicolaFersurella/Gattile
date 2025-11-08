using Application.Dto;
using Application.Mappers;
using Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TestMappers
{
    [TestClass]
    public sealed class TestCatMapper
    {
        [TestMethod]
        public void TestToDomain_WithDtoNull_ThrowsArgumentNullException()
        {
            CatDto dto = null;

            Assert.ThrowsException<ArgumentNullException>(() => dto.ToDomain());
        }
        [TestMethod]
        public void TestToDomain_WithValidDto_ReturnsCorrectCat()
        {
            CatDto dto = new CatDto(
                Name: "Pippo",
                Breed: "Siamese",
                Gender: Gender.MALE,
                ArrivalDate: new DateTime(2020, 6, 1),
                LeaveDate: null,
                BirthDate: new DateTime(2020, 1, 1),
                Description: "A friendly cat"
            );

            Cat cat = new Cat(
                dto.Name,
                dto.Breed,
                dto.Gender,
                dto.ArrivalDate,
                dto.LeaveDate,
                dto.BirthDate,
                dto.Description
            );

            Assert.AreEqual(cat.Name, dto.ToDomain().Name);
            Assert.AreEqual(cat.Breed, dto.ToDomain().Breed);
            Assert.AreEqual(cat.Gender, dto.ToDomain().Gender);
            Assert.AreEqual(cat.ArrivalDate, dto.ToDomain().ArrivalDate);
            Assert.AreEqual(cat.LeaveDate, dto.ToDomain().LeaveDate);
            Assert.AreEqual(cat.BirthDate, dto.ToDomain().BirthDate);
            Assert.AreEqual(cat.Description, dto.ToDomain().Description);
        }
        [TestMethod]
        public void TestToDto_WithEntityNull_ThrowsArgumentNullException()
        {
            Cat entity = null;

            Assert.ThrowsException<ArgumentNullException>(() => entity.ToDto());
        }
        [TestMethod]
        public void TestToDto_WithValidEntity_ReturnsCorrectCatDto()
        {
            Cat cat = new Cat(
                name: "Pippo",
                breed: "Siamese",
                gender: Gender.MALE,
                arrivalDate: new DateTime(2020, 6, 1),
                leaveDate: null,
                birthDate: new DateTime(2020, 1, 1),
                description: "A friendly cat"
            );

            CatDto dto = new CatDto(
                Name: cat.Name,
                Breed: cat.Breed,
                Gender: cat.Gender,
                ArrivalDate: cat.ArrivalDate,
                LeaveDate: cat.LeaveDate,
                BirthDate: cat.BirthDate,
                Description: cat.Description
            );

            Assert.AreEqual(dto.Name, cat.ToDto().Name);
            Assert.AreEqual(dto.Breed, cat.ToDto().Breed);
            Assert.AreEqual(dto.Gender, cat.ToDto().Gender);
            Assert.AreEqual(dto.ArrivalDate, cat.ToDto().ArrivalDate);
            Assert.AreEqual(dto.LeaveDate, cat.ToDto().LeaveDate);
            Assert.AreEqual(dto.BirthDate, cat.ToDto().BirthDate);
            Assert.AreEqual(dto.Description, cat.ToDto().Description);
        }
    }
}
