using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steak : Foods
{
    public Steak(Foods food)
        : base(food.fName, food.allergen, food.cookTime)

    {
        fName = "Steak";
        allergen = "Beef";
        cookTime = 25f;
    }
}
