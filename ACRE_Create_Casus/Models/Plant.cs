﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACRE_Create_Casus.Models
{
    public class Plant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        //Photot is a string because it will be a link to the photopath
        public string Photo { get; set; }

        public Plant(int id, string name, string location, string photo)
        {
            Id = id;
            Name = name;
            Location = location;
            Photo = photo;
        }
        public Plant() { }
        public Plant(string name, string location, string photo)
        {
            Name = name;
            Location = location;
            Photo = photo;
        }
    }
}
