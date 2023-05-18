using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour
{
    public MeshRenderer offScreen, onScreen, holoScreen, noInternet, scanner;
    public Vector3 screenSpace, offsetHandle;

    //Add icon no internet here

    public void ActiveScreen()
    {
        bool isActive = offScreen.gameObject.activeInHierarchy;
        if (!isActive) return;
        onScreen.sharedMaterial.SetFloat("_Alpha", 0);
        holoScreen.sharedMaterial.SetFloat("_Alpha", 0);
        holoScreen.gameObject.SetActive(true);
        offScreen.gameObject.SetActive(false);
        StartCoroutine(DoFadeActiveScreen(0.2f));
    }

    public IEnumerator DoFadeActiveScreen(float duration)
    {
        WaitForEndOfFrame waitForEndOfFrame = new WaitForEndOfFrame();
        float elaspedTime = 0;
        while (elaspedTime < duration)
        {
            float ratio = elaspedTime / duration;
            onScreen.sharedMaterial.SetFloat("_Alpha", ratio);
            holoScreen.sharedMaterial.SetFloat("_Alpha", ratio);
            yield return waitForEndOfFrame;
            elaspedTime += Time.deltaTime;
        }
        onScreen.sharedMaterial.SetFloat("_Alpha", 1);
        holoScreen.sharedMaterial.SetFloat("_Alpha", 1);
    }

    public void DeactiveScanner()
    {
        // GameAnalytics.ToolUserDetect(TOOL_STATE.STOP_SCAN);
        offScreen.gameObject.SetActive(true);
        holoScreen.gameObject.SetActive(false);
        noInternet.gameObject.SetActive(false);
        StopAllCoroutines();
    }

    public void NoInternetScanner()
    {
        noInternet.gameObject.SetActive(true);
    }

    public void ActiveInternet()
    {
        noInternet.gameObject.SetActive(false);
    }
}
