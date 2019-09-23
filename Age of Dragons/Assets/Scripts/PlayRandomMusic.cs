using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayRandomMusic : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] track;
    private AudioClip trackClip;
    void Start()
    {
        //audioSource = gameObject.GetComponent<AudioSource>();
        int index = Random.Range(0, track.Length);
        trackClip = track[index];
        audioSource.clip = trackClip;
        audioSource.Play();
    }
    void Update()
    {


    }
}
