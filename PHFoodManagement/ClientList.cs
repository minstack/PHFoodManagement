using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHFoodManagement
{
    public class ClientList
    {
        public List<Client> Clients { get; set; }
        private List<Client> _originalClients;

        public ClientList ()
        {
            Clients = new List<Client>();
        }

        public void GetClientsFromDB(PHFoodDB db)
        {
            Clients = db.GetClients();
            _originalClients = Clients.ToList();
        }

        public void SaveNewClients(PHFoodDB db)
        {
            db.AddNewClients(Clients);
        }
    }
}
