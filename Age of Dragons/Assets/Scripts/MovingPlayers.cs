using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlayers : MonoBehaviour
{
    Player1 playerOneRef;
    Player2 playerTwoRef;

    Vector2 moveOneToLoc;
    Vector2 moveTwoToLoc;

    // Start is called before the first frame update
    void Start()
    {
        playerOneRef = FindObjectOfType<Player1>();
        playerTwoRef = FindObjectOfType<Player2>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
