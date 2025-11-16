using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grill1Listener : MonoBehaviour
{
    public Grill1Audio G1Audio;
    public ItemSlot grill1;
    bool started = false;

    // Update is called once per frame
    void Update()
    {
        if (grill1.isFull == true && started == false)
        {
            G1Audio.playAudio();
            started = true;
        }
        else if (grill1.isFull == false && started == true)
        {
            G1Audio.stopAudio();
            started = false;
        }
    }
}
