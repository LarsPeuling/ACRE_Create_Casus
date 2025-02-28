﻿using ACRE_Create_Casus.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography;
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

        //CUD Guest
        public List<Guest> CreateGuests(Guest guest)
        {
            List<Guest> guestlist = new List<Guest>();
            using var con = new MySqlConnection(conString);
            con.Open();

            string query = @"insert into guest (role) values (@role);";

            using (var cmd = new MySqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@role", guest.Role);
                cmd.ExecuteNonQuery();
            }
            Console.WriteLine("guest added");
            return guestlist;
        }

        public void UpdateGuest(Guest guest)
        {
            using var con = new MySqlConnection(conString);
            con.Open();

            string query = $"update guest set role = @role where id = {guest.Id}";

            using (var cmd = new MySqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@role", guest.Role);
                cmd.ExecuteNonQuery();
            }
            Console.WriteLine("Guest Updated");
        }
        public void DeleteGuest(int guestId)
        {
            using var con = new MySqlConnection(conString);
            con.Open();

            string query = @"delete from guest where id = @guestId";
            using (var cmd = new MySqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@guestId", guestId);
                cmd.ExecuteNonQuery();
            }
            Console.WriteLine("Guest Deleted");
        }

        //Crud Animal

        public int GetAnimalId(Animal a)
        {
            Animal animal = new Animal();
            using (MySqlConnection cnn = new MySqlConnection(conString))
            {
                cnn.Open();
                var query = "select * from animal where name = @name;";
                using (MySqlCommand cmd = new MySqlCommand(query, cnn))
                {
                    cmd.Parameters.AddWithValue("@name", a.Name);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            animal = new Animal
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")), // Pas aan op basis van je kolomnamen
                                Name = reader.GetString(reader.GetOrdinal("Name")),
                                Location = reader.GetString(reader.GetOrdinal("Location")),
                                Photo = reader.GetString(reader.GetOrdinal("Photo")),
                                // Voeg hier andere eigenschappen toe die je hebt in de Animal klasse
                            };
                        }
                    }
                }
                
            }
            return animal.Id;
        } 
        

        public List<Animal> GetAnimals()
        {
            var animals = new List<Animal>();
            Animal animal = new Animal();
            using (MySqlConnection cnn = new MySqlConnection(conString))
            {
                cnn.Open();
                var query = "SELECT * FROM animal"; // Zorg ervoor dat je de juiste tabelnaam gebruikt
                using (MySqlCommand cmd = new MySqlCommand(query, cnn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            animal = new Animal
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")), // Pas aan op basis van je kolomnamen
                                Name = reader.GetString(reader.GetOrdinal("Name")),
                                Location = reader.GetString(reader.GetOrdinal("Location")),
                                Photo = reader.GetString(reader.GetOrdinal("Age")),
                                // Voeg hier andere eigenschappen toe die je hebt in de Animal klasse
                            };
                            animals.Add(animal);
                        }
                    }
                }
            }
            return animals;
        }

        public void CreateAnimal(Animal animal) 
        {
            using var con = new MySqlConnection(conString);
            con.Open();

            string query = @"insert into animal (name, location, photo) values (@name, @location, @photo);";

            using (var cmd = new MySqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@name", animal.Name);
                cmd.Parameters.AddWithValue("@location", animal.Location);
                cmd.Parameters.AddWithValue("@photo", animal.Photo);
                cmd.ExecuteNonQuery();
            }
            Console.WriteLine("Animal added");
        }

        public void UpdateAnimal(Animal animal)
        {
            using var con = new MySqlConnection(conString);
            con.Open();

            string query = $"update animal set name = @name, location = @location, photo = @photo where id = {animal.Id};";

            using (var cmd = new MySqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@name", animal.Name);
                cmd.Parameters.AddWithValue("@location", animal.Location);
                cmd.Parameters.AddWithValue("@photo", animal.Photo);
                cmd.ExecuteNonQuery();
            }
            Console.WriteLine("Animal Updated");
        }

        public void DeleteAnimal(int animalId)
        {
            using var con = new MySqlConnection(conString);
            con.Open();

            string query = @"delete from animal where id = @animalId;";
            using (var cmd = new MySqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@animalId", animalId);
                cmd.ExecuteNonQuery();
            }
            Console.WriteLine("Animal Deleted");
        }


        //Crud Plant
        public int GetPlantId(Plant p)
        {
            Plant pl = new Plant();
            using (MySqlConnection cnn = new MySqlConnection(conString))
            {
                cnn.Open();
                var query = "select * from plant where name = @name;";
                using (MySqlCommand cmd = new MySqlCommand(query, cnn))
                {
                    cmd.Parameters.AddWithValue("@name", p.Name);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            pl = new Plant
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")), // Pas aan op basis van je kolomnamen
                                Name = reader.GetString(reader.GetOrdinal("Name")),
                                Location = reader.GetString(reader.GetOrdinal("Location")),
                                Photo = reader.GetString(reader.GetOrdinal("Photo")),
                                // Voeg hier andere eigenschappen toe die je hebt in de Animal klasse
                            };
                        }
                    }
                }

            }
            return pl.Id;
        }

        public List<Plant> GetPlant()
        {
            var plants = new List<Plant>();
            Plant plant = new Plant();
            using (MySqlConnection cnn = new MySqlConnection(conString))
            {
                cnn.Open();
                var query = "SELECT * FROM plant"; // Zorg ervoor dat je de juiste tabelnaam gebruikt
                using (MySqlCommand cmd = new MySqlCommand(query, cnn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            plant = new Plant
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")), // Pas aan op basis van je kolomnamen
                                Name = reader.GetString(reader.GetOrdinal("Name")),
                                Location = reader.GetString(reader.GetOrdinal("Species")),
                                Photo = reader.GetString(reader.GetOrdinal("Age")),
                                // Voeg hier andere eigenschappen toe die je hebt in de Animal klasse
                            };
                            plants.Add(plant);
                        }
                    }
                }
            }

            return plants;
        }

        public void CreatePlant(Plant plant)
        {
            using var con = new MySqlConnection(conString);
            con.Open();

            string query = @"insert into plant (name, location, photo) values (@name, @location, @photo);";

            using (var cmd = new MySqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@name", plant.Name);
                cmd.Parameters.AddWithValue("@location", plant.Location);
                cmd.Parameters.AddWithValue("@photo", plant.Photo);
                cmd.ExecuteNonQuery();
            }
            Console.WriteLine("Plant added");
        }

        public void UpdatePlant(Plant plant)
        {
            using var con = new MySqlConnection(conString);
            con.Open();

            string query = $"update plant set name = @name, location = @location, photo = @photo where id = {plant.Id};";

            using (var cmd = new MySqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@name", plant.Name);
                cmd.Parameters.AddWithValue("@location", plant.Location);
                cmd.Parameters.AddWithValue("@photo", plant.Photo);
                cmd.ExecuteNonQuery();
            }
            Console.WriteLine("Plant Updated");
        }

        public void DeletePlant(int plantId)
        {
            using var con = new MySqlConnection(conString);
            con.Open();

            string query = @"delete from plant where id = @plantId;";
            using (var cmd = new MySqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@plantId", plantId);
                cmd.ExecuteNonQuery();
            }
            Console.WriteLine("Plant Deleted");
        }




        //Crud Observation

        public List<Observation> GetObservation()
        {
            List<Observation> list = new List<Observation>();
            Observation o = new Observation();
            using var con = new MySqlConnection(conString);
            con.Open();

            string query = $"select * from observation";
            using (MySqlCommand cmd = new MySqlCommand(query, con)) 
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        o = new Observation
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Date = reader.GetDateTime(reader.GetOrdinal("date")),
                            Description = reader.GetString(reader.GetOrdinal("description")),
                            GuestId = reader.GetInt32(reader.GetOrdinal("guestId")),
                            PlantId = reader.GetInt32(reader.GetOrdinal("plantId")),
                            AnimalId = reader.GetInt32(reader.GetOrdinal("animalId")),
                            Picture = reader.GetString(reader.GetOrdinal("picture")),
                            IsApproved = reader.GetBoolean(reader.GetOrdinal("approved"))
                            
                        };
                        list.Add(o);
                    }
                    return list;
                }
            }
            
        }

        public void CreateObservation(Observation observation)
        {
            using var con = new MySqlConnection(conString);
            con.Open();

            string query = $"insert into observation " +
                $"(date, description, guestId, plantId, animalId, picture, approved) " +
                $"values (@date, @description, @guestId, @plantId, @animalId, @picture, @approved);";

            using (var cmd = new MySqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@date", observation.Date);
                cmd.Parameters.AddWithValue("@description", observation.Description);
                cmd.Parameters.AddWithValue("@guestId", observation.GuestId);
                cmd.Parameters.AddWithValue("@plantId", observation.PlantId);
                cmd.Parameters.AddWithValue("@animalId", observation.AnimalId);
                cmd.Parameters.AddWithValue("@picture", observation.Picture);
                cmd.Parameters.AddWithValue("@approved", observation.IsApproved);
                
                cmd.ExecuteNonQuery();
            }
            Console.WriteLine("Observation added");
        }

        public void UpdateObservation(Observation observation) 
        {
            using var con = new MySqlConnection(conString);
            con.Open();

            string query = $"update observation set date = @date, description = @description, guestId = @guestId, plantId = @plantId, picture = @picture, approved = @approved where id = {observation.Id};";
            using (var cmd = new MySqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@date", observation.Date);
                cmd.Parameters.AddWithValue("@description", observation.Description);
                cmd.Parameters.AddWithValue("@guestId", observation.GuestId);
                cmd.Parameters.AddWithValue("@plantId", observation.PlantId);
                cmd.Parameters.AddWithValue("@animalId", observation.AnimalId);
                cmd.Parameters.AddWithValue("@picture", observation.Picture);
                cmd.Parameters.AddWithValue("@approved", observation.IsApproved);

                cmd.ExecuteNonQuery();
            }
            Console.WriteLine("Observation updated");
        }


        public void ApproveObservation(int observationid)
        {
            using var con = new MySqlConnection(conString);
            con.Open();

            string query = $"update observation set approved = @approved where id = {observationid};";
            using (var cmd = new MySqlCommand(query, con))
            {

                cmd.Parameters.AddWithValue("@approved", 1);
                cmd.ExecuteNonQuery();
            }
            Console.WriteLine("Observation updated");
        }

        public void DeleteObservation (int observationId)
        {
            using var con = new MySqlConnection(conString);
            con.Open();

            string query = $"delete from observation where id = {observationId};";
            using (var cmd = new MySqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@id", observationId);
                cmd.ExecuteNonQuery();
            }
            Console.WriteLine("Observation Deleted");
        }

        public void CreateModerator(string email, string name)
        {
            using var con = new MySqlConnection(conString);
            con.Open();

            string query = $"insert into moderator (name, email) values (@name, @email);";
            using (var cmd = new MySqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@email", email);
                
                cmd.ExecuteNonQuery();
            }
            Console.WriteLine("Moderator added");
        }

        public bool DoesModeratorExist(string mId)
        {
            using var con = new MySqlConnection(conString);
            con.Open();

            string query = $"SELECT COUNT(*) FROM moderator WHERE name = @name;";
            using (var cmd = new MySqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@name", mId);
                int count = Convert.ToInt32(cmd.ExecuteScalar());

                // Return true if count is greater than 0, otherwise false

                return count > 0;
            }
        }
    }
}
