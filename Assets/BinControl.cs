using UnityEngine;

public class BinControl : MonoBehaviour
{
    [SerializeField] 
    private InteractablesManager interactablesManager;
    private InventoryManager inventoryManager;
    public Transform foodItem; // the prefab to spawn

    void Start()
    {
        interactablesManager = GameObject.Find("InteractablesManager").GetComponent<InteractablesManager>();
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
    }
    void OnMouseDown()
    {
        // Instantiate the prefab in the scene first
        GameObject spawnedItem = Instantiate(foodItem.gameObject, interactablesManager.transform);

        // Get the Item component from the spawned instance
        Item itemComponent = spawnedItem.GetComponent<Item>();

        // Try adding it to inventory
        bool added = inventoryManager.AddItem(itemComponent);

        if (!added)
        {
            Debug.Log("Inventory FULL");

            // If inventory full, destroy the spawned object to prevent clutter
            Destroy(spawnedItem);
            return;
        }
    }
}
