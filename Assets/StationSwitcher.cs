using System;
using UnityEngine;

public class StationSwitcher : MonoBehaviour
{
    [Header("Stations")]
    public GameObject fryerStation;
    public GameObject grillStation;
    public GameObject plateStation;
    public ItemSlot[] stationSlots;
    public string currentScene = "Plate";

    void Start()
    {
        fryerStation.SetActive(false);
        grillStation.SetActive(false);
        plateStation.SetActive(true);
    }

    public void ChangeStation(string stationName)
    {
        fryerStation.SetActive(false);
        grillStation.SetActive(false);
        plateStation.SetActive(false);

        switch (stationName)
        {
            case "Fryer":
                currentScene = "Fryer";
                fryerStation.SetActive(true);
                UpdateItemVisibility();

                break;

            case "Grill":
                currentScene = "Grill";
                grillStation.SetActive(true);
                UpdateItemVisibility();

                break;

            case "Plate":
                currentScene = "Plate";
                plateStation.SetActive(true);
                UpdateItemVisibility();

                break;

            default:
                Debug.LogWarning("Unknown station: " + stationName);
                break;
        }
    }
    public void UpdateItemVisibility()
    {
        foreach (var slot in stationSlots)
        {
            if (slot.currentItem == null) 
            {
                continue;
            }
            SpriteRenderer sr = slot.currentItem.GetComponentInChildren<SpriteRenderer>();
            if (sr == null) {
                continue;
            }
            sr.enabled = slot.CompareTag(currentScene);
            slot.currentItem.offScreen = !slot.CompareTag(currentScene);
            slot.currentItem.UpdateCookSprite();
        }
    }
}