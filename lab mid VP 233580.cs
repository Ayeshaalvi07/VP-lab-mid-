using System;
namespace studentClub
{

    public class studentClub
    {
        private double Budget { get; set; }
        private string president { get; set; }
        private string vicePresident { get; set; }
        private string generalSectory { get; set; }
        private string financsSectory { get; set; }

        private string fundsociety { get; set; }








        public studentClub(string Budget, string president, string vicePresident, string generalSectory, string financsSectory, string fundSociety)
        {

            Budget = Budget;

            president = president;

            vicePresident = vicePresident;


            generalSectory = generalSectory;

            financsSectory = financsSectory;

            fundSociety = fundSociety;



        }
        public void fundSociety()
        {
            int size;
            Console.Write("enter fund society");
            Console.Write(Convert.ToInt32(Console.ReadLine()));



        }




        public void dispenseFunds()
        {

        }

        public void registerSociety()
        {

        }
        public void displaySociety()
        {


        }
    };
    public class Society : studentClub
    {
        private string name { get; set; }
        private string concat { get; set; }


        public void addActivity()
        {

        }

        public void listEvents()
        {

        }

        public class fundSociety : Society
        {
            private double fundingAmount { get; set; }





        }



    };
    public class NonFundSociety : Society
    {

    }

    class ClubRole : studentClub
    {
        private string name { set; get; }
        private string role { set; get; }

        private string contactInfo { set; get; }
    };



    class Program
    {
        static void Main(string[] args)
        {
            List<Society> societies = new List<Society>();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n--- Student Club Management System ---");
                Console.WriteLine("1. Register a new society");
                Console.WriteLine("2. Allocate funding to a society");
                Console.WriteLine("3. Register an event for a society");
                Console.WriteLine("4. Display society funding information");
                Console.WriteLine("5. Display events for a society");
                Console.WriteLine("6. Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":

                        Console.Write("Enter society name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter contact information: ");
                        string contact = Console.ReadLine();
                        Console.Write("Is it a funded society? (yes/no): ");
                        string isFunded = Console.ReadLine().ToLower();

                        if (isFunded == "yes")
                        {
                            Console.Write("Enter initial funding amount: ");
                            decimal fundingAmount = decimal.Parse(Console.ReadLine());
                            Console.Write("Enter budget: ");
                            decimal budget = decimal.Parse(Console.ReadLine());

                            StudentClub newClub = new StudentClub(name, contact, fundingAmount, budget);
                            societies.Add(newClub);
                            newClub.RegisterSociety();
                        }
                        else
                        {
                            NonFundedSociety newNonFundedClub = new NonFundedSociety(name, contact);
                            societies.Add(newNonFundedClub);
                            newNonFundedClub.RegisterSociety();
                        }
                        break;

                    case "2":

                        Console.Write("Enter the name of the society to allocate funding: ");
                        string societyName = Console.ReadLine();
                        Society societyToFund = societies.Find(s => s.Name.Equals(societyName, StringComparison.OrdinalIgnoreCase));

                        if (societyToFund is FundedSociety fundedSociety)
                        {
                            Console.Write("Enter the amount to allocate: ");
                            decimal amount = decimal.Parse(Console.ReadLine());
                            fundedSociety.FundingAmount += amount;
                            Console.WriteLine($"Allocated {amount:C} to {fundedSociety.Name}. Total funding now: {fundedSociety.FundingAmount:C}.");
                        }
                        else
                        {
                            Console.WriteLine("Society not found or is not a funded society.");
                        }
                        break;

                    case "3":

                        Console.Write("Enter the name of the society to register an event: ");
                        string eventSocietyName = Console.ReadLine();
                        Society eventSociety = societies.Find(s => s.Name.Equals(eventSocietyName, StringComparison.OrdinalIgnoreCase));

                        if (eventSociety != null)
                        {
                            Console.Write("Enter the event name: ");
                            string eventName = Console.ReadLine();
                            eventSociety.Events.Add(eventName);
                            Console.WriteLine($"Event '{eventName}' registered for {eventSociety.Name}.");
                        }
                        else
                        {
                            Console.WriteLine("Society not found.");
                        }
                        break;

                    case "4":

                        Console.Write("Enter the name of the society to display funding information: ");
                        string fundingSocietyName = Console.ReadLine();
                        Society fundingSociety = societies.Find(s => s.Name.Equals(fundingSocietyName, StringComparison.OrdinalIgnoreCase));

                        if (fundingSociety is FundedSociety fundedSoc)
                        {
                            fundedSoc.DisplayFundingInfo();
                        }
                        else
                        {
                            Console.WriteLine("Society not found or is not a funded society.");
                        }
                        break;

                    case "5":

                        Console.Write("Enter the name of the society to display events: ");
                        string eventsSocietyName = Console.ReadLine();
                        Society eventsSociety = societies.Find(s => s.Name.Equals(eventsSocietyName, StringComparison.OrdinalIgnoreCase));

                        if (eventsSociety != null)
                        {
                            eventsSociety.ListEvents();
                        }
                        else
                        {
                            Console.WriteLine("Society not found.");
                        }
                        break;

                    case "6":

                        exit = true;
                        Console.WriteLine("Exiting the program. Goodbye!");
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

    }
}
