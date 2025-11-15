using Application.UseCases;
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
    /// Logica di interazione per ManageCats.xaml
    /// </summary>
    public partial class ManageCats : Window
    {
        public CatService CatService;
        public AdoptionService AdoptionService;
        public AdopterService AdopterService;
        public ManageCats(CatService c, AdoptionService a, AdopterService ads)
        {
            InitializeComponent();

            CatService = c;
            AdoptionService = a;
            AdopterService = ads;
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
            AddAdoption addAdoptionWindow = new AddAdoption(AdoptionService);
            addAdoptionWindow.Show();
            this.Close();
        }
        public void click_ManageAdoptions(object sender, RoutedEventArgs e)
        {
            ManageAdoptions manageAdoptionsWindow = new ManageAdoptions();
            manageAdoptionsWindow.Show();
            this.Close();
        }
    }
}
