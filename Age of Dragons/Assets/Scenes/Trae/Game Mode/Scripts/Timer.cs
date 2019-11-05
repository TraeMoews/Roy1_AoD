using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float levelTimer = 120f;
    public Text timerOne;
    public Text timerTwo;

    public Text winnerText;
    public GameObject winnerObject;

    public bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        winnerObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (levelTimer <= 0 && !gameOver)
        {
            gameOver = true;
            levelTimer = 0;
            timerOne.text = "Time: " + levelTimer.ToString("F2");
            timerTwo.text = "Time: " + levelTimer.ToString("F2");
            EndGame();
        }
        else if(!gameOver)
        {
            levelTimer -= Time.deltaTime;
            timerOne.text = "Time: " + levelTimer.ToString("F2");
            timerTwo.text = "Time: " + levelTimer.ToString("F2");
        }
    }

    void EndGame()
    {
        //get gold check who won
        //Display winner in text box
        Gold player1;
        Gold player2;

        player1 = FindObjectOfType<Movement>().GetComponent<Gold>();
        player2 = FindObjectOfType<PlayerTwoMove>().GetComponent<Gold>();

        winnerObject.SetActive(true);

        if (player1.hoardGold > player2.hoardGold)
        {
            winnerText.text = "Player 1 is the winner with: " + player1.hoardGold + " Gold. Congratulations!";
        }
        else if(player1.hoardGold < player2.hoardGold)
        {
            winnerText.text = "Player 2 is the winner with: " + player1.hoardGold + " Gold. Congratulations!";
        }
        else
        {
            winnerText.text = "Perfect Tie!";
        }
    }
}
