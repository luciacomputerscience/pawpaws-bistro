using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fries : Foods
{
    public Fries(Foods food)
        : base(food.fName, food.allergen, food.cookTime)

    {
        fName = "Fries";
        allergen = "N/A";
        cookTime = 8f;
    }

   
}
