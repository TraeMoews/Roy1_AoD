using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBlinker : MonoBehaviour
{

    public float CycleTime = 2.0f;

    public Color[] color;

    private float timeSinceLastChange;

    private int lastColor;
    // Use this for initialization
    void Start()
    {

        // Make sure we trigger right away
        timeSinceLastChange = CycleTime + 1.0f;

        // Start at the first color
        lastColor = -1;
    }

    // Update is called once per frame
    void Update()
    {
        // Add the time that has elapsed
        timeSinceLastChange += Time.deltaTime;

        // Has the time required passed?
        if (timeSinceLastChange >= CycleTime)
        {
            // Reset time counter
            timeSinceLastChange = 0.0f;

            // Wrap the index around if we reach the end of the array otherwise incrament the value;
            if (lastColor == (color.Length - 1))
            {
                lastColor = 0;
            }
            else
                lastColor++;

            // change the color
            Renderer r = this.GetComponent<Renderer>();
            r.material.SetColor("_Color", color[lastColor]);
        }
    }
}


