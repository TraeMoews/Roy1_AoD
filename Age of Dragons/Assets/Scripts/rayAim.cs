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
        //Calling the line Renderer
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Setting lineRenderer True in update
        lineRenderer.enabled = true;

        mousePosition = laserHit.transform.position;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, mousePosition, 1f);

        //Check to see where the ray is
        //Debug.DrawLine(transform.position, mousePosition, Color.blue);

        //checking the line location
        //print(lineRenderer.GetPosition(0));

        lineRenderer.SetPosition(0, startingPos.transform.position);
        lineRenderer.SetPosition(1, mousePosition);
        
    }
}
