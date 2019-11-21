using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeBall : MonoBehaviour
{

    #region Public
    public GameObject slime;
    public AudioSource BallSource;
    public AudioClip BallHit;
    #endregion

    #region Private
    private Rigidbody myRB;
    private float speed;
    #endregion



    // Start is called before the first frame update
    void Start()
    {
        BallSource.clip = BallHit;
    }

    // Update is called once per frame
    void Update()
    {
        speed = myRB.velocity.magnitude;
        if (speed < 0.08)
        {
            Destroy(gameObject);
        }
    }

    public void Poison(Vector3 _force)
    {
        myRB = GetComponent<Rigidbody>();
        myRB.AddForce(_force);
    }

    void OnCollisionEnter(Collision collision)
    {
        BallSource.Play();
    }
}

