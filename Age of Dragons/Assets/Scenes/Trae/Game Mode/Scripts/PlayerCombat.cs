using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    bool canAttack;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canAttack)
        {
            if (GetComponent<Movement>())
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    print("Player one attack");
                }
            }
            else if (GetComponent<PlayerTwoMove>())
            {
                if (Input.GetKeyDown(KeyCode.RightShift))
                {
                    print("Player two attack");
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Gold>())
        {
            canAttack = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Gold>())
        {
            canAttack = false;
        }
    }
}
