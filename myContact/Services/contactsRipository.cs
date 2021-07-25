using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using myContact.Repository;
using System.Data.SqlClient;

namespace myContact.Services
{
    class contactsRipository : IcontanctsRepository
    {
        private string ConnectionString = "Data Source=.;Initial Catalog=contact_DB;Integrated Security=true";
        public bool Delet(int contact)
        {
            throw new NotImplementedException();
        }

        
        public bool Insert(string name, string family, string mobile, string email, int age, string address)
        {
            throw new NotImplementedException();
        }

        public DataTable SelectAll()
        {
            string query = "Select * From mycontact2";
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public DataTable SelectRow(int contactId)
        {
            throw new NotImplementedException();
        }

        

        public bool Update(int contact, string name, string family, string mobile, string email, int age, string address)
        {
            throw new NotImplementedException();
        }
    }
}
