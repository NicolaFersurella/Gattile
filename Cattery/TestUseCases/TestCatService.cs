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
                Description: "A friendly cat"
            );

            Assert.ThrowsException<ArgumentException>(() => service.CreateCat(dto));
        }
        [TestMethod]
        public void TestUpdateCat_WithInvalidCatDto_ThrowsArgumentException()
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
                Description: "A friendly cat"
            );

            Assert.ThrowsException<ArgumentException>(() => service.UpdateCat(dto));
        }
        [TestMethod]
        public void TestRemoveCatByCatDto_WithInvalidCatDto_ThrowsArgumentException()
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
                Description: "A friendly cat"
            );

            Assert.ThrowsException<ArgumentException>(() => service.RemoveCatByCatDto(dto));
        }
        [TestMethod]
        public void TestRemoveCatById_WithInvalidIdEmpty_ThrowsArgumentException()
        {
            JsonCatRepository repo;
            repo = null!;
            CatService service = new CatService(repo);

            string id = "";

            Assert.ThrowsException<ArgumentException>(() => service.RemoveCatById(id));
        }
        [TestMethod]
        public void TestRemoveCatById_WithInvalidIdNull_ThrowsArgumentException()
        {
            JsonCatRepository repo;
            repo = null!;
            CatService service = new CatService(repo);

            string id = null;

            Assert.ThrowsException<ArgumentException>(() => service.RemoveCatById(id));
        }
        [TestMethod]
        public void TestGetCatById_WithInvalidIdEmpty_ThrowsArgumentException()
        {
            JsonCatRepository repo;
            repo = null!;
            CatService service = new CatService(repo);

            string id = "";

            Assert.ThrowsException<ArgumentException>(() => service.GetCatById(id));
        }
        [TestMethod]
        public void TestGetCatById_WithInvalidIdNull_ThrowsArgumentException()
        {
            JsonCatRepository repo;
            repo = null!;
            CatService service = new CatService(repo);

            string id = null;

            Assert.ThrowsException<ArgumentException>(() => service.GetCatById(id));
        }
    }
}
