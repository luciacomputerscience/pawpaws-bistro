using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grill4Listener : MonoBehaviour
{
    public Grill4Audio G4Audio;
    public ItemSlot grill4;
    bool started = false;


    // Update is called once per frame
    void Update()
    {
        if (grill4.isFull == true && started == false)
        {
            G4Audio.playAudio();
            started = true;
        }
        else if (grill4.isFull == false && started == true)
        {
            G4Audio.stopAudio();
            started = false;
        }
    }
}
