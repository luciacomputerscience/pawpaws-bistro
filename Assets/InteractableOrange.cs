using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableOrange : MonoBehaviour, IInteractable
{
    public void OnClickAction()
    {
        Debug.Log("You clicked on orange!");
    }
}