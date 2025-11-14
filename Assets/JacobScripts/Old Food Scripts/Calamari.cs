using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calamari : Foods
{
    public Calamari(Foods food)
         : base(food.fName, food.allergen, food.cookTime)

    {
        fName = "Calamari";
        allergen = "Squid";
        cookTime = 9f;
    }
}
