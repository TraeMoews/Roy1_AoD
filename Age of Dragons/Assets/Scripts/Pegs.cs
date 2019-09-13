/*  ╔═════════════════════════════╡  Mech Defense Force 2019 ╞══════════════════╗            
    ║ Authors:  Donald Thatcher          Email: donald.thatcher@outlook.com     ║
    ╟───────────────────────────────────────────────────────────────────────────╢░ 
    ║ Purpose:  Contorls Pegs and Territories                                   ║░
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
    public Rigidbody pegs;
    public Rigidbody priPlayer;
    public Rigidbody secPlayer;
    #endregion

    #region Private
    private bool ghost;
    private float hit = 0f;
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
        //if (priPlayer )
    }
    #endregion
}
