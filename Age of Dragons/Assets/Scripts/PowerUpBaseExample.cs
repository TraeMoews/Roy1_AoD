using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBaseExample : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "IceBall" || other.gameObject.tag == "FireBall")
        {
            //do the power up thing
            Debug.Log("You" + other.gameObject.name + "touched me");
        }
    }
}