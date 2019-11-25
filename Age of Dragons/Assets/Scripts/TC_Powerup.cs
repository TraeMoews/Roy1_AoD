using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TC_Powerup : MonoBehaviour
{
    private Gold playerGold;
    public GameObject P1;
    public GameObject P2;
  
   


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player1")
        {
            playerGold.GetComponent<Gold>().gold = 0;
        }
        else if (other.tag == "Player2:")
       {
            playerGold.GetComponent<Gold>().gold = 0;
       }
        this.gameObject.SetActive(false);
    }
}
