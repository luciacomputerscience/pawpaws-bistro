using UnityEngine;
using UnityEngine.UI; // Required for UI elements

public class RectOutline : MonoBehaviour
{
    // Reference to the Outline component
    public GameObject rectangle;
    private Outline rectangleOutline;

    void Start()
    {
        // Get the Outline component attached to this same GameObject
        rectangleOutline = GetComponent<Outline>();

        if (rectangleOutline == null)
        {
            Debug.LogError("No Outline component found on this GameObject!");
        }
    }

    public void SetOutlineColor(GameObject rectangle,Color newColor)
    {
        rectangleOutline = rectangle.GetComponent<Outline>();
        if (rectangleOutline != null)
        {
            rectangleOutline.effectColor = newColor;
        }
    }

    // Example function to call the color change
   
    public void blinkGreen(GameObject rectangle)
    {
        float t = Mathf.PingPong(Time.time, 1f);
        SetOutlineColor(rectangle, Color.Lerp(Color.black, Color.green, t));
    }
    public void blinkRed(GameObject rectangle)
    {
        float t = Mathf.PingPong(Time.time, 1f);
        SetOutlineColor(rectangle, Color.Lerp(Color.black, Color.red, t));
    }
    public void blinkYellow(GameObject rectangle)
    {
        float t = Mathf.PingPong(Time.time, 1f);
        SetOutlineColor(rectangle, Color.Lerp(Color.black, Color.yellow, t));
    }

    public void Update()
    {


    }
    

}