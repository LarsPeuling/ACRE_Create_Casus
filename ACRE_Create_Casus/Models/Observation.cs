using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACRE_Create_Casus.Models
{
    public class Observation
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public int GuestId { get; set; }
        public int? PlantId {  get; set; }
        public int? AnimalId { get; set; }

        public string Picture { get; set; }
        
        public bool IsApproved { get; set; } = false;

        public Observation(int id, DateTime date, string description, int guestId, int plantId, int animalId, string picture, bool isApproved)
        {
            Id = id;
            Date = date;
            Description = description;
            GuestId = guestId;
            PlantId = plantId;
            AnimalId = animalId;
            Picture = picture;
            IsApproved = isApproved;
        }

        //Used for creating a new observation with plant
        public Observation(DateTime date, string description, int guestId, int? plantId, int? animalId, string picture, bool isApproved)
        {
            Date = date;
            Description = description;
            GuestId = guestId;
            PlantId = plantId;
            AnimalId = animalId;
            Picture = picture;
            IsApproved = isApproved;
        }

        public Observation() { }

    }
}
