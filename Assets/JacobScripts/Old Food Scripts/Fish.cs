using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : Foods 
{ 
    public Fish(Foods food)
         : base(food.fName, food.allergen, food.cookTime)
    {
        fName = "Fish";
        allergen = "Fish";
        cookTime = 10f;
    }
}
