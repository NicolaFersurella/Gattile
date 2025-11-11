using Application.Interfaces;
using Application.Mappers;
using Application.UseCases;
using Domain.Model.Entities;
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
    /// Logica di interazione per AddAdopter.xaml
    /// </summary>
    public partial class AddAdopter : Window
    {
        public AdopterService AdopterService;
        public AddAdopter(AdopterService a)
        {
            InitializeComponent();

            AdopterService = a; 
        }
        private void click_GotFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox tb)
            {
                tb.Clear();
            }
        }
        private void click_AddAdopter(object sender, RoutedEventArgs e)
        {
            string fiscalCode = txtFiscalCode.Text;

            string name = txtAdopterName.Text;

            string surname = txtAdopterSurname.Text;

            string phoneNumber = txtAdopterPhoneNumber.Text;

            string email = txtAdopterEmail.Text;

            string address = txtAdopterAddress.Text;

            string cap = txtAdopterCap.Text;

            string city = txtAdopterCity.Text;

            // creol'adottante
            Adopter createdAdopter = new Adopter(
                new Domain.Model.ValueObjects.FiscalCode(fiscalCode), 
                name, 
                surname, 
                new Domain.Model.ValueObjects.PhoneNumber(phoneNumber), 
                new Domain.Model.ValueObjects.Email(email), 
                address, 
                new Domain.Model.ValueObjects.Cap(cap), 
                city
            );

            // richiamo il servizio per crearlo ma prima lo trasformo in un DTO
            AdopterService.CreateAdopter(createdAdopter.ToDto());
        }
    }
}
