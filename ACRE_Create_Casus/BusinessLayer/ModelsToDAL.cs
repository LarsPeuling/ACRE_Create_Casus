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

        public int GetAnimalId(Animal a)
        {
            return dal.GetAnimalId(a);
        }

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
        public void CreateObservation(Observation o)
        {
            dal.CreateObservation(o);
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
        public int GetPlantId(Plant p)
        {
            return dal.GetPlantId(p);
        }

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

        public void CreateModerator(string email, string name)
        {
            dal.CreateModerator(email, name);
        }

        public bool DoesModeratorExist(string mId)
        {
            return dal.DoesModeratorExist(mId);
        }

        public List<Observation> GetObservation()
        {
            return dal.GetObservation();
        }

    }
}
