using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosions : MonoBehaviour
{
    Collider[] pegsHit;
    
    private void OnCollisionEnter(Collision collision)
    {
        pegsHit = new Collider[Physics.OverlapSphere(transform.position, 8f).Length];
        pegsHit = Physics.OverlapSphere(transform.position, 3f);

        foreach(Collider i in pegsHit)
        {
            if(i.gameObject.CompareTag("Plain") || i.gameObject.CompareTag("Ice") || i.gameObject.CompareTag("Fire"))
            {
                i.gameObject.tag = gameObject.tag;

                if (i.GetComponentInChildren<Light>())
                {
                    if (gameObject.CompareTag("Ice"))
                    {
                        i.GetComponentInChildren<Light>().color = Color.blue;
                    }
                    else if (gameObject.CompareTag("Fire"))
                    {
                        i.GetComponentInChildren<Light>().color = Color.red;
                    }
                }
            }
        }
    }
}
