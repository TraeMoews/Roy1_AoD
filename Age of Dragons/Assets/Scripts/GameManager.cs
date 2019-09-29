﻿using System.Collections;
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

    public Text winnerText;

    Pegs[] allPegs;
    public float fire;
    public float ice;
    List<Pegs> peg;

    public int points;
    bool gameComplete;
    float timer = 5f;

    public GameObject UImen;

    // Start is called before the first frame update
    void Start()
    {
        allPegs = FindObjectsOfType<Pegs>();
        bluescoreText.text = "Score: " + blueScore;
        redscoreText.text = "Score: " + redScore;
    }

    void Update()
    {
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
                        allPegs[i] = null;

                    }
                    else if (allPegs[i].gameObject.CompareTag("Ice"))
                    {
                        ice++;
                        bluescoreText.text = "Score: " + ice * 100;
                        allPegs[i] = null;
                    }
                }
            }
            else
            {
                _totalPegs++;
            }

        }

        print(_totalPegs);
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

}