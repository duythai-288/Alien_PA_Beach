using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
public class ToolController : MonoBehaviour
{
    [Header("Camera")]
    public CamManager cameraManager;
    public Camera toolCam;
    public Camera mainCamera;
    public Camera gunCamera;

    [Header("Tool Container")]
    public GameObject guideArrowsPrefab;

    [Header("Gun")]
    public GunController gunController;
    public Gun gun => gunController.gun;

    [Header("Scanner")]
    public ScannerController scannerController;


    public GameObject guideArrows;
    void Start()
    {
        PlayerController.tools = ToolPlayer.SCANNER;
        ResetToolContainer();
        if (!GameManager.Instance.isPassTut)
        {
            guideArrows = Instantiate(guideArrowsPrefab, transform);
            guideArrows.SetActive(false);
        }
    }

    public void ChangeTool()
    {
        if (PlayerController.isStartCheckAline)
        {
            // GameAnalytics.ToolUserDetect(TOOL_STATE.CHANGE_TOOL);
            scannerController.scanner.DeactiveScanner();
            cameraManager.DeactiveScanner();
            if (PlayerController.tools == ToolPlayer.SCANNER)
            {
                SelectGun();
            }
            else if (PlayerController.tools == ToolPlayer.GUN)
            {
                // GameAnalytics.ToolUserDetect(TOOL_STATE.USE_SCANNER);
                // Vibration.VibrateWeak();
                PlayerController.tools = ToolPlayer.SCANNER;
                PlayerController.isGunAvailable = false;
                PlayerController.isScannerAvailable = false;
                //SetLocalPositionZ(gunController.transform, 1);
                ChangePos(scannerController.scanner.transform,
                          scannerController.activeTransform,
                          onTransactionEndAction: () =>
                          {
                              PlayerController.isScannerAvailable = true;
                          });
                ChangePos(gunController.gun.transform,
                          gunController.restTransform);
                if (!GameManager.Instance.isPassTut)
                {
                    // if (PlayerController.Instance.pointedAlien != null)
                    // {
                    //     Debug.LogWarning("Take Gun");
                    //     guideArrows.SetActive(true);
                    //     UIManager.Instance.inGameController.tutorialController.HideShootText();
                    // }
                    // else
                    // {
                    //     guideArrows.SetActive(false);
                    //     UIManager.Instance.inGameController.tutorialController.ShowTwistedHand();
                    // }
                }
            }
        }
    }

    public void SelectGun()
    {
        // Vibration.VibrateWeak();
        SoundManager.instance.StopNoise();
        PlayerController.tools = ToolPlayer.GUN;
        PlayerController.isScannerAvailable = false;
        PlayerController.isGunAvailable = false;
        ShowPointedAlien();
        // GameAnalytics.ToolUserDetect(TOOL_STATE.USE_GUN);
        SetLocalPositionZ(scannerController.scanner.transform, 1);
        ChangePos(scannerController.scanner.transform,
            scannerController.restTransform);
        ChangePos(gun.transform,
            gunController.activeTransform,
            0.7f,
            () => { PlayerController.isGunAvailable = true; });
        if (!GameManager.Instance.isPassTut)
        {
            if (PlayerController.Instance != null)
            {
                // UIManager.Instance.inGameController.tutorialController.ShowShootText();
                guideArrows.SetActive(false);
            }
            else
            {
                Debug.LogWarning("Take Scanner");
                guideArrows.SetActive(true);
                // UIManager.Instance.inGameController.tutorialController.HideTwistedHand();
            }
        }
    }

    public void ChangePos(GameObject go,
        Vector3 rotate,
        Vector3 position,
        Vector3 scale,
        float duration = 0.7f,
        Action onTransactionActionEnd = null)
    {
        go.transform.DOLocalMove(position, duration).OnComplete(() => { onTransactionActionEnd?.Invoke(); });
        go.transform.DOScale(scale, duration);
        go.transform.DOLocalRotate(rotate, duration);
    }

    public void ChangePos(
        Transform target,
        Transform reference,
        float duration = 0.7f,
        Action onTransactionEndAction = null)
    {
        target.transform.DOLocalMove(reference.localPosition, duration)
            .OnComplete(() => { onTransactionEndAction?.Invoke(); });
        target.DOScale(reference.transform.localScale, duration);
        target.DOLocalRotate(reference.localEulerAngles, duration);
    }

    public void GunLookAtTarget(Vector3 target)
    {
        Vector3 screenPos = mainCamera.WorldToScreenPoint(target);
        Vector3 toolCamConverPos = gunCamera.ScreenToWorldPoint(screenPos);
        gunController.gun.transform.LookAt(toolCamConverPos);
    }

    public Vector3 FromGunCameraToMainCamera(Vector3 postion)
    {
        Vector3 screenPos = gunCamera.WorldToScreenPoint(postion);
        return mainCamera.ScreenToWorldPoint(screenPos);
    }

    public void ResetToolContainer()
    {
        transform.localScale = Vector3.zero;
        PlayerController.tools = ToolPlayer.SCANNER;
    }

    public void ShowTool(float scaleDuration)
    {
        transform.DOScale(1, scaleDuration);
    }

    public void HideTool(float duration)
    {
        transform.DOScale(0, duration);
    }

    void SetLocalPositionZ(Transform transform, float zPos)
    {
        Vector3 localPos = transform.localPosition;
        localPos.z = zPos;
        transform.localPosition = localPos;
    }
    public void ShowPointedAlien()
    {
        
    }

    public void ShowGunGuideArrow()
    {
        guideArrows.SetActive(true);
    }
    public void DestroyTut()
    {
        if (guideArrows != null)
        {
            Destroy(guideArrows);
        }
    }
}
