using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableRed : MonoBehaviour, IInteractable
{
    public void OnClickAction()
    {
        Debug.Log("You clicked on red!");
    }

}
