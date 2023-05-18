using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LoadLevelPanel : MonoBehaviour
{
    public static LoadLevelPanel Instance;
    public CanvasGroup canvasGroup;

    public void Start()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
        
    }

    public void Show(Action onEndShowAction)
    {
        canvasGroup.alpha = 0;
        canvasGroup.gameObject.SetActive(true);
        //gameObject.SetActive(true);
        canvasGroup.DOFade(1, 0.5f).OnComplete(() =>
        {
            onEndShowAction.Invoke();

        });
    }

    public void Hide()
    {
        canvasGroup.DOFade(0, 0.5f)
            .OnComplete(() => canvasGroup.gameObject.SetActive(false)) ;
        

    }
}
