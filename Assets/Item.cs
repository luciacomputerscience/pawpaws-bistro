using System.Collections;
using UnityEngine;

public class Item : MonoBehaviour
{
    [Header("Item Info")]
    [SerializeField] public string itemName;
    [SerializeField] public float cookTime;
    [SerializeField] private string allergen;
    [SerializeField] public Sprite sprite;
    public string note;
    public Sprite raw;
    public Sprite undercooked;
    public Sprite Perfect;
    public Sprite SlightOver;
    public Sprite Burnt;

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
        sprite = raw;
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
        updateSprite();
    }

    public void SnapToSlot(ItemSlot slot)
    {
        currentSlot = slot;
        transform.position = slot.transform.position;
        transform.rotation = slot.transform.rotation;
    }
    public void updateSprite()
    {
        if (cookedTime < cookTime - 2)
        {
            sprite = raw;
        }
        else if (cookedTime < cookedTime - 1)
        {
            sprite = undercooked;
        }
        else if (cookedTime > cookedTime - 1 && cookedTime < cookTime + 1)
        {
            sprite = Perfect;
        }
        else if (cookedTime > cookTime + 1 && cookedTime < cookedTime + 2)
        {
            sprite = SlightOver;
        }
        else if (cookedTime > cookTime + 2)
        {
            sprite = Burnt;
        }
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
