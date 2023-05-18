using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject hand, hand2;

    // public TextMeshProUGUI suggestText;
    public Image textSprite;
    public List<Sprite> sprites;
    public Transform text1Pos, text2Pos;
    public Button CTAbutton;

    [LunaPlaygroundField("firstText_FindAlien", 0, "Game Settings")]
    public string firstText_FindAlien = "FIND THE ALIEN";

    [LunaPlaygroundField("secondText_KillAlien", 1, "Game Settings")]
    public string secondText_KillAlien = "KILL THE ALIEN";

    [LunaPlaygroundField("thirdText_ScanEndAlien", 2, "Game Settings")]
    public string thirdText_ScanEndAlien = "SCAN THE ALIEN";

    [LunaPlaygroundField("text color", 3, "Game Settings")]
    public Color textColor;

    private void Start()
    {
        Luna.Unity.Analytics.LogEvent(Luna.Unity.Analytics.EventType.TutorialStarted, 1);
        ShowTextHand(true);
        //suggestText.text = firstText_FindAlien;
        textSprite.sprite = sprites[0];
        hand.transform.position = text1Pos.position;
        hand.transform.DOLocalMoveY(0, 1f).SetLoops(-1, LoopType.Yoyo);
        textSprite.transform.DOScale(1.1f, 1).SetLoops(-1, LoopType.Yoyo);
    }

    private void ShowTextHand(bool show)
    {
        textSprite.gameObject.SetActive(show);
        hand.gameObject.SetActive(show);
    }

    public void SuggestGun()
    {
        Luna.Unity.Analytics.LogEvent(Luna.Unity.Analytics.EventType.TutorialStarted, 2);

        ShowTextHand(true);

        //suggestText.text = secondText_KillAlien;
        textSprite.sprite = sprites[1];

        hand.transform.position = text2Pos.position;
    }

    public void SuggestScanEnd()
    {
        textSprite.transform.DOLocalMoveY(370, 0.1f).OnComplete(() => { ShowTextHand(true); });
        
        //suggestText.text = thirdText_ScanEndAlien;
        textSprite.sprite = sprites[2];

        hand.transform.position = text1Pos.position;
    }

    public void SuggestTargetAlien()
    {
        hand.SetActive(false);
        hand2.SetActive(true);
        Transform child = hand2.transform.GetChild(0);
        child.DOLocalMoveY(-100, 1).SetLoops(-1, LoopType.Yoyo);
    }

    public void NoSuggest(int position)
    {
        Luna.Unity.Analytics.LogEvent(Luna.Unity.Analytics.EventType.TutorialComplete, position);
        ShowTextHand(false);
        if (position == 2)
        {
            hand2.gameObject.SetActive(false);
            textSprite.gameObject.SetActive(false);
        }
    }

    public void OpenStore()
    {
        Debug.Log($"CTA pressed");
        Luna.Unity.Playable.InstallFullGame();
    }

    public void ShowEndCard()
    {
        Luna.Unity.Analytics.LogEvent(Luna.Unity.Analytics.EventType.EndCardShown);
        SuggestScanEnd();
        CTAbutton.gameObject.SetActive(true);
    }
}