using UnityEngine;

public class CookStationControl : MonoBehaviour
{
    public static CookStationControl Instance;
    public ItemSlot[] stationSlots;

    private void Awake() => Instance = this;

    public bool ReceiveItem(Item item)
    {
        foreach(var slot in stationSlots)
        {
            if(slot.AddItem(item))
            {
                Debug.Log($"Placed {item.ItemName} on slot {slot.name}");
                return true;
            }
        }

        Debug.Log("No slots available!");
        return false;
    }
}
