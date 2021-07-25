using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace myContact.Repository
{
    interface IcontanctsRepository
    {
        DataTable SelectAll();
        DataTable SelectRow(int contactId);
        bool Insert(string name, string family, string mobile,string email, int age, string address);
        bool Update(int contact, string name, string family, string mobile, string email, int age, string address);
        bool Delet(int contact);
    }
}
