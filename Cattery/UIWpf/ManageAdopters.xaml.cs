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
    /// Logica di interazione per ManageAdopters.xaml
    /// </summary>
    public partial class ManageAdopters : Window
    {
        public CatService CatService;
        public AdoptionService AdoptionService;
        public AdopterService AdopterService;
        public ManageAdopters(CatService c, AdoptionService a, AdopterService ads)
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
