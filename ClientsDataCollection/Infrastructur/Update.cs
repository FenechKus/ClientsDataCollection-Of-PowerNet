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

        public List<Clients> Clients { get => clients; set { clients = value; NotifyPropertyChange("Clients"); } }
    }
}
