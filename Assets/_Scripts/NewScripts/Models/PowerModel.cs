using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerModel
{
    
        public float addedFuel { get; private  set;}
        public float addedFuelGain { get; private set; }
        public float addedFuelBurnRate { get; private set; }
        public float addedSpeed { get; private set; }
        public float addedScaleMultiplier { get; private set; }
     
        public  string description { get; private set; }

      public  PowerModel(float addedFuel, float addedSpeed,float addedFuelGain,float addedFuelBurn, float addedScaleMultiplier, string description)
        {
            this.addedFuel = addedFuel;
            this.addedFuelGain = addedFuelGain;
            this.addedFuelBurnRate = addedFuelBurn;
            this.addedSpeed = addedSpeed;
            this.addedScaleMultiplier = addedScaleMultiplier;
            this.description = description;
        }
        
    
  
}

