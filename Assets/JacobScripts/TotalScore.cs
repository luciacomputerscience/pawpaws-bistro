using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TotalScore : MonoBehaviour
{
    public List<float> scores = new List<float>();
    public float average;
    public string ScoreNote;
    public Foods foodscript;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AverageScore()
    {
        float averageS = scores.Average();
        if (averageS <= 1f && averageS >= -1f)
        {
            Debug.Log("Perfectly cooked!");
            ScoreNote = "Perfectly cooked!";
        }
        else if (averageS < 3f && averageS > 1f)
        {
            Debug.Log("Slightly Undercooked!");
            ScoreNote = "Slightly Undercooked!";
        }
        else if (averageS > 3f)
        {
            Debug.Log("Undercooked!");
            ScoreNote = "Undercooked!!";
        }
        else if (averageS < -1f && averageS > -3f)
        {
            Debug.Log("Slightly Overcooked!");
            ScoreNote = "Slightly Overcooked!";
        }
        else
        {
            Debug.Log("Overcooked!");
            ScoreNote = "Overcooked!";
        }
    }
}
