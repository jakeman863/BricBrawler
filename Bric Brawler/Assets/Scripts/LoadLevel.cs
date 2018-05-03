using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadLevel : MonoBehaviour
{

    public void LoadLevelButton(int index)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(index);   
    }

    public void LoadLevelButton(string levelName)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(levelName);
    }

    public void ExitLevelButton()
    {
        Application.Quit();
    }

    public void Unpause()
    {

        Time.timeScale = 1;
    }
    
}