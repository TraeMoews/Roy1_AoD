using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public AudioSource BallSource;
    public AudioClip BallHit;
    // Start is called before the first frame update
    void Start()
    {
        BallSource.clip = BallHit;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        BallSource.Play();
    }
}
