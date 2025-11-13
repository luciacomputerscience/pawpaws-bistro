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
    public Transform foodItem;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        if (interactablesManager == null)
        {
            interactablesManager = GameObject.Find("InteractablesManager").GetComponent<InteractablesManager>();
        }
        if (foodItem == null)
        {
            Debug.LogWarning($"No prefab assigned to {name}!");
            return;
        }
        Debug.Log($"{name}'s parent is {transform.parent.name}");

        if (transform.parent.name == "Uncookable")
        {
            // put on the plate
            Instantiate(foodItem, new Vector2(-2, -.5f), foodItem.rotation, interactablesManager.transform);
        }
        else
        {
            //put in the inventory
            Instantiate(foodItem, new Vector2(-2, -.5f), foodItem.rotation, interactablesManager.transform);
        }
    }
}
