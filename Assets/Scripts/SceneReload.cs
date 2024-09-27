using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneReload : MonoBehaviour
{
   
    // Update is called once per frame
    void Update()
    {
        // look for the R key to reload the scene
        if (Input.GetKeyDown(KeyCode.R)) {
            // get the current scene and set it to the currentScene variable
            Scene currentScene = SceneManager.GetActiveScene();

            // reload the current scene
            SceneManager.LoadScene(currentScene.name);
        }
    }
}
