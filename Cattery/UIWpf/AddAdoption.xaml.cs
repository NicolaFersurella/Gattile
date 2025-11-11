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
        AdoptionService AdoptionService;
        public AddAdoption(AdoptionService a)
        {
            InitializeComponent();

            AdoptionService = a;
        }
        private void click_AddAdoption(object sender, RoutedEventArgs e)
        {
            // ...

            // creol'adozione

            // richiamo il servizio per crearlo ma prima lo trasformo in un DTO
            
        }
    }
}
