using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Contacts.Repository;
using System.Data.SqlClient;

namespace Contacts.Services
{
    public class ContactRepository : IContactRepository
    {
        private string mysqlconn = "Data Source=.;Initial Catalog=CotactWindowsFormApplication_DB;Integrated Security=True;MultipleActiveResultSets=true";
        public bool Insert(string name, string family, string mobile, string staticPhone, string email)
        {
            SqlConnection connection = new SqlConnection(mysqlconn);
            try
            {

                string query =
                    "Insert Into contactInfo (name,family,mobile,staticPhone,email) values (@name,@family,@mobile,@staticPhone,@email)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@family", family);
                command.Parameters.AddWithValue("@mobile", mobile);
                command.Parameters.AddWithValue("@staticPhone", staticPhone);
                command.Parameters.AddWithValue("@email", email);
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

        public bool Update(int contactId, string name, string family, string mobile, string staticPhone, string email)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int contactId)
        {
            throw new NotImplementedException();
        }

        public DataTable SelectAll()
        {
            string query = "Select * From contactInfo";
            SqlConnection connection = new SqlConnection(mysqlconn);
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public DataTable SelectContactById(int contactId)
        {
            throw new NotImplementedException();
        }
    }
}
