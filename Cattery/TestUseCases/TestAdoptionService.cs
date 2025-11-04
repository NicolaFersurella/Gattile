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

namespace TestUseCases
{
    [TestClass]
    public sealed class TestAdoptionService
    {
        [TestMethod]
        public void TestCreateAdoption_WithInvalidAdoptionDto_ThrowsArgumentException()
        {
            IAdoptionRepository repo;
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
        public void TestRemoveAdoption_WithInvalidAdoptionDto_ThrowsArgumentException()
        {
            IAdoptionRepository repo;
            repo = null!;
            AdoptionService service = new AdoptionService(repo);

            AdoptionDto dto = new AdoptionDto(
                Cat: null,
                AdoptionDate: new DateTime(2020, 12, 1),
                Adopter: null
            );

            Assert.ThrowsException<ArgumentException>(() => service.RemoveAdoption(dto));
        }
    }
}
