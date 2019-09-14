using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    //Used for aiming
    public GameObject reticel;
    //Bounds of play area
    public Camera mainCam;
    //Thing player is shooting
    public GameObject shot;

    float targetDis;
    float modForce;

    Vector3 mousePos;
    GameObject myShot;
    Vector3 targetLoc;

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
            if (targetDis <= 4)
            {
                print("min");
                modForce = -500;
            }
            else if (targetDis >= 10)
            {
                print("max");
                modForce = -800;
            }
            else
            {
                print("inbetween");
                modForce = -targetDis * 100;
            }

            myShot.GetComponent<IceBall>().Fire(targetLoc / 8 * (modForce));
        }
    }
}
