using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Public

    public int p1Score;
    public Text p1ScoreText;
    public GameObject p1ScoreSize;
    public float player1;
    public float p1ScoreTimer = 0;
    public int p2Score;
    public Text p2ScoreText;
    public GameObject p2ScoreSize;
    public float player2;
    public float p2ScoreTimer = 0;

    public Text winnerText;
    public int points;
    bool gameComplete;
    float timer = 5f;

    public GameObject UImen;
    Pegs[] allPegs;
    public List<Pegs> peg;

    //Characters 
    public GameObject Fire1;
    public GameObject Ice1;
    public GameObject Slime1;
    public GameObject Paralysis1;

    public GameObject Fire2;
    public GameObject Ice2;
    public GameObject Slime2;
    public GameObject Paralysis2;
 
    #endregion






    // Start is called before the first frame update
    void Start()
    {
        allPegs = FindObjectsOfType<Pegs>();
        p2ScoreText.text = "Score: " + p2Score;
        p1ScoreText.text = "Score: " + p1Score;
    }

    void Update()
    {
        p1ScoreTimer += Time.deltaTime;
        p2ScoreTimer += Time.deltaTime;
        if (p1ScoreTimer >= .5f)
        {
            p1ScoreSize.transform.localScale = new Vector3(2, 3, 1);
        }
        if (p2ScoreTimer >= .5f)
        {
            p2ScoreSize.transform.localScale = new Vector3(2, 3, 1);
        }
        if (gameComplete)
        {
            UImen.SetActive(true);
        }
    }

   /* public void UpdateScore(int points)
    {
        p2Score += points;

        p2ScoreText.text = "Score: " + p2Score;
    }*/

    public void RemovePegs(Pegs _temp)
    {
        int _totalPegs = 0;
        for (int i = 0; i < allPegs.Length; i++)
        {
            if (allPegs[i] != null)
            {
                if (_temp.name == allPegs[i].name)
                {
                    if (allPegs[i].gameObject.CompareTag("Player2"))
                    {
                        player2++;
                        p2ScoreText.text = "Score: " + player2 * 100;
                        AdjustPlayer1Text();
                        allPegs[i] = null;

                    }
                    else if (allPegs[i].gameObject.CompareTag("Player1"))
                    {
                        player1++;
                        p1ScoreText.text = "Score: " + player1 * 100;
                        AdjustPlayer2Text();
                        allPegs[i] = null;
                    }
                }
            }
            else
            {
                _totalPegs++;
            }

        }
        
        if (_totalPegs == allPegs.Length - 1)
        {
            if (player2 > player1)
            {
                winnerText.text = "Player 2 wins!!!! " + player2 + " to " + player1;
            }
            else if (player1 > player2)
            {
                winnerText.text = "Player 1 wins!!!! " + player1 + " to " + player2;
            }
            else
            {
                winnerText.text = "Tie! Player 1: " + player1 + " Player 2: " + player2;
            }

            gameComplete = true;
        }

    }
    public void AdjustPlayer1Text()
    {
        p1ScoreTimer = 0;
        p1ScoreSize.transform.localScale = new Vector3(2, 4, 1);   
    }
    public void AdjustPlayer2Text()
    {
        p2ScoreTimer = 0;
        p2ScoreSize.transform.localScale = new Vector3(2, 4, 1);
    }

    string DragonSelected = PlayerPrefs.GetString("DragonSelected");

}