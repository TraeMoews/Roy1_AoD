using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PegManagmentTemp : MonoBehaviour
{
    Pegs[] allPegs;
    float fire;
    float ice;
    List<Pegs> peg;

    // Start is called before the first frame update
    void Start()
    {
        allPegs = FindObjectsOfType<Pegs>();
    }
    

    public void RemovePegs(Pegs _temp)
    {
        int _totalPegs = 0;
        for(int i = 0; i < allPegs.Length; i++)
        {
            if(allPegs[i] != null)
            {
                if (_temp.name == allPegs[i].name)
                {
                    if (allPegs[i].gameObject.CompareTag("Fire"))
                    {
                        fire++;
                        print("Fire Score: " + fire);
                        allPegs[i] = null;
                    }
                    else if (allPegs[i].gameObject.CompareTag("Ice"))
                    {
                        ice++;
                        print("Ice Score: " + ice);
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
            if(fire > ice)
            {
                print("Fire wins!!!! " + fire + " to " + ice);
            }
            else if(ice > fire)
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
