using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grill2Audio : MonoBehaviour
{
    public new AudioSource audio3;
    public AudioClip audioClip;
    
    // Start is called before the first frame update
    void Start()
    {
        audio3 = GetComponent<AudioSource>();
    }

    public void playAudio()
    {
        if (audio3 != null)
        {
            audio3.Play();
            
            Debug.Log("Audio playinggg");
            
        }

    }

    public void stopAudio()
    {
        audio3.Stop();
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
