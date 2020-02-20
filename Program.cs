using System;
using DinosaurTracker;

namespace JurassicPark
{
  class Program
  {
    static void Main(string[] args)
    {
      // Welcome user, setup variable for the tracker/dinosaur list, setup play again/add another loop with option to quit . . .
      Console.WriteLine("Welcome to Jurassic Park!");
      // tracker represents a new instance of an object. 
      var tracker = new DinosaurDB();
      // while loop for allowing user to quit app
      var isRunning = true;
      while (isRunning)
      {
        // ask user for input
        Console.WriteLine("What would you like to do?");
        Console.WriteLine("(ADD), (VIEW), (REMOVE), (TRANSFER) to new pen, or (QUIT)");
        var input = Console.ReadLine().ToLower();
        // Outcomes of user input
        // If add, we want to ask what type of dinosaur they want to add, create a variable that is equal to their response, and then we'll set that variable equal to it's equivalent variable in the dinosaur card. Repeat for each field
        if (input == "add")
        {
          Console.WriteLine("What type of Dinosaur do you want to add?");
          var what = Console.ReadLine().ToLower();
          Console.WriteLine("What is the diet type? (HERBIVORE) or (CARNIVORE)");
          var diet = Console.ReadLine().ToLower();
          // user input verification
          if (diet != "carnivore" && diet != "herbivore")
          {
            Console.WriteLine("That is not a valid choice, chose again from herbivore or carnivore.");
            diet = Console.ReadLine().ToLower();
          }
          Console.WriteLine("What is the weight in pounds?");
          // you need to parse response into an integer to make sure it's computable as a number instead of being a string.
          var weight = int.Parse(Console.ReadLine());
          Console.WriteLine("What pen number is the dinosaur in?");
          // you need to parse response into an integer to make sure it's computable as a number instead of being a string.
          var pen = int.Parse(Console.ReadLine());

          tracker.AddANewDinosaur(what, diet, weight, pen);
          Console.Clear();


        }
        else if (input == "view")
        {
          Console.WriteLine("Would you like to view: (ALL), (THREE) Heaviest, (DIET) Summary");
          var viewInput = Console.ReadLine().ToLower();
          // if user wants to see all, arrange by date acquired and display all
          if (viewInput == "all")
          {


            foreach (var d in tracker.Dinosaurs)
            {
              Console.WriteLine($"Acquired on: {d.DateAcquired}. {d.Dino}, is a {d.DietType}, weighs {d.Weight}lbs, and is in Enclosure #{d.Pen}.");
            }


          }
          // view heaviest three dinosaurs in the list of dinosaurs
          else if (viewInput == "three")

          {
            tracker.DisplayHeavy3();
          }
          // view diet summaries
          else if (viewInput == "diet")
          {
            tracker.DisplayDietType();
          }
        }
        else if (input == "remove")
        {
          Console.WriteLine("Current Dinosaurs are:");
          foreach (var d in tracker.Dinosaurs)
          {

            Console.WriteLine($"Acquired: {d.DateAcquired}. {d.Dino}, is a {d.DietType}, weighs {d.Weight}lbs, and is in Enclosure #{d.Pen}.");
          }
          Console.WriteLine("what do you want remove");
          var dinosaurR = Console.ReadLine();
          tracker.RemoveDinosaur(dinosaurR);

        }
        // setup tranfer
        else if (input == "transfer")
        {
          Console.Clear();
          Console.WriteLine("Current Dinosaurs are:");
          foreach (var d in tracker.Dinosaurs)
          {

            Console.WriteLine($"Acquired: {d.DateAcquired}. {d.Dino}, is a {d.DietType}, weighs {d.Weight}lbs, and is in Enclosure #{d.Pen}.");
          }

          Console.WriteLine("Which dinosaur do you want transfer?");
          var dinosaurT = (Console.ReadLine());
          tracker.TransferDinosaur(dinosaurT);

        }
        if (input == "quit")
        {
          isRunning = false;
        }
      }
    }
  }
}
