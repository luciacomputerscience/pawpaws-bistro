using UnityEngine;
using UnityEngine.UI;
using TMPro; // For TextMeshPro
using UnityEngine.Events;
using System.Collections.Generic;

public class BillCreator : MonoBehaviour
{
    public Transform canvasTransform;
    
    // Drag the GameObject with the FoodsList script onto this field in the Inspector
    public List<Foods> foodsList { get; set; }
    public List<Foods> foodsToDisplay = new List<Foods>();
    public GameObject buttonPrefab;
    public RectTransform parentContainer; 
    public float pixelsToMoveLeft = 100f; // Amount to shift existing buttons, adjust as needed

    public float buttonSpacingX = 10f; // Spacing between buttons
    private float currentXPosition = -10f; // Tracks the current X position for button placement

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

        List<Foods> foodsToDisplay = new List<Foods>(foodsList);

        GenerateFoodButtons();
    }
    

    public void GenerateFoodButtons()//List<Foods> foodsToDisplay)
    {
       MoveAllExistingButtonsLeft(pixelsToMoveLeft);

        foreach (Foods foodItem in foodsToDisplay)
        {
            GameObject newButtonGO = Instantiate(buttonPrefab, parentContainer);
            RectTransform buttonRT = newButtonGO.GetComponent<RectTransform>();

            // 1. Position the new button based on the current accumulated X position
            // We set the anchoredPosition.x and update the total X position for the next button
            buttonRT.anchoredPosition = new Vector2(currentXPosition, buttonRT.anchoredPosition.y);

            // 2. Update text and listener (as before)
            TMP_Text buttonTextComponent = newButtonGO.GetComponentInChildren<TMP_Text>(); 
            if (buttonTextComponent != null)
            {
                buttonTextComponent.text = $"{foodItem.fName} (${foodItem.cookTime:F2})";
            }
            Button buttonComponent = newButtonGO.GetComponent<Button>();
            //buttonComponent.onClick.AddListener(() => OnFoodButtonClick(foodItem));

            // 3. Increment the X position for the *next* button
            // We add the width of the current button + the desired spacing
            currentXPosition += buttonRT.sizeDelta.x + buttonSpacingX; 
        }
    }
    public void MoveAllExistingButtonsLeft(float moveAmount)
    {
        // Iterate through all children (existing buttons) in the parent container
        foreach (Transform child in parentContainer)
        {
            RectTransform childRT = child.GetComponent<RectTransform>();
            if (childRT != null)
            {
                // Option A: Instant movement
                childRT.anchoredPosition += new Vector2(-moveAmount, 0);

                // Option B: Smooth movement using a Coroutine (requires uncommenting IEnum and StartCoroutine in code)
                // StartCoroutine(MoveButtonSmoothly(childRT, childRT.anchoredPosition + new Vector2(-moveAmount, 0), movementDuration));
            }
        }
    }
    // This method will be called when a food button is clicked
    void OnFoodButtonClick()//Foods clickedFood)
    {
        //Debug.Log($"Clicked on {clickedFood.name}! It has {clickedFood.cookTime} cook time.");
    }
}