using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public int redScore;
    public Text redscoreText;
    public int blueScore;
    public Text bluescoreText;

    public GameObject bScoreSize;
    public GameObject rScoreSize;
    public Text winnerText;

    Pegs[] allPegs;
    public float fire;
    public float ice;
    List<Pegs> peg;

    public int points;
    bool gameComplete;
    float timer = 5f;

    public GameObject UImen;

    public float rScoreTimer = 0;
    public float bScoreTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        allPegs = FindObjectsOfType<Pegs>();
        bluescoreText.text = "Score: " + blueScore;
        redscoreText.text = "Score: " + redScore;
        rScoreSize = FindObjectOfType<RedText>().gameObject;
        bScoreSize = FindObjectOfType<BlueText>().gameObject;
    }

    void Update()
    {
        rScoreTimer += Time.deltaTime;
        bScoreTimer += Time.deltaTime;
        if (rScoreTimer >= .5f)
        {
            rScoreSize.transform.localScale = new Vector3(2, 3, 1);
        }
        if (bScoreTimer >= .5f)
        {
            bScoreSize.transform.localScale = new Vector3(2, 3, 1);
        }
        if (gameComplete)
        {
            UImen.SetActive(true);
            //timer -= Time.deltaTime;
            //if (timer <= 0)
            //{

            //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            //}
        }
    }

    public void UpdateScore(int points)
    {
        blueScore += points;

        bluescoreText.text = "Score: " + blueScore;
    }

    public void RemovePegs(Pegs _temp)
    {
        int _totalPegs = 0;
        for (int i = 0; i < allPegs.Length; i++)
        {
            if (allPegs[i] != null)
            {
                if (_temp.name == allPegs[i].name)
                {
                    if (allPegs[i].gameObject.CompareTag("Fire"))
                    {
                        fire++;
                        redscoreText.text = "Score: " + fire * 100;
                        AdjustRedText();
                        allPegs[i] = null;

                    }
                    else if (allPegs[i].gameObject.CompareTag("Ice"))
                    {
                        ice++;
                        bluescoreText.text = "Score: " + ice * 100;
                        AdjustBlueText();
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
            if (fire > ice)
            {
                winnerText.text = "Fire wins!!!! " + fire + " to " + ice;
            }
            else if (ice > fire)
            {
                winnerText.text = "Ice wins!!!! " + ice + " to " + fire;
            }
            else
            {
                winnerText.text = "Tie! ice: " + ice + " Fire: " + fire;
            }

            gameComplete = true;
        }

    }
    public void AdjustRedText()
    {
        rScoreTimer = 0;
        rScoreSize.transform.localScale = new Vector3(2, 4, 1);   
    }
    public void AdjustBlueText()
    {
        bScoreTimer = 0;
        bScoreSize.transform.localScale = new Vector3(2, 4, 1);
    }

}