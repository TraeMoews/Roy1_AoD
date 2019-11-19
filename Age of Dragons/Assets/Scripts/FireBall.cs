using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    
    public AudioSource BallSource;
    public AudioClip BallHit;

    private Rigidbody myRB;
    private float speed;

	Player1 discheck;

    // Start is called before the first frame update
    void Start()
    {
        BallSource.clip = BallHit;
		discheck = FindObjectOfType<Player1>();
    }

    // Update is called once per frame
    void Update()
    {
        speed = myRB.velocity.magnitude;
        if (speed < 0.1)
        {
            Destroy(gameObject);
        }

		if(Vector3.Distance(transform.position, discheck.transform.position) > 100)
		{
			Destroy(gameObject);
		}
    }

    public void Flame(Vector3 _force)
    {
        myRB = GetComponent<Rigidbody>();
        myRB.AddForce(_force);
    }

    void OnCollisionEnter(Collision collision)
    {
        BallSource.Play();
    }
}
