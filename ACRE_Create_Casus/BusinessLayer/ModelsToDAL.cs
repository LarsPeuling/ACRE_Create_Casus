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

        public List<Guest> CreateGuest(Guest guest)
        {
            List<Guest> guestList = new List<Guest>();
            guestList.Add(guest);
            foreach (var x in guestList)
            {
                dal.CreateGuests(x);
            }
            return guestList;
        }
        //Animal
        //Create animal
        public void CreateAnimal(Animal a)
        {
            dal.CreateAnimal(a);
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
        public void CreateObservation(DateTime date, string description, int guestId, int plantId, int animalId, string picture, bool isApproved)
        {
            Observation observation = new Observation(date,description, guestId, plantId, animalId, picture, isApproved);
            dal.CreateObservation(observation);
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
        public void CreatePlant(Plant plant)
        {
            dal.CreatePlant(plant);
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
