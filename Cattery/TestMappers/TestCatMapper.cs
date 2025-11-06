using Application.Dto;
using Application.Mappers;
using Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
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
                ProbablyYear: 1,
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

            Assert.AreEqual(cat, dto.ToDomain());
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
                probablyYear: 1,
                birthDate: new DateTime(2020, 1, 1),
                description: "A friendly cat",
                adoptions: null
            );

            CatDto dto = new CatDto(
                Name: cat.Name,
                Breed: cat.Breed,
                Gender: cat.Gender,
                ArrivalDate: cat.ArrivalDate,
                LeaveDate: cat.LeaveDate,
                ProbablyYear: cat.ProbablyYear,
                BirthDate: cat.BirthDate,
                Description: cat.Description,
                Adoptions: cat.Adoptions?.ToList()
            );

            Assert.AreEqual(dto, cat.ToDto());
        }
    }
}
*/
