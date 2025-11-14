using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CookStationControl : MonoBehaviour
{
    public static CookStationControl Instance;

    public ItemSlot[] stationSlots;

    private void Awake()
    {
        Instance = this;
    }

    public bool ReceiveItem(string itemName, Sprite itemSprite)
    {
        foreach (var slot in stationSlots)
        {
            if (slot.isFull == false)
            {
                slot.AddItem(itemName, itemSprite);
                Debug.Log("Sent" + itemName + " to grill slot!");
                return true;
            }
        }

        Debug.Log("No grill slots available!");
        return false;
    }
}
