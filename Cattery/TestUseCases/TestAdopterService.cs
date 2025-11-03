using Application.Dto;
using Application.Interfaces;
using Application.Mappers;
using Application.UseCases;

namespace TestUseCases
{
    [TestClass]
    public sealed class TestAdopterService
    {
        [TestMethod]
        public void TestCreateAdopter_WithInvalidAdopterDto_ThrowsArgumentException()
        {
            IAdopterRepository repo;
            repo = null!;
            AdopterService service = new AdopterService(repo);

            AdopterDto dto = new AdopterDto(
                Fc: new Domain.Model.ValueObjects.FiscalCode("RSSMRA85M01H501U"),
                Name: "",
                Surname: "",
                Phone: new Domain.Model.ValueObjects.PhoneNumber("3534066278"),
                Email: new Domain.Model.ValueObjects.Email("utente.utente@gmail.it"),
                Address: "Via Roma 1",
                Cap: new Domain.Model.ValueObjects.Cap("00100"),
                City: "Roma"
            );

            Assert.ThrowsException<ArgumentException>(() => service.CreateAdopter(dto));
        }
        [TestMethod]
        public void TestRemoveAdopter_WithInvalidAdopterDto_ThrowsArgumentException()
        {
            IAdopterRepository repo;
            repo = null!;
            AdopterService service = new AdopterService(repo);

            AdopterDto dto = new AdopterDto(
                Fc: new Domain.Model.ValueObjects.FiscalCode("RSSMRA85M01H501U"),
                Name: "",
                Surname: "",
                Phone: new Domain.Model.ValueObjects.PhoneNumber("3534066278"),
                Email: new Domain.Model.ValueObjects.Email("utente.utente@gmail.it"),
                Address: "Via Roma 1",
                Cap: new Domain.Model.ValueObjects.Cap("00100"),
                City: "Roma"
            );

            Assert.ThrowsException<ArgumentException>(() => service.RemoveAdopter(dto));
        }
    }
}
