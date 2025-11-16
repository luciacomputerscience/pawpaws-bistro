using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fryer2Audio : MonoBehaviour
{
    public AudioSource audio2;
    public AudioClip audioClip;
    
    // Start is called before the first frame update
    void Start()
    {
        audio2 = GetComponent<AudioSource>();
    }

    public void playAudio()
    {
        if (audio2 != null)
        {
            audio2.Play();
            
            Debug.Log("Audio playinggg");
            
        }

    }

    public void stopAudio()
    {
        audio2.Stop();
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
