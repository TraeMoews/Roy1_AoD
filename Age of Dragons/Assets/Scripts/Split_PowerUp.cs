using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Split_PowerUp : MonoBehaviour
{
    //Variables
    public GameObject[] balls;
    int ballsNo;



    // Start is called before the first frame update
    void Start()
    {
      
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

        Vector3 ballPos = new Vector3(this.transform.position.x, this.transform.position.y, transform.position.z);
        ballsNo = Random.Range(4, 8);

        for (int i = 0; i < ballsNo + 1; i++)
        {
            if (collision.gameObject.name.Contains("Devin_IceBall"))
                Instantiate(balls[0], ballPos, transform.rotation);

            else if (collision.gameObject.name.Contains("Devin_FireBall"))
                Instantiate(balls[1], ballPos, transform.rotation);

        }

        this.gameObject.SetActive(false);

    }
}

