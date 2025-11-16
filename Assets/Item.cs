using System.Collections;
using UnityEngine;

public class Item : MonoBehaviour
{
    [Header("Item Info")]
    [SerializeField] public string itemName;
    [SerializeField] private float cookTime;
    [SerializeField] private string allergen;
    [SerializeField] private Sprite sprite;
    public string note;

    public string ItemName => itemName;
    public Sprite Sprite => sprite;

    [Header("Cooking State")]
    public bool onCookingSurface = false;
    public bool offScreen = false;
    public bool timerRunning = false;
    public bool cookable = true;
    public float cookedTime = 0f;

    private ItemSlot currentSlot;

    private void Start()
    {
        if (itemName == "Lettuce" || itemName == "Cheese")
        {
            note = "Not Cookable";
        }
    }

    private void Update()
    {
        if(onCookingSurface && offScreen)
        {
            StartTimer();
        }
        else
        {
            StopTimer();
        }
        if(timerRunning && onCookingSurface)
        cookedTime += Time.deltaTime;
    }

    public void SnapToSlot(ItemSlot slot)
    {
        currentSlot = slot;
        transform.position = slot.transform.position;
        transform.rotation = slot.transform.rotation;
    }

    public void StartTimer() => timerRunning = true;
    public void StopTimer() => timerRunning = false;

    public string EndCook()
    {
        StopTimer();
        onCookingSurface = false;
        if (!this.CompareTag("NeedPlate"))
        {
            cookable = false;
        }
        float diff = cookTime - cookedTime;
        

        if(diff <= 1f && diff >= -1f) note = "Perfectly Cooked!";
        else if(diff < 3f && diff > 1f) note = "Slightly Undercooked!";
        else if(diff > 3f) note = "Undercooked!";
        else if(diff < -1f && diff > -3f) note = "Slightly Overcooked!";
        else note = "Overcooked!";

        Debug.Log($"{itemName}: {note}" + ". Command sent from EndCook in Item.cs");
        return note;
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }
}
