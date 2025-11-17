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
    /// Logica di interazione per AddAdoption.xaml
    /// </summary>
    public partial class AddAdoption : Window
    {
        CatService CatService;
        AdopterService AdopterService;
        AdoptionService AdoptionService;
        public AddAdoption( AdoptionService a, CatService catService, AdopterService adopterService)
        {
            InitializeComponent();

            AdoptionService = a;
            CatService = catService;
            AdopterService = adopterService;
        }
        private void click_AddAdoption(object sender, RoutedEventArgs e)
        {
            // ...

            // creol'adozione

            // richiamo il servizio per crearlo ma prima lo trasformo in un DTO
            
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
        public void click_AddAdopter(object sender, RoutedEventArgs e)
        {
            AddAdopter addAdoptionWindow = new AddAdopter(CatService, AdoptionService, AdopterService);
            addAdoptionWindow.Show();
            this.Close();
        }
        public void click_ManageAdopters(object sender, RoutedEventArgs e)
        {
            ManageAdopters manageAdoptersWindow = new ManageAdopters(CatService, AdoptionService, AdopterService);
            manageAdoptersWindow.Show();
            this.Close();
        }
    }
}
