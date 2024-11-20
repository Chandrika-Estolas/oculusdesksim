using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class troubleshoot : MonoBehaviour
{
    public void LoadRandomScene()
    {
        // Generate a random number between 4 and 8 inclusive
        int randomSceneIndex = Random.Range(4, 7); // Random.Range with integers is inclusive on the lower bound and exclusive on the upper bound

        // Load the scene with the generated index
        SceneManager.LoadScene(randomSceneIndex);
    }
}

