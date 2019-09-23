using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    public GameObject reticel;
    public Camera mainCam;
    public GameObject shot;

    GameObject myShot;
    Vector3 targetLoc;
    Vector3 mousePos;

    //AudioSource for launcher sound
    public AudioSource LaunchSource;
    //AudioClip for launcher sound
    public AudioClip LaunchClip;

    public float sen;
    float targetDis;
    [SerializeField]
    float modForce;

    bool hasShot;

    // Update is called once per frame
    void Update()
    {
        if (mainCam.WorldToScreenPoint(reticel.transform.position).x + (Input.GetAxis("Horizontal") * sen) < 0)
        {
            print("Off screen right");
            mousePos += new Vector3(.25f, 0, 0);
            reticel.transform.position = mousePos;
        }
        else if(mainCam.WorldToScreenPoint(reticel.transform.position).y + (Input.GetAxis("Vertical") * sen) < 0)
        {
            print("Off screen Bottom");
            mousePos += new Vector3(0, .25f, 0);
            reticel.transform.position = mousePos;
        }
        else if (mainCam.WorldToScreenPoint(reticel.transform.position).x + (Input.GetAxis("Horizontal") * sen) > 1000)
        {
            print("Off screen Left");
            mousePos -= new Vector3(.25f, 0, 0);
            reticel.transform.position = mousePos;
        }
        else if(mainCam.WorldToScreenPoint(reticel.transform.position).y + (Input.GetAxis("Vertical") * sen) > 760)
        {
            print("Off screen Top");
            mousePos -= new Vector3(0, .25f, 0);
            reticel.transform.position = mousePos;
        }
        else
        {
            mousePos.x += Input.GetAxis("Horizontal") * sen;
            mousePos.y += Input.GetAxis("Vertical") * sen;
            mousePos.z = transform.position.z; 
            reticel.transform.position = mousePos;
        }

        if(myShot == null)
        {
            hasShot = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && !hasShot)
        {
            hasShot = true;
            targetLoc = transform.position - reticel.transform.position;
            targetDis = Vector3.Distance(transform.position, reticel.transform.position);
            myShot = Instantiate(shot, transform.position, transform.rotation);
            LaunchSource.clip = LaunchClip;
            LaunchSource.Play();

            if (targetDis <= 4)
            {
                modForce = -50;
            }
            else if (targetDis >= 10)
            {
                modForce = -50;
            }
            else
            {
                modForce = -targetDis * 10;
            }

            myShot.GetComponent<IceBall>().Fire(targetLoc * (modForce));
        }
    }
}
