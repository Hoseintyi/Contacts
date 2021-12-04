using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Contacts.Repository;
using System.Data.SqlClient;

namespace Contacts.Services
{
  public  class ContactRepository:IContactRepository
    {
        private string myconnection = "DataSource=.; Initial Catalog= CotactWindowsFormApplication_DB; Integrated Security= true";
        public bool Insert(string name, string family, string mobile, string staticPhone, string email)
        {
            throw new NotImplementedException();
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
            SqlConnection connection = new SqlConnection(myconnection);
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
