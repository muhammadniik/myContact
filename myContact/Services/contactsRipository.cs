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
            SqlConnection connection = new SqlConnection(ConnectionString);
            try{
                string qurey = "delete from mycontact2 where contactId = @contactid";
                SqlCommand command = new SqlCommand(qurey, connection);
                command.Parameters.AddWithValue("@contactid", contact);
                connection.Open();
                command.ExecuteNonQuery();
                return true;

            }
            catch {
                return false;
            }
            finally
            {
                connection.Close();
            }
            
        }

        
        public bool Insert(string name, string family, string mobile, string email, int age, string address)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            try
            {
                
                string qury = "Insert into mycontact2 (name,family,email,age,mobil,Adderss) values (@name,@family,@email,@age,@mobil,@adress)";
                SqlCommand command = new SqlCommand(qury, connection);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@family", family);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@age", age);
                command.Parameters.AddWithValue("@mobil", mobile);
                command.Parameters.AddWithValue("@adress", address);
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
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
            string qury = "select * from mycontact2 where contactid =" + contactId;
            SqlConnection conection = new SqlConnection(ConnectionString);
            SqlDataAdapter adabtor = new SqlDataAdapter(qury, conection);
            DataTable data = new DataTable();
            adabtor.Fill(data);
            return data;
        }

        

        public bool Update(int contact, string name, string family, string mobile, string email, int age, string address)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            try
            {

                string qury = "update mycontact2 set  name = @name,family= @family,email= @email,age= @age,mobil= @mobil,Adderss= @adress where contactID = @contact";
                SqlCommand command = new SqlCommand(qury, connection);
                command.Parameters.AddWithValue("@contact", contact);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@family", family);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@age", age);
                command.Parameters.AddWithValue("@mobil", mobile);
                command.Parameters.AddWithValue("@adress", address);
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
