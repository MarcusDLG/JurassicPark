using System;
using DinosaurTracker;

namespace JurassicPark
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Welcome to Jurassic Park!");
      var tracker = new DinosaurDB();
      var isRunning = true;
      while (isRunning)
      {
        Console.WriteLine("What would you like to do?");
        Console.WriteLine("(ADD), (VIEW), (REMOVE), (TRANSFER) to new pen, or (QUIT)");
        var input = Console.ReadLine().ToLower();
        if (input == "add")
        {
          Console.WriteLine("What type of Dinosaur do you want to add?");
          var what = Console.ReadLine().ToLower();
          Console.WriteLine("What is the diet type? (HERBIVORE) or (CARNIVORE)");
          var diet = Console.ReadLine().ToLower();
          if (diet != "carnivore" && diet != "herbivore")
          {
            Console.WriteLine("That is not a valid choice, chose again from herbivore or carnivore.");
            diet = Console.ReadLine().ToLower();
          }
          Console.WriteLine("What is the weight in pounds?");
          var weight = int.Parse(Console.ReadLine());
          Console.WriteLine("What pen number is the dinosaur in?");
          var pen = int.Parse(Console.ReadLine());

          tracker.AddANewDinosaur(what, diet, weight, pen);
          Console.Clear();


        }
        else if (input == "view")
        {
          Console.WriteLine("Would you like to view: (ALL), (THREE) Heaviest, (DIET) Summary");
          var viewInput = Console.ReadLine().ToLower();
          if (viewInput == "all")
          {


            foreach (var d in tracker.Dinosaurs)
            {
              Console.WriteLine($"Acquired on: {d.DateAcquired}. {d.Dino}, is a {d.DietType}, weighs {d.Weight}lbs, and is in Enclosure #{d.Pen}.");
            }


          }
          else if (viewInput == "three")

          {
            tracker.DisplayHeavy3();
          }
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
