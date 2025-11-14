using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.Rendering;

public class BinControl : MonoBehaviour
{
    [SerializeField] 
    private InteractablesManager interactablesManager;
    private InventoryManager inventoryManager;
    public Transform foodItem;

    void Start()
    {
        interactablesManager = GameObject.Find("InteractablesManager").GetComponent<InteractablesManager>();
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
    }

    void OnMouseDown()
    {
        Item item = foodItem.GetComponent<Item>();
        string parentCategory = transform.parent.name;

        bool added = inventoryManager.AddItem(item.ItemName, item.Sprite);

        if (!added)
        {
            Debug.Log("Inventory FULL");
            return;
        }

        // Only spawn it if added successfully
        GameObject spawnedItem = Instantiate(foodItem.gameObject, interactablesManager.transform);
    }


}
