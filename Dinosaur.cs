using System;


namespace JurassicPark
{
  public class Dinosaur
  {
    // what
    public string Dino { get; set; }
    // Diet
    public string DietType { get; set; }
    // Weight
    public int Weight { get; set; }
    // Date
    public DateTime DateAcquired { get; set; }
    // Pen number
    public int Pen { get; set; }

  }
}




// // Name
//  DietType - This will be carnivore or herbivore
//  DateAcquired - This will be defaulted when the dinosaur is created
//  Weight - In pounds, how heavy the dinosaur is
//  EnclosureNumber - the Pen that the dinosaur is currently in, thing should be a number