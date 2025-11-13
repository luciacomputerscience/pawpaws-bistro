using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMeal : MonoBehaviour
{
    public string mouseControlled = "n";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (mouseControlled == "y")
        {
            Vector2 mousePosition = new Vector2 (Input.mousePosition.x, Input.mousePosition.y);
            Vector2 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = objPosition;
        }
    }

    void OnMouseDown()
    {
        mouseControlled = "y";
    }
}
