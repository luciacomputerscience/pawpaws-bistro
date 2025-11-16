using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grill1Audio : MonoBehaviour
{
    public new AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void playAudio()
    {
        audio.Play();
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
