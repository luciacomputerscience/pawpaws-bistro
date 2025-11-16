using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fryer2Listener : MonoBehaviour
{
    public Fryer2Audio F2Audio;
    public ItemSlot fryer2;
    bool started1 = false;

    // Update is called once per frame
    void Update()
    {
        if (fryer2.isFull == true && started1 == false)
        {
            F2Audio.playAudio();
            Debug.Log("fryer 2 Playing");
            started1 = true;
        }
        else if (fryer2.isFull == false && started1 == true)
        {
            F2Audio.stopAudio();
            Debug.Log("fryer 2 Stopped Playing");
            started1 = false;
        }
    }
}
