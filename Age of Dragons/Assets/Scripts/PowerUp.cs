using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    //Variables
    public GameObject[] balls;
    int ballsNo;
    public float maxPos = 1.7f;
    public float delayTimer;
    float timer;


    // Start is called before the first frame update
    void Start()
    {
        timer = delayTimer;
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Fixed Update is called once input is detected
    private void FixedUpdate()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {

        timer -= Time.deltaTime;
        if (timer <= 0)
        {

            Vector3 ballPos = new Vector3(this.transform.position.x, this.transform.position.y, transform.position.z);
            ballsNo = Random.Range(0, 4);
            Instantiate(balls[ballsNo], ballPos, transform.rotation);
            timer = delayTimer;
        }
    }
}

