using Application.Dto;
using Application.Interfaces;
using Application.Mappers;
using Application.UseCases;
using Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Persistence.Repositories;

/*
namespace TestUseCases
{
    [TestClass]
    public sealed class TestCatService
    {
        [TestMethod]
        public void TestCreateCat_WithInvalidCatDto_ThrowsArgumentException()
        {
            JsonCatRepository repo;
            repo = null!;
            CatService service = new CatService(repo);

            CatDto dto = new CatDto(
                Name: "",
                Breed: "",
                Gender: Gender.MALE,
                ArrivalDate: new DateTime(2020, 6, 1),
                LeaveDate: null,
                BirthDate: new DateTime(2020, 1, 1),
                ProbablyYear: 0,
                Description: "A friendly cat"
            );

            Assert.ThrowsException<ArgumentException>(() => service.CreateCat(dto));
        }
        [TestMethod]
        public void TestViewAllCat_NoInvalidParameter_ReturnList()
        {
            JsonCatRepository repo;
            repo = null!;
            CatService service = new CatService(repo);

            CatDto dto1 = new CatDto(
                Name: "Pippo",
                Breed: "Siamese",
                Gender: Gender.MALE,
                ArrivalDate: new DateTime(2020, 6, 1),
                LeaveDate: new DateTime(2020, 8, 1),
                BirthDate: new DateTime(2020, 1, 1),
                ProbablyYear: null,
                Description: "A friendly cat"
            );
            CatDto dto2 = new CatDto(
                Name: "Pluto",
                Breed: "Siamese",
                Gender: Gender.MALE,
                ArrivalDate: new DateTime(2020, 6, 1),
                LeaveDate: new DateTime(2020, 8, 2),
                BirthDate: new DateTime(2020, 1, 1),
                ProbablyYear: null,
                Description: "A friendly cat"
            );

            repo.Add(dto1.ToDomain());
            repo.Add(dto2.ToDomain());

            List<CatDto> excpectedResult = new List<CatDto>() { dto1, dto2 };

            Assert.AreEqual(excpectedResult, service.ViewAll());
        }
    }
}
*/
