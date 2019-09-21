using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scenManager : MonoBehaviour
{
    public void loadLevel (int LevelNumber)
    {
        SceneManager.LoadScene(LevelNumber);
    }
}
