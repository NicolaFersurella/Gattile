using Application.Dto;
using Application.Interfaces;
using Application.UseCases;
using Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Mappers;
using Infrastructure.Persistence.Repositories;


namespace TestUseCases
{
    [TestClass]
    public sealed class TestAdoptionService
    {
        [TestMethod]
        public void TestCreateAdoption_WithInvalidAdoptionDto_ThrowsArgumentException()
        {
            JsonAdoptionRepository repo;
            repo = null!;
            AdoptionService service = new AdoptionService(repo);

            AdoptionDto dto = new AdoptionDto(
                Cat: null,
                AdoptionDate: new DateTime(2020, 12, 1),
                Adopter: null
            );

            Assert.ThrowsException<ArgumentException>(() => service.CreateAdoption(dto));
        }
        [TestMethod]
        public void TestUpdateAdoption_WithInvalidAdoptionDto_ThrowsArgumentException()
        {
            JsonAdoptionRepository repo;
            repo = null!;
            AdoptionService service = new AdoptionService(repo);

            AdoptionDto dto = new AdoptionDto(
                Cat: null,
                AdoptionDate: new DateTime(2020, 12, 1),
                Adopter: null
            );

            Assert.ThrowsException<ArgumentException>(() => service.UpdateAdoption(dto));
        }
        [TestMethod]
        public void TestRemoveAdoption_WithInvalidAdoptionDto_ThrowsArgumentException()
        {
            JsonAdoptionRepository repo;
            repo = null!;
            AdoptionService service = new AdoptionService(repo);

            AdoptionDto dto = new AdoptionDto(
                Cat: null,
                AdoptionDate: new DateTime(2020, 12, 1),
                Adopter: null
            );

            Assert.ThrowsException<ArgumentException>(() => service.RemoveAdoption(dto));
        }
        [TestMethod]
        public void TestGetAdoptionByIdCat_WithInvalidIdEmpty_ThrowsArgumentException()
        {
            JsonAdoptionRepository repo;
            repo = null!;
            AdoptionService service = new AdoptionService(repo);

            string id = "";

            Assert.ThrowsException<ArgumentException>(() => service.GetAdoptionByIdCat(id));
        }
        [TestMethod]
        public void TestGetAdoptionByIdCat_WithInvalidIdNull_ThrowsArgumentException()
        {
            JsonAdoptionRepository repo;
            repo = null!;
            AdoptionService service = new AdoptionService(repo);

            string id = null;

            Assert.ThrowsException<ArgumentException>(() => service.GetAdoptionByIdCat(id));
        }
        [TestMethod]
        public void TestGetAdoptionByFiscalCodeAdopter_WithInvalidFcEmpty_ThrowsArgumentException()
        {
            JsonAdoptionRepository repo;
            repo = null!;
            AdoptionService service = new AdoptionService(repo);

            string fc = "";

            Assert.ThrowsException<ArgumentException>(() => service.GetAdoptionByFiscalCodeAdopter(fc));
        }
        [TestMethod]
        public void TestGetAdoptionByFiscalCodeAdopter_WithInvalidFcNull_ThrowsArgumentException()
        {
            JsonAdoptionRepository repo;
            repo = null!;
            AdoptionService service = new AdoptionService(repo);

            string fc = null;

            Assert.ThrowsException<ArgumentException>(() => service.GetAdoptionByIdCat(fc));
        }
    }
}
