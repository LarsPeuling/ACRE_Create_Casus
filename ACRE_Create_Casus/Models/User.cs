﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACRE_Create_Casus.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Role { get; set; }

        public User(string role)
        {
            Role = role;
        }
    }
}
