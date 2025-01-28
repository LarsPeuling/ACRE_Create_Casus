using ACRE_Create_Casus.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZstdSharp.Unsafe;

namespace ACRE_Create_Casus.DAL
{
    public class DataAccesLayer
    {
        public string conString = "Server=20.31.135.94;Port=3306;Database=acre_casus;AllowPublicKeyRetrieval=True;Uid=my_user;Pwd=my_password;";

        public DataAccesLayer()
        {
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            using var con = new MySqlConnection(conString);
        }

        public List<Guest> CreateGuests(Guest guest)
        {
            List<Guest> guestlist = new List<Guest>();
            using var con = new MySqlConnection(conString);
            con.Open();

            string insertQuery = @"insert into guest (role) values (@role);";

            using (var cmd = new MySqlCommand(insertQuery, con))
            {
                cmd.Parameters.AddWithValue("@role", guest.Role);
                cmd.ExecuteNonQuery();
            }
            Console.WriteLine("guest added");
            return guestlist;
        } 

        //Crud Animal
        public Animal GetAnimal(int id)
        {
            return new Animal(1, "Koe", "Weiland", "https://www.google.com");
        }

        public Animal CreateAnimal(Animal animal)
        {
            Console.WriteLine($"Animal Created:\n{animal.Id},\n{animal.Name},\n{animal.Location},\n{animal.Photo}");
            return animal;
        }

        public Animal UpdateAnimal(Animal animal)
        {
            Console.WriteLine($"Animal Updated:\n{animal.Id},\n{animal.Name},\n{animal.Location},\n{animal.Photo}");
            return animal;
        }

        public void DeleteAnimal(int id)
        {
            Console.WriteLine($"Animal Deleted with id:{id}");
        }

        //Crud Plant

        public Plant GetPlant(int id)
        {
            return new Plant(1, "Koe", "Weiland", "https://www.google.com");
        }

        public Plant CreatePlant(Plant plant)
        {
            Console.WriteLine($"Plant Created:\n{plant.Id},\n{plant.Name},\n{plant.Location},\n{plant.Photo}");
            return plant;
        }

        public Plant UpdatePlant(Plant plant)
        {
            Console.WriteLine($"Plant Updated:\n{plant.Id},\n{plant.Name},\n{plant.Location},\n{plant.Photo}");
            return plant;
        }

        public void DeletePlant(int id)
        {
            Console.WriteLine($"Plant Deleted with id:{id}");
        }


        //Crud Observation

        public Observation GetObservation(int id)
        {
            return new Observation(1, DateTime.Now,1, true, "Koe is ziek", false);
        }

        public Observation CreateObservation(Observation observation)
        {
            Console.WriteLine($"Observation Created:" +
                $"\nObservation Id:{observation.Id = 1}" +
                $"\nObservation Date and Time: {observation.Date}," +
                $"\nObservation User Id: {observation.UserId}," +
                $"\nObservation Is an Animal (T/F): {observation.IsAnimal}," +
                $"\nObservation Description: {observation.Description}, " +
                $"Observatoin is validated: false");
            return observation;
        }

        public Observation ApproveObservation(int observationId)
        {
            Observation observation = GetObservation(observationId);
            Console.WriteLine($"Observation is approved: {!observation.IsApproved}");
            return observation;
        }

        public Observation UpdateObservation(Observation observation)
        {
            Console.WriteLine($"Observation Updated:\n{observation.Id},\n{observation.Date},\n{observation.UserId},\n{observation.IsAnimal},\n{observation.Description}");
            return observation;
        }

        public void DeleteObservation(int id)
        {
            Console.WriteLine($"Observation Deleted with id:{id}");
        }
    }
}
