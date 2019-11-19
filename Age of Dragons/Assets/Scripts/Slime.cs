using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{

    #region Public
    public GameObject slime;
    public float speed;
    public AudioSource Ballsource;
    public AudioClip BallHit;
    #endregion

    #region Private
    #endregion



    // Start is called before the first frame update
    void Start()
    {
        Ballsource.clip = BallHit;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
