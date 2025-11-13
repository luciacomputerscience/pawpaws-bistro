using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookStations : MonoBehaviour
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

        if(gameObject.name == "MeatPatties")
        {
            if (gameplay.grillS1 == "empty")
            {
                Instantiate(bottomBunObj, new Vector2(-2, -.5f), bottomBunObj.rotation, interactablesManager.transform);
                Instantiate(topBunObj, new Vector2(-2, -.4f), topBunObj.rotation, interactablesManager.transform);
                gameplay.grillS1 = "full";
            }
            else if (gameplay.grillS2 == "empty")
            {
                Instantiate(bottomBunObj, new Vector2(-1, -.5f), bottomBunObj.rotation, interactablesManager.transform);
                Instantiate(topBunObj, new Vector2(-1, -.4f), topBunObj.rotation, interactablesManager.transform);
                gameplay.grillS2 = "full";
            }
            else if (gameplay.grillS3 == "empty")
            {
                Instantiate(bottomBunObj, new Vector2(0, -.5f), bottomBunObj.rotation, interactablesManager.transform);
                Instantiate(topBunObj, new Vector2(0, -.4f), topBunObj.rotation, interactablesManager.transform);
                gameplay.grillS3 = "full";
            }
            else if (gameplay.grillS4 == "empty")
            {
                Instantiate(bottomBunObj, new Vector2(1, -.5f), bottomBunObj.rotation, interactablesManager.transform);
                Instantiate(topBunObj, new Vector2(1, -.4f), topBunObj.rotation, interactablesManager.transform);
                gameplay.grillS4 = "full";
            }         
            
        }
    }
}
