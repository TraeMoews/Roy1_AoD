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
    //AudioSource for launcher sound
    public AudioSource LaunchSource;
    //AudioClip for launcher sound
    public AudioClip LaunchClip;

    float targetDis;
    [SerializeField]
    float modForce;

    Vector3 mousePos;
    GameObject myShot;
    Vector3 targetLoc;

    bool hasShot;
    // Update is called once per frame

    public GameObject targetMove;
    Vector3 startLoc;
    bool backAgain;

    GameManager gm;
    public int explosionPower;

    private void Awake()
    {
        QualitySettings.vSyncCount = 0;  // VSync must be disabled
        Application.targetFrameRate = 60;
        gm = FindObjectOfType<GameManager>();
        if(targetMove != null)
        {
            startLoc = transform.position;
        }
    }
    void Update()
    {
        if(targetMove != null)
        {
            if (transform.position == targetMove.transform.position)
            {
                backAgain = false;
            }
            else if (transform.position == startLoc)
            {
                backAgain = true;
            }

            if (backAgain)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetMove.transform.position, .2f);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, startLoc, .2f);
            }
        }

        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Cursor.visible = false;
        mousePos.z = transform.position.z;
        reticel.transform.position = mousePos;

        if(myShot == null)
        {
            hasShot = false;
        }

        if (Input.GetMouseButtonDown(0) && !hasShot)
        {
            hasShot = true;
            targetLoc = transform.position - reticel.transform.position;
            targetDis = Vector3.Distance(transform.position, reticel.transform.position);
            myShot = Instantiate(shot, transform.position, transform.rotation);
            if(gm.fire >= explosionPower)
            {
                myShot.AddComponent<Explosions>();
                print("Fire Explosions on");
            }
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
            
            myShot.GetComponent<FireBall>().Flame(targetLoc * (modForce));
        }
    }
}
