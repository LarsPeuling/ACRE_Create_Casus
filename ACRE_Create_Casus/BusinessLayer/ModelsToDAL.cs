using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACRE_Create_Casus.Models;
using ACRE_Create_Casus.DAL;

namespace ACRE_Create_Casus.BusinessLayer
{
    public class ModelsToDAL
    {
        DataAccesLayer dal = new DataAccesLayer();

        public async Task<List<string>> ConnToDal()
        {
            return await DataAccesLayer.ConnectToDB(); // Await the task and return the result
        }
        //Animal
        //Create animal
        public Animal CreateAnimal(int id, string name, string location, string photo)
        {
            Animal a = new Animal(id, name, location, photo);
            return dal.CreateAnimal(a);
        }

        //Update animal
        public void UpdateAnimal(Animal animal)
        {
            dal.UpdateAnimal(animal);
        }

        //Delete animal
        public void DeleteAnimal(int animalId)
        {
            dal.DeleteAnimal(animalId);
        }


        //Observation
        //Create observation
        public Observation CreateObservation(DateTime date, int userId, bool isAnimal, string description)
        {
            Observation observation = new Observation(date, userId, isAnimal, description);
            return dal.CreateObservation(observation);
        }

        //Update observation
        public void UpdateObservation(Observation observation)
        {
            dal.UpdateObservation(observation);
        }

        //Aprove Observation
        public void ApproveObservation(int observationId)
        {
            dal.ApproveObservation(observationId);
        }

        //Delete observation
        public void DeleteObservation(int observationId)
        {
            dal.DeleteObservation(observationId);
        }

        //Plant
        //Create plant
        public Plant CreatePlant(int id, string name, string location, string photo)
        {
            return new Plant(id, name, location, photo);
        }

        //Update plant
        public void UpdatePlant(Plant plant)
        {
            dal.UpdatePlant(plant);
        }

        //Delete plant
        public void DeletePlant(int plantId)
        {
            dal.DeletePlant(plantId);
        }

    }
}
