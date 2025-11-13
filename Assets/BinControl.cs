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
    public Transform bottomBunObj;
    public Transform topBunObj;
    public Transform cookedChickenObj;
    public Transform rawChickenObj;
    public Transform cookedMeatObj;
    public Transform rawMeatObj;
    public Transform cookedFishObj;
    public Transform rawFishObj;
    public Transform friesObj;
    public Transform onionRingsObj;
    public Transform lettuceObj;
    public Transform tomatoesObj;
    public Transform cheeseObj;

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
            interactablesManager = GameObject.Find("InteractablesManager").GetComponent<InteractablesManager>();
        //if parent of gameobject is uncookable
        //Send to plate
        //Else send to inventory 
        if (transform.parent.name == "Uncookable")
        {
            // put on the plate
            Instantiate(lettuceObj, new Vector2(-2, -.5f), bottomBunObj.rotation, interactablesManager.transform);
        }
        else
        {
            //put in the inventory
            Instantiate(rawMeatObj, new Vector2(-2, -.5f), bottomBunObj.rotation, interactablesManager.transform);
        }
    }
}
