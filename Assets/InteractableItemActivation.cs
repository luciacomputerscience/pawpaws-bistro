using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableItemActivation : MonoBehaviour
{
    void Start()
    {
        InteractablesManager.AddToInteractablesEvent.Invoke(transform);
    }

    void OnDisable()
    {
        InteractablesManager.RemoveFromInteractablesEvent.Invoke(transform);
    }
}
