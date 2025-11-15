using System;
using UnityEngine;

public class StationSwitcher : MonoBehaviour
{
    [Header("Stations")]
    public GameObject fryerStation;
    public GameObject grillStation;
    public GameObject plateStation;
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
                break;

            case "Grill":
                currentScene = "Grill";
                grillStation.SetActive(true);
                break;

            case "Plate":
                currentScene = "Plate";
                plateStation.SetActive(true);
                break;

            default:
                Debug.LogWarning("Unknown station: " + stationName);
                break;
        }
    }
}
