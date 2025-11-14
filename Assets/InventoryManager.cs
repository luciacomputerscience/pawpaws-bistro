using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    private void Awake() => Instance = this;

    public List<Item> items = new List<Item>();
    public ItemSlot[] itemSlot;

    public bool AddItem(Item item)
    {
        Debug.Log(itemSlot);
        for (int i = 0; i < itemSlot.Length; i++)
        {
            if(itemSlot[i].isFull == false)
            {
                itemSlot[i].AddItem(item);
                return true;
            }
        }
        return false;
        // 
        // items.Add(item);
        // item.transform.parent = inventoryParent;  // optional: snap to inventory container
        // item.transform.localPosition = Vector3.zero;
        // item.StopTimer();
        // item.onCookingSurface = false;
        // return true;
    }
// 
    // public bool RemoveItem(Item item)
    // {
        // if(items.Contains(item))
        // {
            // items.Remove(item);
            // return true;
        // }
        // return false;
    // }
}
