//Name: rayAim
//Author: Jacob Herring


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rayAim : MonoBehaviour
{
    private LineRenderer lineRenderer;
    public GameObject startingPos;
    public GameObject laserHit;
    Vector3 mousePosition;


    // Start is called before the first frame update
    void Start()
    {
        //locking the mouse indicator
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        //Calling the line Renderer
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Input to unlock the mouse indicator
        if (Input.GetKey(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else if (Input.GetKey(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        //Setting lineRenderer True in update
        lineRenderer.enabled = true;

        mousePosition = Camera.main.ScreenToViewportPoint(Input.mousePosition);

        RaycastHit2D hit = Physics2D.Raycast(transform.position,mousePosition, 3f);

        Debug.DrawLine(transform.position, mousePosition, Color.blue);

        //checking the line location
        print(lineRenderer.GetPosition(0));

        laserHit.transform.position = mousePosition;

        lineRenderer.SetPosition(0, startingPos.transform.position);
        lineRenderer.SetPosition(1, mousePosition);
        
    }
}
