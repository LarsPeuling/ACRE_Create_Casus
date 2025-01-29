using ACRE_Create_Casus.Models;
using ACRE_Create_Casus.BusinessLayer;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ACRE_Create_Casus
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            bool running = true;
            ModelsToDAL mtd = new ModelsToDAL();

            while (running)
            {
                /*Console.WriteLine("Give Guest Role: ");
                string role = Convert.ToString(Console.ReadLine());
                Guest g = new Guest(role);
                mtd.CreateGuest(g);*/

                Console.WriteLine("create observation:\n" +
                    "A small description of the observation (200 characters)\n" +
                    "Your guestId\n" +
                    "Is it a plant or an animal\n" +
                    "The path to a picture");

                string desc = Convert.ToString(Console.ReadLine());
                int gId = Convert.ToInt32(Console.ReadLine());
                string pOrA = Convert.ToString(Console.ReadLine()).ToLower();
                string pPath = Convert.ToString(Console.ReadLine());

                switch (pOrA) 
                {
                    case "plant":
                        Console.WriteLine("Plant name:");
                        string pName = Console.ReadLine();
                        Console.WriteLine("Plant location");
                        string pLocation = Console.ReadLine();
                        Console.WriteLine("photo path");
                        string pPhoto = Console.ReadLine();
                        Plant p = new Plant(pName,pLocation,pPhoto);
                        mtd.CreatePlant(p);
                        break;
                    case "animal":
                        Console.WriteLine("Animal name:");
                        string aName = Console.ReadLine();
                        Console.WriteLine("Plant location");
                        string aLocation = Console.ReadLine();
                        Console.WriteLine("photo path");
                        string aPhoto = Console.ReadLine();
                        Animal a = new Animal(aName, aLocation, aPhoto);
                        mtd.CreateAnimal(a);
                        break;
                }




                /* Console.WriteLine("Welcome to ACRE_CREATE_CASUS" +
                 "\nMade By: Team Herkansers" +
                 "\nPlease choose an option:" +
                 "\n1. Create an Observation;" +
                 "\n2. I am a Moderator" +
                 "\n3. Exit");

                 //User input
                 string input = Console.ReadLine();

                 switch (input)
                 {
                     case "1":
                         Console.WriteLine("Please state your role:");
                         string role = Console.ReadLine();
                         //ModelsToDAL modelsToDAL = new ModelsToDAL();
                         Console.WriteLine("Please enter the following of your Observation:" +
                             "\nYour UserId:" +
                             "\nIf it is an animal (True if it is an animal, False if it is not an animal):" +
                             "\nA small description of your Observation:");
                         int userId = Convert.ToInt32(Console.ReadLine());
                         bool isAnimal = Convert.ToBoolean(Console.ReadLine());
                         string description = Console.ReadLine();
                         Observation observation = mtd.CreateObservation(DateTime.Now, userId, isAnimal, description);
                         break;
                     case "2":
                         Console.WriteLine("Please enter your name:");
                         string name = Console.ReadLine();
                         Console.WriteLine("Please enter your email:");
                         string email = Console.ReadLine();
                         Moderator moderator = new Moderator(1, name, email);
                         Console.WriteLine("Choose an action to perform:" +
                             "\n1. Update Observation;" +
                             "\n2. Validate Observation" +
                             "\n3. Delete observation");
                         string action = Console.ReadLine();
                         switch (action)
                         {
                             case "1":
                                 Console.WriteLine("Please enter the following of the Observation to be updated:" +
                                     "\nObservation Id:" +
                                     "\nObservation UserId:" +
                                     "\nIf it is an animal (True if it is an animal, False if it is not an animal):" +
                                     "\nA small description of your Observation:");
                                 //ModelsToDAL mtd = new ModelsToDAL();
                                 int id = Convert.ToInt32(Console.ReadLine());
                                 DateTime date = DateTime.Now;
                                 int usrID = Convert.ToInt32(Console.ReadLine());
                                 bool b_isAnimal = Convert.ToBoolean(Console.ReadLine());
                                 string s_description = Console.ReadLine();
                                 Observation observation1 = new Observation(id, date, usrID, b_isAnimal, s_description, false);
                                 mtd.UpdateObservation(observation1);
                                 break;

                             case "2":
                                 Console.WriteLine("");
                                 Console.WriteLine("Please enter the following of the Observation you want to validate:" +
                                     "\nObservation Id:");
                                 int observationId = Convert.ToInt32(Console.ReadLine());
                                 //ModelsToDAL modelsToDAL2 = new ModelsToDAL();
                                 mtd.ApproveObservation(observationId);
                                 break;

                             case "3":
                                 Console.WriteLine("Please enter the following of the Observation you want to delete:" +
                                     "\nObservation Id:");
                                 int observationId1 = Convert.ToInt32(Console.ReadLine());
                                 //ModelsToDAL modelsToDAL1 = new ModelsToDAL();
                                 mtd.DeleteObservation(observationId1);
                                 break;

                         }
                     break;
                     case "3":
                         running = false;
                         break;
                     default:
                         Console.WriteLine("Invalid input");
                         return;
                 }

                 Console.WriteLine();*/


            }
        }
    }
}
