using UnityEngine;
using UnityEngine.UIElements;

public class ItemSlot : MonoBehaviour
{
    public Item currentItem;
    public StationSwitcher stationSwitcher;
    public bool isFull;
    
    public InventoryAudio invAud;
    public bool playingAudio = false;
    public bool playedAudio = false;
    public bool isInventory;


    private void Update()
    {
        if (isInventory == true)
        {
            if (isFull == true && playedAudio == false){
                invAud.playAudio();
                playedAudio = true;
            }
        }
        else
        {
            while (isFull == true && playingAudio == false)
            {

                playingAudio = true;
            }
            if (isFull == false && playingAudio == true)
            {

                playingAudio = false;
            }
        }
        
    }

    public bool AddItem(Item item)
    {
        if (item == null)
        {
            Debug.LogError("ItemSlot.AddItem received a null item!");
            return false;
        }
    
        if (currentItem != null)
        {
            Debug.Log("Slot full!");
            return false;
        }
        // Inventory slot

        if (this.tag == "Untagged")
        {
            currentItem = item;
            item.SnapToSlot(this);
            isFull = true;
            Debug.Log("Added " + item.name + " to inventory slot " + this.name);
            return true;
        }
    
        // Station slot
        if (this.tag == "Plate")
        {
            currentItem = item;
            item.SnapToSlot(this);
            isFull = true;
            Debug.Log("Added " + item.name + " to station slot " + this.name);
            return true;
        }
        else if (item.tag == "Need" + this.tag && item.tag == "Need" + stationSwitcher.currentScene && item.cookable == true)
        {

            currentItem = item;
            item.SnapToSlot(this);
            isFull = true;
            Debug.Log("Added " + item.name + " to station slot " + this.name);
            return true;
        }
    
        Debug.Log("Item does not belong here or wrong screen: " + item.name);
        return false;
    }

    public void OnMouseDown()
    {
        Debug.Log("Clicked slot: " + this.name +"Holding:" + currentItem + ". Command sent from OnMouseDown in ItemSlot.cs");
        if (transform.parent.name == "InventoryCanvas" ) {
            if (isFull==false)
            {
                return;
            }
            else
            {
                
                bool sent = CookStationControl.Instance.ReceiveItem(currentItem);
                if (sent)
                {
                    if (currentItem.CompareTag("NeedPlate"))
                    {
                        currentItem.onCookingSurface = false;
                    }
                    else
                    {
                        currentItem.onCookingSurface = true;
                    }

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
                    currentItem.onCookingSurface = false;
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
            Item tempItem = currentItem;
            currentItem = null;
            isFull = false;
            playedAudio = false;
            if (tempItem.cookedTime > 0f)
            {
                tempItem.EndCook();
            }
        }
    }
}
