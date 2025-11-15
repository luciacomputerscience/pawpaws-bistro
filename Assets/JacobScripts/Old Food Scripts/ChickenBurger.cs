using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenBurger : Foods
{
    public ChickenBurger(Foods food)
        : base(food.fName, food.allergen, food.cookTime)

    {
        fName = "Chicken Burger";
        allergen = "Chicken";
        cookTime = 12f;
    }
}
