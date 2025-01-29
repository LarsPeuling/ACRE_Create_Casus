using ACRE_Create_Casus.Models;
using ACRE_Create_Casus.BusinessLayer;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Cryptography.X509Certificates;

namespace ACRE_Create_Casus
{
    internal class Program
    {
        //public static string pPicture = Convert.ToString(Console.ReadLine());
        public static void Main(string[] args)
        {
            bool running = true;
            ModelsToDAL mtd = new ModelsToDAL();


            while (running)
            {
                Console.WriteLine("Give Guest Role: ");
                string role = Convert.ToString(Console.ReadLine());
                Guest g = new Guest(role);
                mtd.CreateGuest(g);


                Console.WriteLine("Welcome to ACRE_CREATE_CASUS" +
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
                        Console.WriteLine("create observation:\n" +
                            "A small description of the observation (200 characters)\n" +
                            "Your guestId\n" +
                            "Is it a plant or an animal\n");

                        string desc = Convert.ToString(Console.ReadLine());
                        int gId = Convert.ToInt32(Console.ReadLine());
                        string pOrA = Convert.ToString(Console.ReadLine()).ToLower();

                        int entityId = CreateEntity(pOrA); // the result will not be used, for the user must use the corresponding Id from either plant or animal, which is given to them in another console.writeline()
                        Console.WriteLine("animal Id:\n");
                        int aId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("plant Id:\n");
                        int pId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("The path to a picture");
                        string pPicture = Convert.ToString(Console.ReadLine());
                        Observation o = new Observation(DateTime.Now, desc, gId, aId, pId, pPicture, false);
                        mtd.CreateObservation(o);
                        break;
                     case "2":
                         Console.WriteLine("Please enter your name:");
                         string name = Console.ReadLine();
                         Console.WriteLine("Please enter your email:");
                         string email = Console.ReadLine();
                        if (mtd.DoesModeratorExist(name) == false)
                        {
                            mtd.CreateModerator(name, email);
                            Console.WriteLine("Choose an action to perform:" +
                             "\n1. Update Observation;" +
                             "\n2. Validate Observation" +
                             "\n3. Delete observation" +
                             "\n ");
                        }
                        else
                            
                            Console.WriteLine("Choose an action to perform:" +
                             "\n1. Update Observation;" +
                             "\n2. Validate Observation" +
                             "\n3. Delete observation" +
                             "\n ");
                        //Moderator moderator = new Moderator(1, name, email);
                         
                         string action = Console.ReadLine();
                         switch (action)
                         {
                             case "1":
                                List<Observation> list = mtd.GetObservation();
                                foreach( Observation ob in list)
                                {
                                    Console.WriteLine($"{Convert.ToString(ob.Id)},{ob.Date} {ob.Description}, {ob.GuestId}, {ob.PlantId}, {ob.AnimalId}, {ob.Picture}, {ob.IsApproved}");
                                }
                                Console.WriteLine("Please enter the following of the Observation to be updated:" +
                                     "\nObservation Id:" +
                                     "\nObservation Description:" +
                                     "\nAnimal Id: (If it is a plant, please enter 0)" +
                                     "\nPlant Id: (If it is a animal, please enter 0)" +
                                     "\nPicture Path:");
                                 //ModelsToDAL mtd = new ModelsToDAL();
                                 int id = Convert.ToInt32(Console.ReadLine());
                                 DateTime date = DateTime.Now;
                                 string s_description = Console.ReadLine();
                                int Gid = 1;
                                 int Aid = Convert.ToInt32(Console.ReadLine());
                                 int Pid = Convert.ToInt32(Console.ReadLine());
                                 string picture = Console.ReadLine();
                                 Observation observation1 = new Observation(id, date, s_description, Gid, Aid, Pid, picture, true);
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

                 Console.WriteLine();


            }
        }
        public static int CreateEntity(string pOrA)
        {
            ModelsToDAL mtd = new ModelsToDAL();
            switch (pOrA)
            {
                case "plant":
                    Console.WriteLine("Plant name:");
                    string pName = Console.ReadLine();
                    Console.WriteLine("Plant location:");
                    string pLocation = Console.ReadLine();
                    Console.WriteLine("Photo path:");
                    string pPhoto = Console.ReadLine();
                    Plant p = new Plant(pName, pLocation, pPhoto);
                    mtd.CreatePlant(p);
                    mtd.GetPlantId(p);
                    Console.WriteLine($"Vul bij Animal Id 0 in en bij plant Id {mtd.GetPlantId(p)}");
                    return p.Id; // Return the Id of the created plant

                case "animal":
                    Console.WriteLine("Animal name:");
                    string aName = Console.ReadLine();
                    Console.WriteLine("Animal location:");
                    string aLocation = Console.ReadLine();
                    Console.WriteLine("Photo path:");
                    string aPhoto = Console.ReadLine();
                    Animal a = new Animal(aName, aLocation, aPhoto);
                    mtd.CreateAnimal(a);
                    Console.WriteLine($"Vul bij Animal Id {mtd.GetAnimalId(a)} in en bij Plant Id 0");
                    return a.Id; // Return the Id of the created animal


                default:
                    throw new ArgumentException("Invalid type specified. Use 'plant' or 'animal'.");
            }
        }
        
    }
}
