using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACRE_Create_Casus.Models
{
    public class Animal 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        //Photot is a string because it will be a link to the photopath
        public string Photo { get; set; }

        public Animal(int id, string name, string location, string photo)
        {
            Id = id;
            Name = name;
            Location = location;
            Photo = photo;
        }
    }
}
