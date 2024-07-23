using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Threading;

namespace ProblematicProblem
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Random rng = new Random();
            bool cont = false;
            List<string> activities = new List<string>()
            {
                "Movies", "Paintball", "Bowling", "Lazer Tag", "LAN Party", "Hiking", "Axe Throwing", "Wine Tasting"
            };

            Console.Write(
                "Hello, welcome to the random activity generator! \nWould you like to generate a random activity? yes/no: ");
            var contInput = Console.ReadLine()?.ToLower();
            if (contInput != "yes" && contInput != "no")
            {
                Console.WriteLine("Invalid input. Terminating...");
                return;
            }
            if (contInput == "no")
            {
                Console.WriteLine("Come back and see us soon!");
                return;
            }
            cont = true;
            Console.WriteLine();
            Console.Write("We are going to need your information first! What is your name? ");
            string userName = Console.ReadLine();
            Console.WriteLine($"Hello, {userName}");
            Console.Write("What is your age? ");
            var isUserAge = int.TryParse(Console.ReadLine(), out int age);
            if (!isUserAge)
            {
                Console.WriteLine("Invalid Age. Terminating...");
                return;
            }
            Console.WriteLine($"Thanks for letting us know that you are {age} years old");
            Console.Write("Would you like to see the current list of activities? Sure/No thanks: ");
            var seeListSelection = Console.ReadLine()?.ToLower();
            if (seeListSelection != "sure" && seeListSelection != "no thanks")
            {
                Console.WriteLine("Invalid input. Terminating...");
                return;
            }

            var seeList = seeListSelection.ToLower() == "sure";
            
            if (seeList)
            {
                foreach (string activity in activities)
                {
                    Console.Write($"{activity} ");
                    Thread.Sleep(250);
                }
                Console.WriteLine();
                Console.Write("Would you like to add any activities before we generate one? yes/no: ");
                var addActivityInput = Console.ReadLine()?.ToLower();
                if (addActivityInput != "yes" && addActivityInput != "no")
                {
                    Console.WriteLine("Invalid input. Terminating...");
                    return;
                }

                var addToList = addActivityInput.ToLower() == "yes";
                Console.WriteLine();
                
                while (addToList)
                {
                    Console.Write("What would you like to add? ");
                    string userAddition = Console.ReadLine();
                    activities.Add(userAddition);
                    foreach (string activity in activities)
                    {
                        Console.Write($"{activity} ");
                        Thread.Sleep(250);
                    }
                    Console.WriteLine();
                    Console.WriteLine("Would you like to add more? yes/no: ");
                    var addToListInput = Console.ReadLine()?.ToLower();
                    if (addToListInput != "yes" && addToListInput != "no")
                    {
                        Console.WriteLine("Invalid input. Terminating...");
                        return;
                    }

                    if (addToListInput.ToLower() == "no")
                    {
                        addToList = false;
                    }
                }
            } 
            while (cont)
            {
                Console.Write("Connecting to the database");
                for (int i = 0; i < 10; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);
                }

                Console.WriteLine();
                Console.Write("Choosing your random activity");
                for (int i = 0; i < 9; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);
                }

                Console.WriteLine();
                int randomNumber = rng.Next(activities.Count);
                string randomActivity = activities[randomNumber];
                if (age < 21 && randomActivity == "Wine Tasting")
                {
                    Console.WriteLine($"Oh no! Looks like you are too young to do {randomActivity}");
                    Console.WriteLine("Pick something else!");
                    activities.Remove(randomActivity);
                    randomNumber = rng.Next(activities.Count);
                    randomActivity = activities[randomNumber];
                }

                Console.Write(
                    $"Ah got it! {userName}, your random activity is: {randomActivity}! Is this ok or do you want to grab another activity? Keep/Redo: ");
                Console.WriteLine();
                var grabAnswer = Console.ReadLine()?.ToLower();
                if (grabAnswer != "keep" &&  grabAnswer != "redo")
                {
                    Console.WriteLine("Invalid input. Terminating");
                    return;
                }

                if (grabAnswer.ToLower() == "keep")
                {
                    Console.WriteLine("Enjoy your activity. We hope to see you again soon!");
                    cont = false;
                }
            }
        }       
    }
}