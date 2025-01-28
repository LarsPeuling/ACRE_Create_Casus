using ACRE_Create_Casus.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACRE_Create_Casus.Models
{
    public class Moderator : Guest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Moderator(int id, string name, string email) : base(role: "Moderator")
        {
            Id = id;
            Name = name;
            Email = email;
        }


        
    }
}
