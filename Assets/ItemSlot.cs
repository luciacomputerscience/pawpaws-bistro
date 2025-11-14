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
            Debug.Log("CurrItemTag:" + item.tag +" | CurrSlotTag:" + this.tag);
            if ((item.tag != ("Need" + this.tag)) && (this.tag != "Untagged"))
            {
                Debug.Log("Item does not belong here.");
                Debug.Log(item);
                ClearSlot();
                return false;
            }
            else
            {
                Debug.Log("added" + item.name + "to "+ this.name + ". Command sent from AddItem in ItemSlot.cs");
                item.SnapToSlot(this);
                isFull = true;
                return true;
            }            
        }
        else
        {
            Debug.Log("Slot full!");
            return false;
        }
    }

    public void OnMouseDown()
    {
        Debug.Log("Clicked slot: " + this.name +"Holding:" + currentItem + ". Command sent from OnMouseDown in ItemSlot.cs");
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
        else if (transform.parent.parent.name == "Stations")
        {
            if (isFull==false)
            {
                return;
            }
            else
            {
                bool sent = InventoryManager.Instance.AddItem(currentItem);
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
