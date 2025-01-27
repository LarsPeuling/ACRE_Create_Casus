using ACRE_Create_Casus.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACRE_Create_Casus.DAL
{
    public class DataAccesLayer
    {
        public static async Task<List<string>> ConnectToDB()
        {
            var builder = new MySqlConnectionStringBuilder
            {
                Server = "57.153.168.38",
                Database = "my_database",
                UserID = "azureuser",
                Password = "Azureuser!!!",
                SslMode = MySqlSslMode.Disabled,
                ConnectionTimeout = 30 // Uncomment to set a timeout
            };

            var results = new List<string>(); // List to hold the results

            using (var conn = new MySqlConnection(builder.ConnectionString))
            {
                Console.WriteLine("Opening connection");
                await conn.OpenAsync();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM GEBRUIKER";
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {

                            results.Add(reader.GetString(0)); // Add the first column to the results
                            Console.WriteLine($"{results}");
                        }
                    }
                }
                Console.WriteLine("Closing connection");
            }

            return results; // Return the results
        }

        public static async Task ReadData()
        {
            var builder = new MySqlConnectionStringBuilder
            {
                Server = "57.153.168.38",
                Database = "my_database",
                UserID = "azureuser",
                Password = "Azureuser!!!",
                SslMode = MySqlSslMode.Required,
            };

            using (var conn = new MySqlConnection(builder.ConnectionString))
            {
                Console.WriteLine("Opening connection");
                await conn.OpenAsync();

                using (var command = conn.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM inventory;";

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            Console.WriteLine(string.Format(
                                "Reading from table=({0}, {1}, {2})",
                                reader.GetInt32(0),
                                reader.GetString(1),
                                reader.GetInt32(2)));
                        }
                    }
                }

                Console.WriteLine("Closing connection");
            }

            Console.WriteLine("Press RETURN to exit");
            Console.ReadLine();
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
