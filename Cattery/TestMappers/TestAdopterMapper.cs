using Application.Mappers;
using Application.Dto;
using Domain.Model.Entities;
namespace TestMappers
{
    [TestClass]
    public sealed class TestAdopterMapper
    {
        [TestMethod]
        public void TestToDomain_WithDtoNull_ThrowsArgumentNullException()
        {
            AdopterDto dto = null;

            Assert.ThrowsException<ArgumentNullException>(() => dto.ToDomain());
        }
        [TestMethod]
        public void TestToDomain_WithValidDto_ReturnsCorrectAdopter()
        {
            AdopterDto dto = new AdopterDto(
                Fc: new Domain.Model.ValueObjects.FiscalCode("RSSMRA85M01H501U"),
                Name: "Mimmo",
                Surname: "Rossi",
                Phone: new Domain.Model.ValueObjects.PhoneNumber("3534066278"),
                Email: new Domain.Model.ValueObjects.Email("utente.utente@gmail.it"),
                Address: "Via Roma 1",
                Cap: new Domain.Model.ValueObjects.Cap("00100"),
                City: "Roma"
            );

            Adopter adopter = new Adopter(
                fc: dto.Fc,
                name: dto.Name,
                surname: dto.Surname,
                number: dto.Phone,
                email: dto.Email,
                address: dto.Address,
                cap: dto.Cap,
                city: dto.City
            );

            Assert.AreEqual(adopter, dto.ToDomain());
        }
        [TestMethod]
        public void TestToDto_WithEntityNull_ThrowsArgumentNullException()
        {
            Adopter entity = null;

            Assert.ThrowsException<ArgumentNullException>(() => entity.ToDto());
        }
        [TestMethod]
        public void TestToDto_WithValidEntity_ReturnsCorrectAdopterDto()
        {
            Adopter adopter = new Adopter(
                fc: new Domain.Model.ValueObjects.FiscalCode("RSSMRA85M01H501U"),
                name: "Luca",
                surname: "Diddi",
                number: new Domain.Model.ValueObjects.PhoneNumber("3534066278"),
                email: new Domain.Model.ValueObjects.Email("utente.utente@gmail.it"),
                address: "Via Franco 1",
                cap: new Domain.Model.ValueObjects.Cap("00100"),
                city: "Roma"
            );

            AdopterDto dto = new AdopterDto(
                Fc: adopter.Fc,
                Name: adopter.Name,
                Surname: adopter.Surname,
                Phone: adopter.Phone,
                Email: adopter.Email,
                Address: adopter.Address,
                Cap: adopter.Cap,
                City: adopter.City
            );

            Assert.AreEqual(dto, adopter.ToDto());
        }
    }
}