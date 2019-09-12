using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public GameObject reticel;
    Vector3 mousePos;
    public Camera mainCam;
    public GameObject shot;
    GameObject myShot;
    public float sen;
    Vector3 targetLoc;
    float targetDis;
    float modForce;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        //mousePos = mousePos * sen;
        mousePos.z = transform.position.z;
        reticel.transform.position = mousePos;

        if (Input.GetMouseButtonDown(0))
        {
            targetLoc = transform.position - reticel.transform.position;
            targetDis = Vector3.Distance(transform.position, reticel.transform.position);
            myShot = Instantiate(shot, transform.position, transform.rotation);
            if(targetDis <= 4)
            {
                modForce = -500;
            }
            else if(targetDis >= 10)
            {
                modForce = -800;
            }
            else
            {
                modForce = -targetDis * 100;
            }
            print(targetDis);
            myShot.GetComponent<IceBall>().Fire(targetLoc/8 * (modForce));
        }
    }
}
