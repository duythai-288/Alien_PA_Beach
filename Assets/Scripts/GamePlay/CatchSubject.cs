using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatchSubject : MonoBehaviour
{
    public GameObject catchLoading;
    public GameObject catchPanel;
    public Text catchPercent;
    public Text statusText;
    private bool isCatching;
    private int percent;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void OnCatching()
    {
        catchPanel.SetActive(true);
        isCatching = true;
        catchLoading.SetActive(true);
        statusText.text = "Catch Progress";
    }

    public void CancelCatching()
    {
        isCatching = false;
        catchLoading.SetActive(false);
        catchPercent.text = "";
        percent = 0;
        statusText.text = "Hold To Catch";
    }

    // Update is called once per frame
    void Update()
    {
        //if (isCatching)
        //{
        //    catchLoading.transform.Rotate(0, 0, 3);
        //    percent++;
        //    if (percent <= 100)
        //    {
        //        catchPercent.text = percent + "%";
        //    }
        //    else
        //    {
        //        isCatching = false;
        //        CatchSuccessful();
        //    }
        //}

    }

    public void CatchSuccessful()
    {
        statusText.text = "Success";
    }
}
