using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestLevelController : MonoBehaviour
{
    // Start is called before the first frame update

    public Text nextLevel;

    private void Start()
    {
#if ENV_PROD
        gameObject.SetActive(false);
        Debug.unityLogger.logEnabled = false;
#else
        gameObject.SetActive(true);
        Debug.unityLogger.logEnabled = true;
#endif
    }

    public void SetNextLevel()
    {
        PlayerPrefsManager.CurrentIndex = int.Parse(nextLevel.text);
        // GameSceneManager.Instance.NextLevel();
    }
}
