using ClientsDataCollection.DataBases;
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

namespace ClientsDataCollection.Views
{
    /// <summary>
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : Window
    {
        MainWindow mv = new MainWindow();
        public Add()
        {
            InitializeComponent();
        }

        private void ApplyClick(object sender, RoutedEventArgs e)
        {
            using (PowerNetEntitiess entitiess = new PowerNetEntitiess())
            {
                try
                {
                    Clients clients = new Clients()
                    {
                        name = NameBox.Text,
                        address = AddressBox.Text,
                        phone = PhoneBox.Text,
                        Tarif = TarifBox.Text
                    };
                    entitiess.Clients.Add(clients);
                    entitiess.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "No varible value", MessageBoxButton.OK, MessageBoxImage.Error);
                } 
                finally
                {
                    this.Close();
                    mv.Updater();
                }
            }
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
