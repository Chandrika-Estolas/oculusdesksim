using System.Collections;
using System.Collections.Generic;
using System.Web;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 

public class SceneNavigation : MonoBehaviour
{
    public int Scene;

    public void ChangeScene()
    {
        SceneManager.LoadScene(Scene);
    }

    public void RestartScene()
    {
        // Get the current active scene
        Scene currentScene = SceneManager.GetActiveScene();

        // Reload the current scene
        SceneManager.LoadScene(currentScene.name);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
