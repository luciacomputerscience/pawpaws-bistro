using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeefBurger : Foods
{
    public BeefBurger(Foods food)
        : base(food.fName, food.allergen, food.cookTime)

    {
        fName = "Beef Burger";
        allergen = "Beef";
        cookTime = 10f;
    }
}
