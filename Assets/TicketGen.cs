using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class TicketGen : MonoBehaviour
{
    public List<string> foodItems = new();
    public List<string> Necessities = new();
    public List<string> burgerProtein = new();
    public List<string> side = new();
    public List<string> burgerFixings = new();
    // Start is called before the first frame update
    void Start()
    {
        foodItems.Add("Beef");
        foodItems.Add("Chicken");
        foodItems.Add("Lettuce");
        foodItems.Add("Cheese");
        foodItems.Add("Tomatoes");
        foodItems.Add("Fish");
        foodItems.Add("Fries");
        foodItems.Add("Onion Rings");
        foodItems.Add("Top Bun");
        foodItems.Add("Bottom Bun");
        foodItems.Add("Calamari");
        Necessities.Add("Top Bun");
        Necessities.Add("Bottom Bun");
        burgerProtein.Add("Beef");
        burgerProtein.Add("Chicken");
        burgerProtein.Add("Fish");
        burgerFixings.Add("Lettuce");
        burgerFixings.Add("Cheese");
        burgerFixings.Add("Tomatoes");
        side.Add("Fries");
        side.Add("Onion Rings");
        side.Add("Calamari");
    }

    public List<string> GenerateOrder()
    {
        List<string> newOrder = new();
        int orderType = Random.Range(0,3);
        int ProteinNum = Random.Range(0, 3);
        if (orderType == 0)
        {
            // Burger
            string BurgerProt = burgerProtein[ProteinNum];
            newOrder.Add(Necessities[0]);
            newOrder.Add(burgerFixings[0]);
            newOrder.Add(burgerFixings[1]);
            newOrder.Add(BurgerProt);
            newOrder.Add(Necessities[1]);
        } else if (orderType == 1)
        {
            // Just the Protein
            string Prot = burgerProtein[ProteinNum];
            newOrder.Add(Prot);
        } else if (orderType == 2)
        {
            // Just sides

            int sideVal = Random.Range(0, 2);
            newOrder.Add(side[sideVal]);
        }
        if (orderType != 2)
        {
            int sideCheck = Random.Range(0, 2);
            if (sideCheck == 0)
            {
                // Add side
                int sideVal = Random.Range(0, 2);
                newOrder.Add(side[sideVal]);
            } 
        }
        return newOrder;
    }
}
