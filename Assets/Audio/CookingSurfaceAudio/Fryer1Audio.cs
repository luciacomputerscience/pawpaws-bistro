using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fryer1Audio : MonoBehaviour
{
    public new AudioSource audio;
    public AudioClip audioClip;
    public bool playing = false;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void playAudio()
    {
        if (audio != null && playing == false)
        {
            audio.Play();
            audio.PlayOneShot(audioClip);
            Debug.Log("Audio playinggg");
            playing = true;

        }
        
    }

    public void stopAudio()
    {
        audio.Stop();
        playing = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
