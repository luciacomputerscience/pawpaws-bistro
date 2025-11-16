using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text;

public class BillCreatorText : MonoBehaviour
{
    public TextMeshProUGUI cookingListText;
    public List<string> foodsList = new List<string>() {"Beef", "Chicken", "Fries", "Onion Rings", "Calamari", "Fish" };
    private List<string> foodsToDisplay = new List<string>();
    public List<string> AllergenNames = new List<string>(){"Stinky","Stanky","Organic Lab Product","Un-bearably infected","Fitzkulent"};
    public List<string> FoodPrices = new List<string>(){"59.9","69","Three Ninety","4 dollhairs","7.99 on a sunday","8.99 but not on a monday"};
   

    List<string> CoolNames = new List<string>() { "Merleap's Magical Mambo","Cook County Country Cooked","This Plate Is Big Enough For The Two Of Us", "Gaze Den, no wait i meant Gay-","Superstored & Frozen", "b- b- bill bill  b- b- bill", "There Is A Mouse In New Orleans","Unbearably Expensive","Totally Pawsome"};

    // A public method that other scripts (like your button creator) can call

    public void AddFoodToDisplay(List<string> NewOrder)//call this method to add foods to the foods to display list
    {
        //Look for Beef, Chicken, Fish, Fries, Onion Rings, Calamari
        
        clearFoodsToDisplay();
        foreach (string foodName in NewOrder)
        {
            foreach (string food in foodsList)
            {
                if (food == foodName)
                {
                    if (food == "Beef" || food == "Chicken" || food == "Fish" )
                    {
                        foodsToDisplay.Add(food + " Burger");
                    }
                    else if (food == "Fries" || food == "Onion Rings" || food == "Calamari" )
                    {
                        foodsToDisplay.Add("Side: " + food);
                    }
                     else 
                     {
                        foodsToDisplay.Add(food);
                     }
                    
                }
            }
        }
        DisplayFoodsToCook(foodsToDisplay);

        
    }
    public void DisplayFoodsToCook(List<string> foodsToDisplay)//call this method to update the foods to display list
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
            foreach (string food in foodsToDisplay)
            {
                // Format the line as a bullet point list
                string Allergen = AllergenNames[Random.Range(0, AllergenNames.Count)];
                string Price = FoodPrices[Random.Range(0, FoodPrices.Count)];
                sb.AppendLine($"- {food} :");
                sb.AppendLine($"    Allergen: {Allergen}");
                sb.AppendLine($"    Price: ${Price}");
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
    
    void Awake()
    {
        cookingListText = GetComponent<TextMeshProUGUI>();
    }
    void Start()
    {}
      
    

    // Update is called once per frame
    void Update()
    {
        
    }

}