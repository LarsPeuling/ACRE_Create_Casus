using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ACRE_Create_Casus.DAL;

namespace ACRE_Create_Casus.Models
{
    public class Guest
    {
        public int Id { get; set; }
        public string Role { get; set; }

        public Guest(string role)
        {
            Role = role;
        }


       

    }
}
