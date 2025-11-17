using Application.Dto;
using Application.Interfaces;
using Application.Mappers;
using Application.UseCases;
using Domain.Model.Entities;
using Infrastructure.Persistence.Repositories;
using Microsoft.VisualBasic.FileIO;
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
        public CatService CatService;
        public AdoptionService AdoptionService;
        public AdopterService AdopterService;
        public AddCat(CatService c, AdoptionService a, AdopterService ads)
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
        private void click_AddCat(object sender, RoutedEventArgs e)
        {
            string name = txtCatName.Text;

            string breed = txtCatBreed.Text;

            Gender gender = (Gender)comboGender.SelectedItem;

            string description = txtCatDescription.Text;

            DateTime arrivalDate = (DateTime)dateCatArrivalDate.SelectedDate;

            DateTime? leaveDate = dateCatLeaveDate.SelectedDate;

            DateTime? birthDate = dateCatBirthDate.SelectedDate;

            // creo il gatto dto
            CatDto createdCatDto = new CatDto(name, breed, gender, arrivalDate, leaveDate, birthDate, description);

            // richiamo il servizio per crearlo ma prima lo trasformo in un DTO
            CatService.CreateCat(createdCatDto);

            MessageBox.Show("Gatto aggiunto con successo!");
        }
        public void click_Dashboard(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
        public void click_AddAdopter(object sender, RoutedEventArgs e)
        {
            AddAdopter addAdopterWindow = new AddAdopter(CatService, AdoptionService, AdopterService);
            addAdopterWindow.Show();
            this.Close();
        }
        public void click_ManageAdopters(object sender, RoutedEventArgs e)
        {
            ManageAdopters manageAdoptersWindow = new ManageAdopters(CatService, AdoptionService, AdopterService);
            manageAdoptersWindow.Show();
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
