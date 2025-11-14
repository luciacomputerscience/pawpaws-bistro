using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    //==ITEM DATA==//
    public string itemName;
    public Sprite itemSprite;
    public bool isFull;
    //==ITEM SLOT==//
    [SerializeField]
    private Image itemImage;

    public void AddItem(string itemName, Sprite itemSprite)
    {
        this.itemName = itemName;
        this.itemSprite = itemSprite;
        isFull = true;

        itemImage.sprite = itemSprite;
    }
    public void ClearSlot()
        {
            itemName = null;
            itemSprite = null;
            isFull = false;
            itemImage.sprite = null;
        }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Clicked slot: " + itemName);
        if (transform.parent.name == "InventoryCanvas") {
            
            if (isFull==false)
            {
                return;
            }
            else
            {
                bool sent = CookStationControl.Instance.ReceiveItem(itemName, itemSprite);
                if (sent)
                {
                    ClearSlot();
                }
            }    
        } 
    }
}
