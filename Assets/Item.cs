using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    private string itemName;
    [SerializeField]
    private float cookTime;
    [SerializeField]
    private string allergen;
    [SerializeField]
    private Sprite sprite;

    public Sprite Sprite => sprite;
    public string ItemName => itemName;

    private float cookedTime = 0f;
    private bool correctCookingSurface = false;
    private bool timerRunning = false;

    private InventoryManager inventoryManager;


    // Start is called before the first frame update
    void Start()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
    }

    private void Update()
    {
        if (timerRunning && correctCookingSurface)
            cookedTime += Time.deltaTime;
    }

    public void StartAndStop()
    {
        timerRunning = !timerRunning;
        if (!timerRunning)
            Score();
    }

    public void StartTimer() => timerRunning = true;
    public void StopTimer() => timerRunning = false;
    public void SetCookingSurface(bool isCorrect) => correctCookingSurface = isCorrect;

    public void EndCook()
    {
        Score();
        Destroy(gameObject);
    }

    public string Score()
    {
        float difference = cookTime - cookedTime;

        if (difference <= 1f && difference >= -1f)
            return "Perfectly cooked!";
        else if (difference < 3f && difference > 1f)
            return "Slightly Undercooked!";
        else if (difference > 3f)
            return "Undercooked!";
        else if (difference < -1f && difference > -3f)
            return "Slightly Overcooked!";
        else
            return "Overcooked!";
    }
// 
    // private void OnMouseUpAsButton()
    // {
        // EndCook();
    // }
}
