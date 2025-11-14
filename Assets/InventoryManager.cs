using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public ItemSlot[] itemSlot;

    public bool AddItem(string itemName, Sprite itemSprite)
    {
        Debug.Log(itemSlot);
        for (int i = 0; i < itemSlot.Length; i++)
        {
            if(itemSlot[i].isFull == false)
            {
                itemSlot[i].AddItem(itemName, itemSprite);
                return true;
            }
        }
        return false;
    }
}
