using System.Collections;
using UnityEngine;

public class Item : MonoBehaviour
{
    [Header("Item Info")]
    [SerializeField] private string itemName;
    [SerializeField] private float cookTime;
    [SerializeField] private string allergen;
    [SerializeField] private Sprite sprite;

    public string ItemName => itemName;
    public Sprite Sprite => sprite;

    [Header("Cooking State")]
    public bool onCookingSurface = false;
    public bool timerRunning = false;
    private float cookedTime = 0f;

    private ItemSlot currentSlot;

    private void Update()
    {
        if(timerRunning && onCookingSurface)
            cookedTime += Time.deltaTime;
    }

    public void SnapToSlot(ItemSlot slot)
    {
        currentSlot = slot;
        transform.position = slot.transform.position;
        transform.rotation = slot.transform.rotation;
        onCookingSurface = true;
        StartTimer();
    }

    public void StartTimer() => timerRunning = true;
    public void StopTimer() => timerRunning = false;

    public string EndCook()
    {
        StopTimer();
        onCookingSurface = false;

        float diff = cookTime - cookedTime;
        string note;

        if(diff <= 1f && diff >= -1f) note = "Perfectly cooked!";
        else if(diff < 3f && diff > 1f) note = "Slightly Undercooked!";
        else if(diff > 3f) note = "Undercooked!";
        else if(diff < -1f && diff > -3f) note = "Slightly Overcooked!";
        else note = "Overcooked!";

        Debug.Log($"{itemName}: {note}" + ". Command sent from EndCook in Item.cs");
        return note;
    }

    public void RemoveFromSlot()
    {
        currentSlot?.ClearSlot();
        currentSlot = null;
        onCookingSurface = false;
    }
}
