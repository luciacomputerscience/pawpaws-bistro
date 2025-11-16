using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grill2Listener : MonoBehaviour
{
    public Grill2Audio G2Audio;
    public ItemSlot grill2;
    bool started = false;


    // Update is called once per frame
    void Update()
    {
        if (grill2.isFull == true && started == false)
        {
            G2Audio.playAudio();
            started = true;
        }
        else if (grill2.isFull == false && started == true)
        {
            G2Audio.stopAudio();
            started = false;
        }
    }

   
}
