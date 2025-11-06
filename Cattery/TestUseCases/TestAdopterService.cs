using Application.Dto;
using Application.Interfaces;
using Application.Mappers;
using Application.UseCases;
using Infrastructure.Persistence.Repositories;

/*
namespace TestUseCases
{
    [TestClass]
    public sealed class TestAdopterService
    {
        [TestMethod]
        public void TestCreateAdopter_WithInvalidAdopterDto_ThrowsArgumentException()
        {
            JsonAdopterRepository repo;
            repo = null!;
            AdopterService service = new AdopterService(repo);

            AdopterDto dto = new AdopterDto(
                Fc: "RSSMRA85M01H501U",
                Name: "",
                Surname: "",
                Phone: "3534066278",
                Email: "utente.utente@gmail.it",
                Address: "Via Roma 1",
                Cap: "00100",
                City: "Roma"
            );

            Assert.ThrowsException<ArgumentException>(() => service.CreateAdopter(dto));
        }
        [TestMethod]
        public void TestRemoveAdopter_WithInvalidAdopterDto_ThrowsArgumentException()
        {
            JsonAdopterRepository repo;
            repo = null!;
            AdopterService service = new AdopterService(repo);

            AdopterDto dto = new AdopterDto(
                Fc: "RSSMRA85M01H501U",
                Name: "",
                Surname: "",
                Phone: "3534066278",
                Email: "utente.utente@gmail.it",
                Address: "Via Roma 1",
                Cap: "00100",
                City: "Roma"
            );

            Assert.ThrowsException<ArgumentException>(() => service.RemoveAdopter(dto));
        }
    }
}
*/
