using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelect : MonoBehaviour
{
    #region Public
    public List<GameObject> models;
    public int selectionIndex = 0;
    public Vector3 playerSpawnPosition;
    public GameObject Player1;
    public GameObject Player2;
    #endregion

    // Start is called before the first frame update
    private void Start()
    {
        models = new List<GameObject>();
        foreach(Transform t in transform)
        {
            models.Add(t.gameObject);
            t.gameObject.SetActive(false);
        }

        models[selectionIndex].SetActive(true);
    }

    // Update is called once per frame
    private void Update()
    {

    }
    public void Select(int index)
    {
        if (index == selectionIndex)
            return;

        if (index < 0 || index >= models.Count)
            return;

        models[selectionIndex].SetActive(false);
        selectionIndex = index;
        models[selectionIndex].SetActive(true);
    }

    public void StartGame(int characterChoices)
    {
        GameObject SpawnPlayer1 = Instantiate(Player1, playerSpawnPosition, Quaternion.identity) as GameObject;
    }

}
