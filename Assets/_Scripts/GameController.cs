using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    public static bool isPortrait = true;
    public CharacterController characterController;
    public UIController UI;
    public ToolChange toolChange;
    
    public Transform camParent;
    public NewScanner scanner;
    public NewGun gun;
    public Camera scannerCam;
    public MeshRenderer onScreenMesh;

    private RenderTexture _tempTexture, _blankTexture;
    private int _width = 540;
    private int _height = 960;

    private void Awake()
    {
        Instance = this;
        //Application.targetFrameRate = 30;
        characterController = GetComponent<CharacterController>();
    }

    private void Start()
    {
        float screenRatio = (Screen.width/(float)Screen.height);
        Debug.Log(screenRatio);
        if (screenRatio >= 1) {
            // Landscape Layout
            isPortrait = false;
            _tempTexture = new RenderTexture(_height, _width, 1);

        } else if (screenRatio < 1) {
            // Portrait Layout
            isPortrait = true;
            _tempTexture = new RenderTexture(_width, _height, 1);

        }
        // _tempTexture = new RenderTexture(_width, _height, 1);
        _blankTexture = _tempTexture;
        scannerCam.targetTexture = _tempTexture;
        onScreenMesh.material.mainTexture = _tempTexture;

        StageOne();
    }

    private void StageOne()
    {
        Luna.Unity.LifeCycle.GameStarted();
        scanner.scannerRun = true;
        characterController.StartStageOne();
        // StartCoroutine(CollectGC());
    }

    private void StageTwo()
    {
        scanner.Rest();
        gun.GunActive();
        characterController.StartStageTwo();
        scannerCam.gameObject.SetActive(false);
        UI.SuggestTargetAlien();
        onScreenMesh.material.mainTexture = null;
    }


    private void Update()
    {
        if(!scanner.scannerRun) return;
        _tempTexture.Release();
    }

    public void CheckAlien()
    {
        UI.SuggestGun();
        toolChange.ActiveGun();
        Luna.Unity.Analytics.LogEvent("alien_checked", 1);
    }

    public void StartScanner()
    {
        Luna.Unity.Analytics.LogEvent(Luna.Unity.Analytics.EventType.LevelStart);
        Luna.Unity.Analytics.LogEvent("scanner_click", 1);
        UI.NoSuggest(1);
        StartCoroutine(ScannerSound());
    }

    public void ChangeGun()
    {
        Debug.Log($"change gun");
        StageTwo();
        StopCoroutine(ScannerSound());
        Luna.Unity.Analytics.LogEvent("gun_click", 1);

    }

    public IEnumerator ShowEndCard()
    {
        scanner.ActiveScan();
        gun.Rest();
        yield return new WaitForSeconds(2f);
        camParent.DOLocalRotate(Vector3.zero, 1f);
        yield return new WaitForSeconds(1f);
        UI.ShowEndCard();
        
        Luna.Unity.LifeCycle.GameEnded();
    }

    private IEnumerator ScannerSound()
    {
        while (scanner.scannerRun)
        {
            AudioController.Instance.PlayOne(0);
            yield return new WaitForSeconds(2f);
        }
    }

}