using ClientsDataCollection.DataBases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientsDataCollection.Infrastructur
{
    internal class Update : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChange(string info)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(info));
        }

        private List<Clients> clients = new List<Clients>();

        private List<Tarifs> tarifs = new List<Tarifs>();

        public List<Clients> Clients { get => clients; set => clients=value; }

        public List<Tarifs> Tarifs { get => tarifs; set => tarifs=value; }
    }
}
