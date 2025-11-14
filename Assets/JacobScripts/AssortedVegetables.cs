using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssortedVegetables : Foods
{
    public AssortedVegetables(Foods food)
        : base(food.fName, food.allergen, food.cookTime)
    {
        fName = "Assorted Vegetables";
        allergen = "N/A";
        cookTime = 7f;
    }
}
