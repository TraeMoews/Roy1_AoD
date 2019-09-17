using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PegTransformation : MonoBehaviour
{

    bool fire;
    bool ice;
    PegManagmentTemp pegManRef;

    // Start is called before the first frame update
    void Start()
    {
        pegManRef = FindObjectOfType<PegManagmentTemp>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if(!fire && !ice)
        {
            if (gameObject.CompareTag("Plain"))
            {
                gameObject.tag = collision.collider.tag;
            }
            else if (collision.gameObject.CompareTag("Fire") && gameObject.CompareTag("Fire"))
            {
                print("Second Fire");
                fire = true;
                pegManRef.RemovePegs(this);
                Destroy(gameObject);
            }
            else if (collision.gameObject.CompareTag("Ice") && gameObject.CompareTag("Ice"))
            {
                print("Second Ice");
                ice = true;
                pegManRef.RemovePegs(this);
                Destroy(gameObject);
            }
            else if (gameObject.tag == "Fire")
            {
                gameObject.tag = collision.collider.tag;
            }
            else if (gameObject.tag == "Ice")
            {
                gameObject.tag = collision.collider.tag;
            }
        }
    }
}