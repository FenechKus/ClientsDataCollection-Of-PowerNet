using ClientsDataCollection.DataBases;
using ClientsDataCollection.Infrastructur;
using ClientsDataCollection.Views;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ClientsDataCollection
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Update update = new Update();
        public MainWindow()
        {
            InitializeComponent();
            Updater();
            InitializeCombobox();
        }

        private void InitializeCombobox()
        {
            foreach (var item in GridV.Columns.ToList())
            {
                if (item.Header != null)
                {
                    ComboSelect.Items.Add(item.Header);
                }
            }
        }

        public void Updater()
        {
            using(PowerNetEntitiess entities = new PowerNetEntitiess()) 
            {
                var clients = entities.Clients.ToList();
                update.Clients = clients;
                ComboSelect.SelectedIndex = 0;
            }
            DataContext = null;
            DataContext = update;
        }

        private void EditButton(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Edit edit = new Edit();
            edit.DataContext = button.DataContext;
            edit.ShowDialog();
            Updater();
        }

        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<Clients> clients = new List<Clients>();
            using(PowerNetEntitiess entitie = new PowerNetEntitiess())
            {

                switch (ComboSelect.SelectedIndex)
                {
                    case 0:
                        clients = entitie.Clients.ToList();
                        clients.Sort((p, q) => p.id.CompareTo(q.id));
                        update.Clients = clients;
                        break;

                    case 1:
                        clients = entitie.Clients.ToList();
                        clients.Sort((p, q) => p.name.CompareTo(q.name));
                        update.Clients = clients;
                        break;

                    case 2:
                        clients = entitie.Clients.ToList();
                        clients.Sort((p, q) => p.address.CompareTo(q.address));
                        update.Clients = clients;
                        break;

                    case 3:
                        clients = entitie.Clients.ToList();
                        clients.Sort((p, q) => p.phone.CompareTo(q.phone));
                        update.Clients = clients;
                        break;
                    case 4:
                        clients = entitie.Clients.ToList();
                        clients.Sort((p, q) => p.Tarif.CompareTo(q.Tarif));
                        update.Clients = clients;
                        break;
                   
                }

            }
        }

        private void Search(object sender, TextChangedEventArgs e)
        {
           TextBox seararchBox = (TextBox)sender;
            using (PowerNetEntitiess entitie = new PowerNetEntitiess())
            {
                var request = entitie.Clients.Where(p => p.name.Contains(seararchBox.Text)).ToList();
                if (seararchBox.Text != "")
                {
                    if (request != null)
                    {
                        update.Clients = request;
                    }
                }
                else
                {
                    update.Clients = entitie.Clients.ToList();
                }
            }
        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            Add add = new Add();
            add.ShowDialog();
            Updater();
        }
    }
}