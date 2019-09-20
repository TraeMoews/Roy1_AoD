using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public int redScore;
    public Text redscoreText;
    public int blueScore;
    public Text bluescoreText;

   
    // Start is called before the first frame update
    void Start()
    {
        bluescoreText.text = "Score: " + blueScore;
        redscoreText.text = "Score: " + redScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(int points)
    {
        blueScore += points;

        bluescoreText.text = "Score: " + blueScore;
    }
}
