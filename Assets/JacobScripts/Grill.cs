using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grill : MonoBehaviour
{
    private GameObject food1;
    Foods editfood1;
    private bool check1 = false;
    private GameObject food2;
    Foods editfood2;
    private bool check2 = false;
    private List<GameObject> detectedObjects = new List<GameObject>();

    public void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("NeedGrill"))
        {
            detectedObjects.Add(other.gameObject);
            if (detectedObjects.Count == 1)
            {
                if (check1 == false)
                {
                    food1 = other.gameObject;
                    editfood1 = food1.GetComponent<Foods>();
                    editfood1.CorrectCookingSurface = true;
                    check1 = true;
                    Debug.Log("Grill1 assigned successfully!");
                }
                else if (check2 == false)
                {
                    food2 = other.gameObject;
                    check2 = true;
                    editfood2 = food2.GetComponent<Foods>();
                    editfood2.CorrectCookingSurface = true;
                    Debug.Log("GRill2 assigned successfully!");
                }
            }
            else
            {
                if (check1 == false)
                {
                    food1 = other.gameObject;
                    editfood1 = other.GetComponent<Foods>();
                    editfood1.CorrectCookingSurface = true;
                    check1 = true;
                    Debug.Log("Grill1 assigned successfully!");
                }
                else if (check2 == false)
                {
                    food2 = other.gameObject;
                    check2 = true;
                    editfood2 = other.GetComponent<Foods>();
                    editfood2.CorrectCookingSurface = true;
                    Debug.Log("Grill2 assigned successfully!");
                }
            }


        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == food1)
        {
            check1 = false;
            Debug.Log("Successfully removed item1.");
        }else if (other.gameObject == food2){
            check2 = false;
            Debug.Log("Successfully removed item2.");
        }
    }
    public void startStop()
    {
        if (check1 == true)
        {
            editfood1.StartAndStop();
        }
        if (check2 == true)
        {
            editfood2.StartAndStop();
        }
    }
    public void StartTimer()
    {
        if (check1 == true && editfood1.timerRunning == false)
        {
            editfood1.timerRunning = true;
        }
        if (check2 == true && editfood2.timerRunning == false)
        {
            editfood2.timerRunning = true;
        }
    }

    public void StopTimer()
    {
        if (check1 == true && editfood1.timerRunning == true)
        {
            editfood1.timerRunning = false;
        }
        if (check2 == true && editfood2.timerRunning == true)
        {
            editfood2.timerRunning = false;
        }
    }
}
