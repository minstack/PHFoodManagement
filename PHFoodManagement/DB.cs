using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHFoodManagement
{
    public class DB
    {
        protected SqlConnection _conn = new SqlConnection();
        private string _connString = Properties.Settings.Default.ConnectionString;


        public DB()
        {
            _conn.ConnectionString = _connString;
        }

        protected void OpenConnection()
        {
            if (_conn != null && _conn.State != ConnectionState.Open)
            {
                _conn.ConnectionString = _connString;
                _conn.Open();
            }
        }

    }
}
