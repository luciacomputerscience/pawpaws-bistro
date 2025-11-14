using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnionRings : Foods
{
    public OnionRings(Foods food)
        : base(food.fName, food.allergen, food.cookTime)

    {
        fName = "Onion Rings";
        allergen = "N/A";
        cookTime = 8f;
    }
}
