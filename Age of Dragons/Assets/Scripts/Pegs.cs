/*  ╔═════════════════════════════╡  Mech Defense Force 2019 ╞══════════════════╗            
    ║ Authors:  Donald Thatcher          Email: donald.thatcher@outlook.com     ║
    ╟───────────────────────────────────────────────────────────────────────────╢░ 
    ║ Purpose:  Controls Pegs and Territories                                   ║░
    ║ Usage:    Handles color change and locking of Pegs and Territoties        ║░
    ╚═══════════════════════════════════════════════════════════════════════════╝░
       ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pegs : MonoBehaviour
{

    #region Public
    public GameObject peg;
    public Rigidbody fire;
    public Rigidbody ice;
    public Material iceMat;
    public Material fireMat;

    #endregion

    #region Private
    private bool ghost;
    private float hit = 0f;
    private Renderer rend;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        ghost = false;
        rend = GetComponent<Renderer>();
        rend.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region Fuctions

    // Will disable peg in scene when hit twice by same color ball
    public void ghostPeg()
    {
        if (hit == 2)
        {
            ghost = true;
        }
    }

    // Determine what ball hit peg and turns it the respective color
    void OnCollisionEnter(Collision coll)
    {
        switch (coll.gameObject.tag)
        {
            case "Ice":
            rend.sharedMaterial = iceMat;
            Debug.Log("Ice");
            break;

            case "Fire":        
            rend.sharedMaterial = fireMat;
            Debug.Log("Fire");
            break;
        }
    }
    #endregion
}
