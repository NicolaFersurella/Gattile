using Infrastructure.Persistence.Repositories;
using Application.UseCases;
using Application.Dto;
using Domain.Model.Entities;

namespace UIConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            JsonCatRepository catRepo = new JsonCatRepository();
            JsonAdoptionRepository adoptionRepo = new JsonAdoptionRepository();
            CatService catService = new CatService(catRepo);
            AdoptionService adoptionService = new AdoptionService(adoptionRepo);

            DateTime arrivalDate = new DateTime(2020, 6, 1);
            DateTime birthDate = new DateTime(2020, 1, 1);

            CatDto newCat = new CatDto("Pluto", "Siamese", Gender.MALE, arrivalDate, null, birthDate, 5, "A friendly cat");

            AdopterDto adopterDto = new AdopterDto("RSSMRA85M01H501U", "Mimmo", "Franco", "3534066278", "utente.utente@gmail.it", "via Roma", "47122", "Milan");

            AdoptionDto adoptionDto = new AdoptionDto(newCat, DateTime.Now, adopterDto);

            try
            {
                catService.CreateCat(newCat);
                Console.WriteLine("Cat created successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating cat: {ex.Message}");
            }
            try
            {
                adoptionService.CreateAdoption(adoptionDto);
                Console.WriteLine("Adoption created successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating adoption: {ex.Message}");
            }
        }
    }
}
