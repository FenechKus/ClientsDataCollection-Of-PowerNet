using ClientsDataCollection.DataBases;
using ClientsDataCollection.Infrastructur;
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
    /// Логика взаимодействия для Edit.xaml
    /// </summary>
    public partial class Edit : Window
    {
        MainWindow mv = new MainWindow();
        Update update = new Update();
        public Edit()
        {
            InitializeComponent();
        }

        private void ApplyClick(object sender, RoutedEventArgs e)
        {
            try
            {
                using (PowerNetEntitiess entitiess = new PowerNetEntitiess())
                {
                    var row = entitiess.Clients.ToList();

                    foreach (var client in row)
                    {
                        if (client.id == int.Parse(IdBox.Text))
                        {
                            client.name = NameBox.Text;
                            client.address = AddressBox.Text;
                            client.phone = PhoneBox.Text;
                            client.Tarif = TarifBox.Text;
                        }
                        mv.DataContext = update.Clients;
                        entitiess.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Save Data Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void RemoveClick(object sender, RoutedEventArgs e)
        {
            try
            {
                using (PowerNetEntitiess entities = new PowerNetEntitiess())
                {
                    var row = entities.Clients.ToList();

                    foreach (var item in row)
                    {
                        if (item.id == int.Parse(IdBox.Text))
                        {


                            entities.Clients.Remove(item);
                            entities.SaveChanges();
                            return;

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Remove Data Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void CancelClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
