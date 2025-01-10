using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ACRE_Create_Casus.DAL;

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


        //DataAccesLayer stuff
        DataAccesLayer dal = new DataAccesLayer();
        //Create observation
        public Observation CreateObservation(DateTime date, int userId, bool isAnimal, string description)
        {
            Observation observation = new Observation(date, userId, isAnimal, description);
            return dal.CreateObservation(observation);
        }

        //Create animal
        public Animal CreateAnimal(int id, string name, string location, string photo)
        {
            Animal a = new Animal(id, name, location, photo);
            return dal.CreateAnimal(a);
        }


        //Create plant
        public Plant CreatePlant(int id, string name, string location, string photo)
        {
            return new Plant(id, name, location, photo);
        }

    }
}
