using Application.UseCases;
using Infrastructure.Persistence.Repositories;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UIWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public CatService catService;
        public AdopterService adopterService;
        public AdoptionService adoptionService;

        //public JsonCatRepository catRepository = new JsonCatRepository();
        //public JsonAdopterRepository adopterRepository = new JsonAdopterRepository();
        //public JsonAdoptionRepository adoptionRepository = new JsonAdoptionRepository();

        public MainWindow()
        {
            InitializeComponent();
        }

        public void click_AddCat(object sender, RoutedEventArgs e)
        {
            AddCat addCatWindow = new AddCat(catService);
            addCatWindow.ShowDialog();
        }
        public void click_ManageCats(object sender, RoutedEventArgs e)
        {
            ManageCats manageCatsWindow = new ManageCats();
            manageCatsWindow.ShowDialog();
        }
        public void click_AddAdopter(object sender, RoutedEventArgs e)
        {
            AddAdopter addAdopterWindow = new AddAdopter(adopterService);
            addAdopterWindow.ShowDialog();
        }
        public void click_ManageAdopters(object sender, RoutedEventArgs e)
        {
            ManageAdopters manageAdoptersWindow = new ManageAdopters();
            manageAdoptersWindow.ShowDialog();
        }
        public void click_AddAdoption(object sender, RoutedEventArgs e)
        {
            AddAdoption addAdoptionWindow = new AddAdoption(adoptionService);
            addAdoptionWindow.ShowDialog();
        }
        public void click_ManageAdoptions(object sender, RoutedEventArgs e)
        {
            ManageAdoptions manageAdoptionsWindow = new ManageAdoptions();
            manageAdoptionsWindow.ShowDialog();
        }
    }
}