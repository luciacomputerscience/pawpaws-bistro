using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fryer2Audio : MonoBehaviour
{
    public new AudioSource audio;
    public AudioClip audioClip;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void playAudio()
    {
        if (audio != null)
        {
            audio.Play();
            audio.PlayOneShot(audioClip);
            Debug.Log("Audio playinggg");
        }

    }

    public void stopAudio()
    {
        audio.Stop();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
