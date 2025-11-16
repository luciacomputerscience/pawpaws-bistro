using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fryer1Listener : MonoBehaviour
{
    public Fryer1Audio F1Audio;
    public ItemSlot fryer1;
    bool started = false;


    // Update is called once per frame
    void Update()
    {
        if (fryer1.isFull == true && started == false)
        {
            F1Audio.playAudio();
            Debug.Log("fryer1Playing");
            started = true;
        }
        else if (fryer1.isFull == false && started == true)
        {
            F1Audio.stopAudio();
            Debug.Log("fryer1stoppedplaying");
            started = false;
        }
    }
}
