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
        mainCamera = Camera.main;
    }
}










