using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NewBehaviourScript : MonoBehaviour
{
    private InteractiveViewCursorControls controls;

    [SerializeField]
    private InteractablesManager interactablesManager;

    [SerializeField]
    private Texture2D interactiveCursorTexture;
    private Cursor InteractiveCursor;

    [SerializeField]
    private Transform newSelectionTransform;
    private Transform currentSelectionTransform;

    public static Action MakeCursorDefault;
    public static Action MakeCursorInteractive;
    private bool cursorIsInteractive = false;

    public float DistanceThreshold;

    void Awake()
    {
        controls = new InteractiveViewCursorControls();
        controls.Mouse.Click.started += _ => StartedClick();
        controls.Mouse.Click.performed += _ => EndedClick();
        MakeCursorDefault += DefaultCursorTexture;
        MakeCursorInteractive += InteractiveCursorTexture;
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private void Update()
    {
        FindInteractableWithinDistanceThreshold();
    }

    private void FindInteractableWithinDistanceThreshold()
    {
        newSelectionTransform = null;
        Vector2 mouseScreen = controls.Mouse.Position.ReadValue<Vector2>();

        for (int i = 0; i < interactablesManager.Interactables.Count; i++)
        {
            Transform item = interactablesManager.Interactables[i];
            Vector2 itemScreen = Camera.main.WorldToScreenPoint(item.position);

            Vector2 delta = new Vector2(itemScreen.x - mouseScreen.x, itemScreen.y - mouseScreen.y);
            float sqrMag = delta.sqrMagnitude;

            if (sqrMag < DistanceThreshold * DistanceThreshold)
            {
                newSelectionTransform = item;

                if (cursorIsInteractive == false)
                {
                    InteractiveCursorTexture();
                }
                break;
            }
        }
        if (currentSelectionTransform != newSelectionTransform)
        {
            currentSelectionTransform = newSelectionTransform;
            DefaultCursorTexture();
        }
    }

    private void InteractiveCursorTexture()
    {
        cursorIsInteractive = true;
        Vector2 hotspot = new Vector2(interactiveCursorTexture.width / 2, 0);
        Cursor.SetCursor(interactiveCursorTexture, hotspot, CursorMode.Auto);
    }

    private void DefaultCursorTexture()
    {
        cursorIsInteractive = false;
        Cursor.SetCursor(default, default, default);
    }

    private void StartedClick()
    {

    }

    private void EndedClick()
    {
        OnClickInteractable();
    }
    
    private void OnClickInteractable()
    {
        if (newSelectionTransform != null)
        {
            IInteractable interactable = newSelectionTransform.gameObject.GetComponent<IInteractable>();
            if (interactable != null) { interactable.OnClickAction(); }
            newSelectionTransform = null;
        }
    }

}
