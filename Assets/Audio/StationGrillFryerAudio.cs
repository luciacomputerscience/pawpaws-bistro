using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationGrillFryerAudio : MonoBehaviour
{
    public ItemSlot fryer1;
    public ItemSlot fryer2;
    public ItemSlot Grill1;
    public ItemSlot Grill2;
    public ItemSlot Grill3;
    public ItemSlot Grill4;
    public Fryer1Audio F1Audio;
    public Fryer2Audio F2Audio;
    public Grill1Audio G1Audio;
    public Grill1Audio G2Audio;
    public Grill1Audio G3Audio;
    public Grill1Audio G4Audio;
    private bool f1p= false;
    private bool f2p = false;
    private bool G1p = false;
    private bool G2p = false;
    private bool G3p = false;
    private bool G4p = false;




    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (fryer1.isFull == true && f1p == false)
        {
            
            Debug.Log("Fryer1 playing audio!");
            f1p = true;
        } else if (fryer1.playingAudio == false)
        {
            F1Audio.stopAudio();
            f1p = false;
        }
        if (f1p == true)
        {
            F1Audio.playAudio();
        }

        if (fryer2.playingAudio == true && f2p == false)
        {
            F2Audio.playAudio();
            f2p = true;
        }
        else if (fryer2.playingAudio == false)
        {
            F2Audio.stopAudio();
            f2p = false;
        }

        if (Grill1.playingAudio == true)
        {
            G1Audio.playAudio();
        }
        else if (Grill1.playingAudio == false)
        {
            G1Audio.stopAudio();
        }

        if (Grill2.playingAudio == true)
        {
            G2Audio.playAudio();
        }
        else if (Grill2.playingAudio == false)
        {
            G2Audio.stopAudio();
        }

        if (Grill3.playingAudio == true)
        {
            G3Audio.playAudio();
        }
        else if (Grill3.playingAudio == false)
        {
            G3Audio.stopAudio();
        }

        if (Grill4.playingAudio == true)
        {
            G4Audio.playAudio();
        }
        else if (Grill4.playingAudio == false)
        {
            G4Audio.stopAudio();
        }
    }
}
