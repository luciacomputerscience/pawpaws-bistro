using UnityEngine;
using UnityEngine.UI; // Required for UI elements

public class ButtonOutlineChanger : MonoBehaviour
{
    public Button targetButton; // Assign your button in the Inspector

    // Method to change the outline color
    public void ChangeOutlineColor(Button targetButton, Color newColor)
    {
        if (targetButton != null)
        {
            // Get the Outline component from the button's GameObject
            Outline buttonOutline = targetButton.GetComponent<Outline>();

            if (buttonOutline != null)
            {
                // Set the effectColor of the Outline
                buttonOutline.effectColor = newColor;
                Debug.Log("Button outline color changed to: " + newColor);
            }
            else
            {
                Debug.LogWarning("No Outline component found on the target button.");
            }
        }
        else
        {
            Debug.LogError("Target Button not assigned in the Inspector.");
        }
    }

    public void blinkGreen(Button targetButton)
    {
        float t = Mathf.PingPong(Time.time, 1f);
        ChangeOutlineColor(targetButton, Color.Lerp(Color.black, Color.green, t));
    }
    public void blinkRed(Button targetButton)
    {
        float t = Mathf.PingPong(Time.time, 1f);
        ChangeOutlineColor(targetButton, Color.Lerp(Color.black, Color.red, t));
    }
    public void blinkYellow(Button targetButton)
    {
        float t = Mathf.PingPong(Time.time, 1f);
        ChangeOutlineColor(targetButton, Color.Lerp(Color.black, Color.yellow, t));
    }
    public void Update()
    {
        
    }

    // Example usage (optional): Call this from another script or UI event
   
}