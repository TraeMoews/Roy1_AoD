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

    Pegs[] allPegs;
    float fire;
    float ice;
    List<Pegs> peg;

    public int points;

    // Start is called before the first frame update
    void Start()
    {
        allPegs = FindObjectsOfType<Pegs>();
        bluescoreText.text = "Score: " + blueScore;
        redscoreText.text = "Score: " + redScore;
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
                print("Fire wins!!!! " + fire + " to " + ice);
            }
            else if (ice > fire)
            {
                print("Ice wins!!!! " + ice + " to " + fire);
            }
            else
            {
                print("Tie! ice: " + ice + " Fire: " + fire);
            }
        }

    }

}