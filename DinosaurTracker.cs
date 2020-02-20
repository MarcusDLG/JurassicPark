using System;
using System.Collections.Generic;
using System.Linq;
using JurassicPark;

namespace DinosaurTracker
{
  public class DinosaurDB
  {
    public List<Dinosaur> Dinosaurs { get; set; } = new List<Dinosaur>();


    public void AddANewDinosaur(string what, string diet, int weight, int pen)
    {
      var dinoAdd = new Dinosaur
      {
        Dino = what,
        DietType = diet,
        DateAcquired = DateTime.Now,
        Weight = weight,
        Pen = pen
      };

      Dinosaurs.Add(dinoAdd);
    }
    public void RemoveDinosaur(string what)
    {
      // Sightings.RemoveAll(sighting => sighting.WhatISaw == what);

      var thingToRemove = Dinosaurs.Where(Dinosaurs => Dinosaurs.Dino == what).ToList();
      if (thingToRemove.Count() > 1)
      {
        Console.WriteLine($"We found multiple {what}, which do you want to remove");
        for (int i = 0; i < thingToRemove.Count; i++)
        {
          var creature = thingToRemove[i];
          Console.WriteLine($"{i + 1}: {creature.Dino} at pen number: {creature.Pen}");
        }

        var index = int.Parse(Console.ReadLine());
        Dinosaurs.Remove(thingToRemove[index - 1]);

      }
      else
      {
        // remove the only instance found
        Dinosaurs.Remove(thingToRemove.First());
      }


    }

    public void DisplayHeavy3()
    {
      var heavyDino = (Dinosaurs.OrderByDescending(displayHeavy3 => displayHeavy3.Weight).Take(3));
      foreach (var dino in heavyDino)
      {
        Console.WriteLine($"The {dino.Dino} weighs {dino.Weight} ");
      }


    }
    public void TransferDinosaur(string name)
    {
      // var moveIndex = Dinosaurs.IndexOf(Dinosaurs.First(name => Dinosaurs.Contains(name)));
      Console.WriteLine($"Please enter an enclosure number");
      var newPen = int.Parse(Console.ReadLine());
      Dinosaurs.First(name => Dinosaurs.Contains(name)).Pen = newPen;

    }

    public void DisplayDietType()
    {
      var herbivore = Dinosaurs.Count(displayDietH => displayDietH.DietType == "herbivore");
      var carnivore = Dinosaurs.Count(displayDietC => displayDietC.DietType == "carnivore");
      Console.WriteLine($"There are {herbivore} herbivore(s) and {carnivore} carnivore(s).");

    }
  }
}