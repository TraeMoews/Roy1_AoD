using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayRandomSound : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] track;
    private AudioClip trackClip;
    void Start()
    {

    }
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.H))
        {
            int index = Random.Range(0, track.Length);
            trackClip = track[index];
            audioSource.clip = trackClip;
            audioSource.Play();
        }
    }
}
