using Application.Interfaces;
using Application.Mappers;
using Application.UseCases;
using Domain.Model.Entities;
using Infrastructure.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace UIWpf
{
    /// <summary>
    /// Logica di interazione per AddCat.xaml
    /// </summary>
    public partial class AddCat : Window
    {
        public CatService catService;
        public AddCat(CatService c)
        {
            InitializeComponent();

            catService = c;
        }
        private void click_GotFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox tb)
            {
                tb.Clear();
            }
        }

        private void click_AddCat(object sender, RoutedEventArgs e)
        {
            string name = txtCatName.Text;

            string breed = txtCatBreed.Text;

            string genderText = txtCatGender.Text;
            Gender gender = Enum.Parse<Gender>(genderText);

            string description = txtCatDescription.Text;

            DateTime arrivalDate = (DateTime)dateCatArrivalDate.SelectedDate;

            DateTime? leaveDate = dateCatLeaveDate.SelectedDate;

            DateTime? birthDate = dateCatBirthDate.SelectedDate;

            // creo il gatto
            Cat createdCat = new Cat(name, breed, gender, arrivalDate, leaveDate, birthDate, description);

            // richiamo il servizio per crearlo ma prima lo trasformo in un DTO
            catService.CreateCat(createdCat.ToDto());
        }
    }
}
