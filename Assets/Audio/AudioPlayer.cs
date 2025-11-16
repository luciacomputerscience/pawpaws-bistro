using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{

    public AudioSource AudioGrill;
    public AudioSource AudioFryer;
    public AudioClip fryer;
    public AudioClip grill;
    public bool playingFryer = false;
    public bool playingGrill = false;

    // Start is called before the first frame update
    void Start()
    {
        AudioFryer = GetComponent<AudioSource>();
        AudioGrill = GetComponent<AudioSource>();
    }


    public void playfryer()
    {
        if (AudioFryer != null && fryer != null)
        {
            AudioFryer.Play();
            playingFryer = true;
        }
    }

    public void playGrill()
    {
        if (AudioGrill != null && grill != null)
        {
            AudioGrill.Play();
            playingGrill = true;
        }
    }

    public void StopGrill()
    {
        if (playingGrill == true)
        {
            AudioGrill.Stop();
            playingGrill = false;
        }
    }
    public void stopFryer()
    {
        if (playingFryer == true)
        {
            AudioFryer.Stop();
            playingFryer = false;
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
