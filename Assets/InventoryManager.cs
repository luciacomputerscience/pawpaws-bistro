using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    private void Awake() => Instance = this;
    public ItemSlot[] itemSlot;

    public bool AddItem(Item item)
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            if(itemSlot[i].isFull == false)
            {
                Debug.Log(itemSlot[i] + ". Command sent from AddItem in InventoryManager.cs");
                itemSlot[i].AddItem(item);
                return true;
            }
        }
        return false;
    }
}
