using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grill3Listener : MonoBehaviour
{
    public Grill3Audio G3Audio;
    public ItemSlot grill3;
    bool started = false;


    // Update is called once per frame
    void Update()
    {
        if (grill3.isFull == true && started == false)
        {
            G3Audio.playAudio();
            started = true;
        }
        else if (grill3.isFull == false && started == true)
        {
            G3Audio.stopAudio();
            started = false;
        }
    }
}
