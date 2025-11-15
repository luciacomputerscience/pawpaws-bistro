using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foods : MonoBehaviour
{
    public GameObject foodObject;
    public string fName { get; set; }
    public string allergen { get; set; }
    public float cookTime;
    public float cookedTime = 0f;
    public bool CorrectCookingSurface = false;
    public bool timerRunning = false;

    public void StartAndStop()
    {
        if (timerRunning == false) {
            
            timerRunning = true;
        } else
        {
            timerRunning = false;
            Score();
        }
        
    }

    public Foods()
    {
        fName = "Unknown Food";
        allergen = "Unknown Allergen";
    }

    public Foods(string name, string alerg, float cookT)
    {
        fName = name;
        allergen = alerg;
        cookTime = cookT;
    }


    private void Update()
    {


        if (timerRunning == true && CorrectCookingSurface == true)
        {
            cookedTime += Time.deltaTime;

        }
    }



    public void StartTimer()
    {
        timerRunning = true;
    }

    public void StopTimer()
    {
        timerRunning = false;
    }
    public void EndCook()
    {
        Score();
        Destroy(gameObject);
    }

   
    

    public void OnMouseUpAsButton()
    {
        EndCook();
    }
    public string Score()
    {
        float score = cookTime - cookedTime;

        Debug.Log(score);
        Debug.Log(cookTime);
        if (score <= 1f && score >= -1f)
        {
            Debug.Log("Perfectly cooked!");
            return "Perfectly cooked!";
        } 
        else if (score < 3f && score > 1f)
        {
            Debug.Log("Slightly Undercooked!");
            return "Slightly Undercooked!";
        }
        else if (score > 3f)
        {
            Debug.Log("Undercooked!");
            return "Undercooked!!";
        }else if (score < -1f && score > -3f){
            Debug.Log("Slightly Overcooked!");
            return "Slightly Overcooked!";
        } else
        {
            Debug.Log("Overcooked!");
            return "Overcooked!";
        }
    }

    
}
