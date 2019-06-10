using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicMixer : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip MusicClip;
    public AudioSource MusicSource;

    public void Start()
    {
        MusicSource.clip = MusicClip;
    }

    // Update is called once per frame
    void Update()
    {
        if (Fries.instance.isEaten == true)
        {
            MusicSource.Play();
            Fries.instance.isEaten = false;

        }
    }
}
