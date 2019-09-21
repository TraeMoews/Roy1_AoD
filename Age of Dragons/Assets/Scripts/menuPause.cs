using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menuPause : MonoBehaviour
{
    //Variables go in this line
    //This calls the canvas in the scene
    [SerializeField]
    GameObject goCanvas;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Escape opens the canvas
        if (Input.GetKey(KeyCode.Escape))
        {
            goCanvas.SetActive(true);
        }
    }

    //Additional Functions
    public void resumetheGame()
    {
        goCanvas.SetActive(false);
    }

    public void restartTheScene(int LevelNumber)
    {
        SceneManager.LoadScene(LevelNumber);
    }

    public void goToMainMenu(int LevelNumber)
    {
        SceneManager.LoadScene(LevelNumber);
    }

    public void quitTheGame()
    {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
