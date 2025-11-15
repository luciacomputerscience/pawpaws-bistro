using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text;

public class BillCreatorText : MonoBehaviour
{
    public TextMeshProUGUI cookingListText;
    public List<Foods> foodsList { get; set; }
    public List<Foods> foodsToDisplay = new List<Foods>();
    public BeefBurger beef;
    public ChickenBurger chicken;
    public Fries fries;
    public Calamari calamari;
    public OnionRings onionRings;

    List<string> CoolNames = new List<string>() { "Merleap's Magical Mambo","Cook County Country Cooked","This Plate Is Big Enough For The Two Of Us", "Gaze Den, no wait i meant Gay-","Superstored & Frozen", "b- b- bill bill  b- b- bill", "There Is A Mouse In New Orleans","Unbearably Expensive","Totally Pawsome"};

    // A public method that other scripts (like your button creator) can call
    public void DisplayFoodsToCook(List<Foods> foodsToDisplay)//call this method to update the foods to display list
    {
        if (cookingListText == null)
        {
            Debug.LogError("CookingListText reference is missing!");
            return;
        }

        // Use StringBuilder for efficient text concatenation
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"--- {CoolNames[Random.Range(0, CoolNames.Count)]} ---");

        if (foodsToDisplay == null || foodsToDisplay.Count == 0)
        {
            sb.AppendLine("No items currently selected.");
        }
        else
        {
            foreach (Foods food in foodsToDisplay)
            {
                // Format the line as a bullet point list
                sb.AppendLine($"- {food.name} | Allergen: {food.allergen}  | ${food.cookTime:F2}");
            }
        }
        
        // Update the actual UI text box with the compiled string
        cookingListText.text = sb.ToString();
    }
     public void OnRefreshButtonClicked()
    {
        
        DisplayFoodsToCook(foodsToDisplay);
        
    }
    public void clearFoodsToDisplay()//call this method to clear the foods to display list
    {
        foodsToDisplay.Clear();
        
    }
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

        List<Foods> foodsToDisplay = new List<Foods>(foodsList);
        OnRefreshButtonClicked();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
