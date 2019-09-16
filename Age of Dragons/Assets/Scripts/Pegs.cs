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
    public Rigidbody pegBody;
    public Rigidbody fire;
    public Rigidbody ice;
    #endregion

    #region Private
    private bool ghost;
    private float hit = 0f;
    private GameObject peg;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        ghost = false;


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region Fuctions

    public void ghostPeg()
    {
        if (hit == 2)
        {
            ghost = true;
        }
    }

    public void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "IceBall")
        {
            Color ice = coll.gameObject.GetComponent<Material>().color;
            gameObject.GetComponent<Material>().color = ice;
            Debug.Log("Ice");
        }
        else if (coll.gameObject.tag=="FireBall")
        {
            Color fire = coll.gameObject.GetComponent<Material>().color;
            gameObject.GetComponent<Material>().color = fire;
            Debug.Log("Fire");
        }
    }
    #endregion
}
