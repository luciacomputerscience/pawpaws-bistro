using UnityEngine;

public class ItemSlot : MonoBehaviour
{
    public Item currentItem;
    public bool isFull;

    public bool AddItem(Item item)
    {
        if(currentItem == null)
        {
            currentItem = item;
            item.SnapToSlot(this);
            isFull = true;
            return true;
        }
        else
        {
            Debug.Log("Slot full!");
            return false;
        }
    }

    public void RemoveItem()
    {
        if(currentItem != null)
        {
            currentItem.StopTimer();
            currentItem.onCookingSurface = false;
            currentItem = null;
        }
    }

    // private void OnMouseDown()
    // {
        // if(currentItem != null)
        // {
            // InventoryManager.Instance.AddItem(currentItem);
            // RemoveItem();
        // }
    // }
}
