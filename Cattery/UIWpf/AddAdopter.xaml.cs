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
        public CatService CatService;
        public AdoptionService AdoptionService;
        public AdopterService AdopterService;
        public AddAdopter(CatService c, AdoptionService a, AdopterService ads)
        {
            InitializeComponent();

            CatService = c;
            AdoptionService = a;
            AdopterService = ads;
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

            // creol'adottante dto
            AdopterDto createdAdopter = new AdopterDto(fiscalCode, name, surname, phoneNumber, email, address, cap, city);

            // richiamo il servizio per crearlo ma prima lo trasformo in un DTO
            AdopterService.CreateAdopter(createdAdopter);

            MessageBox.Show("Adottante aggiunto con successo!");
        }
        public void click_Dashboard(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
        public void click_AddCat(object sender, RoutedEventArgs e)
        {
            AddCat addCatWindow = new AddCat(CatService, AdoptionService, AdopterService);
            addCatWindow.Show();
            this.Close();
        }
        public void click_ManageCats(object sender, RoutedEventArgs e)
        {
            ManageCats manageCatsWindow = new ManageCats(CatService, AdoptionService, AdopterService);
            manageCatsWindow.Show();
            this.Close();
        }
        public void click_AddAdoption(object sender, RoutedEventArgs e)
        {
            AddAdoption addAdoptionWindow = new AddAdoption(AdoptionService, CatService, AdopterService);
            addAdoptionWindow.Show();
            this.Close();
        }
        public void click_ManageAdoptions(object sender, RoutedEventArgs e)
        {
            ManageAdoptions manageAdoptionsWindow = new ManageAdoptions(CatService, AdoptionService, AdopterService);
            manageAdoptionsWindow.Show();
            this.Close();
        }
    }
}
