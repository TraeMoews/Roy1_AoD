using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameDataController : MonoBehaviour
{

    #region Public
    public GameObject player1;
    public GameObject player2;
    public string scenechoice;
    #endregion

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }




    #region Scene Controls
    public void LoadLevelSelect()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    public void CharacterSelect()
    {
        SceneManager.LoadScene("CharacterSelect");
    }

    public void LevelChoice(string sceneName)
    {
        scenechoice = sceneName;
    }

    public void LoadSelectedLevel(string scenechoice)
    {
        SceneManager.LoadScene(scenechoice);
    }
    #endregion

    public void QuitGame()
    {
        Application.Quit();
    }


}
