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
            Debug.Log("added" + item.name + "to slot");
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

    public void OnMouseDown()
    {
        Debug.Log("Clicked slot: " + this.name +"Holding:" + currentItem);
        if (transform.parent.name == "InventoryCanvas") {
            if (isFull==false)
            {
                return;
            }
            else
            {
                bool sent = CookStationControl.Instance.ReceiveItem(currentItem);
                if (sent)
                {
                    ClearSlot();
                }
            }    
        } 
    }
    public void ClearSlot()
    {
        if(currentItem != null)
        {
            currentItem.StopTimer();
            currentItem.onCookingSurface = false;
            currentItem = null;
            isFull = false;
        }
    }
}
