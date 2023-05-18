using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneAspect : MonoBehaviour
{
    private string portraitScene = "Map 2 - Prison Office";
    private string landscapeScene = "Map 2 - Prison Office Landscape";

    // Start is called before the first frame update
    void Start()
    {
        float screenRatio = (Screen.width/(float)Screen.height);
        Debug.Log(screenRatio);
        if (screenRatio >= 1) {
            // Landscape Layout
            SceneManager.LoadScene(landscapeScene);
        } else if (screenRatio < 1) {
            // Portrait Layout
            SceneManager.LoadScene(portraitScene);

        }
    }

    
}
