using ACRE_Create_Casus.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACRE_Create_Casus.Models
{
    public class Moderator : User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Moderator(int id, string name, string email) : base(role: "Moderator")
        {
            Id = id;
            Name = name;
            Email = email;
        }


        //DataAccesLayer stuff
        DataAccesLayer dal = new DataAccesLayer();

        public void UpdateObservation(Observation observation)
        {
            dal.UpdateObservation(observation);
        }

        public void DeleteObservation(int observationId)
        {
            dal.DeleteObservation(observationId);
        }

        public void ApproveObservation(int observationId)
        {
            dal.ApproveObservation(observationId);
        }
    }
}
