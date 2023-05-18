using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using System;

public class PlayerController : MonoBehaviour
{

    public static PlayerController Instance;
    public static ToolPlayer tools;
    public static bool isStartCheckAline;
    public static bool isFocusPlayGame = true;
    public static bool isGunAvailable
    {
        get => GunController.isGunAvailable;
        set => GunController.isGunAvailable = value;
    }
    public static bool isScannerAvailable
    {
        get => ScannerController.isScannerAvailable;
        set => ScannerController.isScannerAvailable = value;
    }

    public float speedRotate = 0.0f;
    public float pathSpeed = 5.0f;

    //[HideInInspector]
    public float minAngle, maxAngle = 0.0f;
    public bool isReveseCheckAngle = false;
    public bool isStartGame;
    public bool isCatch;
    [HideInInspector]
    public bool isDetected;

    public GunController gunController;
    public GunManager gunManager;
    public Bullet beam;
    public ScannerController scannerController;
    public ScannerManager scannerManager;
    public ToolController tool;
    public Camera mainCam;
    public Camera toolCam;
    public CamManager camManager;
    public CatchSubject catchPanel;
    [HideInInspector]
    public GameObject particle;

    [HideInInspector]
    public GamePath gamePath;
    private bool isCatching;

    float scaleDuration = 1f;

    public PlayerController GetIntance()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        return Instance;
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // beam = gunManager.gunManager.guns[PlayerPrefsManager.CurrentGun].beam.GetComponent<Bullet>();
        SetCamPath();
    }


    void Update()
    {
        //CatchAlien();
    }
    private void MovePlayer(Vector3[] path)
    {
        isStartCheckAline = false;
        isScannerAvailable = false;

        transform.position = path[0];
        transform.rotation = Quaternion.LookRotation(path[1] - path[0]);
        float pathDuration = path.GetDuration(pathSpeed);
        transform.DOPath(path, pathDuration, PathType.Linear)
            .SetLookAt(0.2f)
            .SetEase(Ease.Linear)
            .OnComplete(() =>
            {
                isStartCheckAline = true;
                isScannerAvailable = true;
                // EventDispatcher.Instance.PostEvent(EventID.CameraPathComplete);
            });
    }

    private void CatchAlien()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                var selection = hit.transform;
                // if (selection.m_tag.Equals("Alien") && selection.gameObject.GetComponent<CharacterComponent>().isTakeDown)
                // {
                //     catchPanel.gameObject.SetActive(true);
                //     isCatching = true;
                // }
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isCatching = false;
            catchPanel.gameObject.SetActive(false);
            catchPanel.GetComponent<CatchSubject>().CancelCatching();
        }

        if (isCatching)
        {
            catchPanel.GetComponent<CatchSubject>().OnCatching();
        }
    }

    public void StartGame()
    {
        Debug.Log("Current Level: " + PlayerPrefsManager.CurrentIndex);
        // Vibration.VibrateRhythm();
        SoundManager.instance.PlaySingle(SoundType.Touch);
        isStartGame = true;
        if (gamePath == null) SetCamPath();
        MovePlayer(gamePath.path.GetTransformPath(gamePath.position));
        if (PlayerPrefsManager.IsLevelBonus == 0)
        {
            tool.ShowTool(scaleDuration);
            scannerController.ShowScanner(scaleDuration, false);
            gunController.ShowGun(scaleDuration);
        }
        else
        {
            tool.SelectGun();
            scannerController.HideScanner(scaleDuration);
            gunController.ShowGun(scaleDuration, false);
        }
    }

    public void SetCamPath()
    {
        // gamePath = PlayerPrefsManager.currentLevelData.cameraPath;
        // transform.position = gamePath.path.GetTransformPath(gamePath.position)[0];
        // transform.rotation = Quaternion.LookRotation(gamePath.path.GetTransformPath(gamePath.position)[1] - gamePath.path.GetTransformPath(gamePath.position)[0]);
    }

    public void DoRotate(float force, bool isLeft = true)
    {
        Vector3 angle = transform.eulerAngles;
        float step = (isLeft ? -1 : 1) * Time.deltaTime * speedRotate;
        angle.y += step * force;
        if (!isReveseCheckAngle) angle.y = Mathf.Clamp(angle.y, minAngle, maxAngle);
        else
        {
            angle.y = angle.y.LimitAngleTo360();

            if (isLeft && angle.y > maxAngle && angle.y < minAngle)
            {
                angle.y = minAngle;
            }
            else if (!isLeft && angle.y < minAngle && angle.y > maxAngle)
            {
                angle.y = maxAngle;
            }

        }

        transform.eulerAngles = angle;
    }

    public void InitStartGame()
    {
        GameManager.Instance.earnedCoin = 0;
        // UIManager.Instance.ResetUIPanel();
        scannerController.ResetScanner();
        gunController.ResetGun();
        tool.ResetToolContainer();
        SetCamPath();
    }

    public IEnumerator HideTool()
    {
        yield return new WaitForSeconds(1f);
        gunController.HideGun(scaleDuration);
        scannerController.HideScanner(scaleDuration);
        tool.HideTool(scaleDuration);
    }

    public void PlayerLookAtAlien(Transform alienTrans)
    {
        transform.DOLookAt(alienTrans.position, 1f);
    }

    public void DestroyTut()
    {
        GameManager.Instance.isPassTut = true;
        PlayerPrefsManager.IsShowTut = 1;
        // UIManager.Instance.inGameController.DestroyTut();
        tool.DestroyTut();
    }
}
