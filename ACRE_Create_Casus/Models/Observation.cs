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
        public int UserId { get; set; }
        public bool IsAnimal { get; set; }
        public string Description { get; set; }
        public bool IsApproved { get; set; } = false;

        public Observation(int id, DateTime date, int userId, bool isAnimal, string description, bool isApproved)
        {
            Id = id;
            Date = date;
            UserId = userId;
            IsAnimal = isAnimal;
            Description = description;
            IsApproved = isApproved;
        }

        //Used for creating a new observation
        public Observation(DateTime date, int userId, bool isAnimal, string description)
        {
            Date = date;
            UserId = userId;
            IsAnimal = isAnimal;
            Description = description;
        }
    }
}
