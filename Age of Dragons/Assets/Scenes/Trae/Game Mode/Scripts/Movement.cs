using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    Vector3 move;
  
    //Vector3 left = transform.Rotation(0, 0, -90);
    public float speed = .5f;
    CharacterController myCharCont;

    float stamina;
    bool inRestingZone;
    float maxStamina;
    bool canMove;

    Timer gameTimer;

    public Slider myStamina;
    // Start is called before the first frame update
    void Start()
    {
        
        gameTimer = FindObjectOfType<Timer>();
        myCharCont = GetComponent<CharacterController>();
        maxStamina = 10f;
        stamina = maxStamina;
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (!gameTimer.gameOver)
        {
            if (canMove)
            {
                float x;
                float z;

                x = Input.GetAxis("Horizontal");
                z = Input.GetAxis("Vertical");

                move = new Vector3(x, 0, z) * speed * Time.deltaTime;
                myCharCont.Move(move);

            }

            if (!inRestingZone)
            {
                if (canMove)
                {
                    stamina -= .02f;
                }
                else
                {
                    stamina += .05f;
                    if (stamina >= maxStamina)
                    {
                        canMove = true;
                    }
                }

                if (stamina <= 0)
                {
                    canMove = false;
                }
            }
            else if (inRestingZone)
            {
                if (stamina <= maxStamina)
                {
                    stamina += .075f;
                }

                if (Input.GetKeyDown(KeyCode.E))
                {
                    GetComponent<Gold>().GainHoardGold();
                }
            }

            myStamina.value = stamina * .1f;

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RestingArea"))
        {
            inRestingZone = true;
        }

        if (other.CompareTag("Town"))
        {
            if (other.GetComponent<Town>().owner == gameObject)
            {
                other.GetComponent<Town>().PickUpGold();
            }
            else
            {
                other.GetComponent<Town>().AssignAttacker(gameObject);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Town") && !gameTimer.gameOver)
        {
            other.GetComponent<Town>().ResetLoyalty();

            if (Input.GetKeyDown(KeyCode.E))
            {
                other.GetComponent<Town>().UpgradeTown();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("RestingArea"))
        {
            inRestingZone = false;
        }

        if (other.CompareTag("Town"))
        {
            other.GetComponent<Town>().RemoveAttacker();
        }
    }
}
