using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InteractablesManager : MonoBehaviour
{
    [SerializeField]
    private List<Transform> interactables;

    public List<Transform> Interactables
    {
        get => interactables;
    }

    private Camera mainCamera;

    public static Action<Transform> AddToInteractablesEvent;
    public static Action<Transform> RemoveFromInteractablesEvent;

    private void Awake()
    {
        AddToInteractablesEvent += AddToListOfInteractables;
        RemoveFromInteractablesEvent += RemoveFromListOfInteractables;
    }

    private void AddToListOfInteractables(Transform transformToAddToList)
    {
        interactables.Add(transformToAddToList);
    }

    private void RemoveFromListOfInteractables(Transform transformToRemoveFromList)
    {
        interactables.Remove(transformToRemoveFromList);
    }

    void Start()
    {
        //Get the main camera on start
        mainCamera = Camera.main;

        AllChildrenWorldToScreenPoint();
    }

    private void AllChildrenWorldToScreenPoint()
    {
        // Loop through all the children objects we made and run WorldToScreenPoint on them
        // Cursor position will be giving us screen point info to determine whats within interactable distance.
        for (int i = 0; i < this.transform.childCount; i++)
        {
            transform.GetChild(i).position = mainCamera.WorldToScreenPoint(transform.GetChild(i).position);

            // Increase scale by 100
            transform.GetChild(i).localScale = Vector3.one * 100;
        }
    }
}













