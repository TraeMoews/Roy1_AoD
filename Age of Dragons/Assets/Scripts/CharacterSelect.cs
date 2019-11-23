using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterSelect : MonoBehaviour
{
    #region Public
    public List<GameObject> availableDragonsP1;
    public List<GameObject> availableDragonsP2;
    public int selectionIndex = 0;
    public Vector3 playerSpawnPosition;
    public GameObject Player1;
    public GameObject Player2;
    
    #endregion

    // Start is called before the first frame update
   private void Start()
   {
        

        
       availableDragonsP1 = new List<GameObject>();
        foreach(Transform t in transform.transform.Find("ModelsContainerP1").transform)
        {
            availableDragonsP1.Add(t.gameObject);
            t.gameObject.SetActive(false);
        }

        availableDragonsP1[selectionIndex].SetActive(true);

       availableDragonsP2 = new List<GameObject>();
        foreach(Transform t in transform.transform.Find("ModelsContainerP2").transform)
        {
            availableDragonsP2.Add(t.gameObject);
            t.gameObject.SetActive(false);
        }

        availableDragonsP2[selectionIndex].SetActive(true);
        
    }

    // Update is called once per frame
    private void Update()
    {

    }
    public void SelectP1(int index)
    {
        if (index == selectionIndex)
            return;

        if (index < 0 || index >= availableDragonsP1.Count)
            return;

        availableDragonsP1[selectionIndex].SetActive(false);
        selectionIndex = index;
        availableDragonsP1[selectionIndex].SetActive(true);
        Player1 = availableDragonsP1[index];
    }

    public void SelectP2(int index)
    {
        if (index == selectionIndex)
            return;

        if (index < 0 || index >= availableDragonsP2.Count)
            return;

        availableDragonsP2[selectionIndex].SetActive(false);
        selectionIndex = index;
        availableDragonsP2[selectionIndex].SetActive(true);
        Player2 = availableDragonsP2[index];
    }

   /* public void StartGame(int characterChoices)
    {
        GameObject SpawnPlayer1 = Instantiate(Player1, playerSpawnPosition, Quaternion.identity) as GameObject;
        GameObject SpawnPlayer2 = Instantiate(Player2, playerSpawnPosition, Quaternion.identity) as GameObject;
    }

    public void Choice()
    {
        PlayerPrefs.SetString("DragonSelected", availableDragons[selectionIndex].name);
    }*/

}
