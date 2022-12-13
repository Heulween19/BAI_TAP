using System;
using System.Collections.Generic;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Manage_User.Models;

namespace Manage_User.Models
{
    public class Class1
    {
        DbUserContext oai = new DbUserContext();
        public IEnumerable<DbUser> LayDS()
        {
            return oai.DbUsers.ToList();
        }

        public DbUser Lays (int id)
        {
            return oai.DbUsers.First(x => x.Id.CompareTo(id) == 0);
        }

        public void Them(DbUser n)
        {
            oai.DbUsers.Add(n);
            oai.SaveChanges();
        }

        public void Sua(DbUser n)
        {
            DbUser x = Lays(n.Id);
            x.UserName = n.UserName;
            x.Password = n.Password;
            x.BirthDay = n.BirthDay;
            x.Address = n.Address;
            x.Email = n.Email;
            x.Gender = n.Gender;
            oai.SaveChanges();
        }

        public void Xoa(int id)
        {
            DbUser n = Lays(id);
            oai.DbUsers.Remove(n);
            oai.SaveChanges();
        }

        


    }
}
