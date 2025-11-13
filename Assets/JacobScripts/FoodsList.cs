using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodsList : MonoBehaviour
{
    public List<Foods> foodsList { get; set; }
    public BeefBurger beef;
    public ChickenBurger chicken;
    public Fries fries;
    public Calamari calamari;
    public OnionRings onionRings;
    // Start is called before the first frame update
    void Start()
    {
        Foods food = new Foods();
        beef = new BeefBurger(food);
        chicken = new ChickenBurger(food);
        fries = new Fries(food);
        onionRings = new OnionRings(food);
        calamari = new Calamari(food);
        foodsList = new List<Foods>();

        foodsList.Add(beef);
        foodsList.Add(chicken);
        foodsList.Add(fries);
        foodsList.Add(onionRings);
        foodsList.Add(calamari);

    }

    
}
