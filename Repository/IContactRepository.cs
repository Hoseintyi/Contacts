using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Contacts.Repository
{
    interface IContactRepository
    {
        bool Insert(string name, string family, string mobile , string staticPhone , string email);

        bool Update(int contactId,string name, string family, string mobile, string staticPhone, string email);

        bool Delete(int contactId);

        DataTable SelectAll();

        DataTable SelectContactById(int contactId);

        DataTable Search(string parameter);


    }
}
