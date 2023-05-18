using UnityEngine.EventSystems;
using UnityEngine;
using DG.Tweening;

public class ScannerController : MonoBehaviour
{
    public static bool isScannerAvailable;

    public Scanner scanner;
    public Transform activeTransform;
    public Transform restTransform;

    private PlayerController playerManager;
    private bool movePlayer;


    #region Properties
    public CamManager cameraManager => playerManager.camManager;
    Camera toolCam => playerManager.toolCam;
    #endregion
    public Transform posA, posB, posC;
    Plane plane;
    RaycastHit hit;
    Ray ray;

    // Start is called before the first frame update
    void Start()
    {
        playerManager = PlayerController.Instance;
        plane = new Plane();
        ResetScanner();
    }

    // Update is called once per frame
    void Update()
    {
        MoveScanner();
    }

    private void MoveScanner()
    {
        if (PlayerController.tools == ToolPlayer.SCANNER && isScannerAvailable && playerManager.isStartGame && PlayerController.isFocusPlayGame)
        {
            if (Input.GetMouseButtonDown(0))
            {
                CheckingInternet();
                StartScan();
                movePlayer = true;
            }
            if (Input.GetMouseButtonUp(0))
            {
                movePlayer = false;
            }
            if (movePlayer)
            {
                plane.Set3Points(posA.position, posB.position, posC.position);
                Ray ray = toolCam.ScreenPointToRay(Input.mousePosition);
                float enter;
                if (plane.Raycast(ray, out enter))
                {
                    Vector3 hitPoint = ray.GetPoint(enter);
                    scanner.transform.position = Vector3.Lerp(scanner.transform.position,
                        hitPoint + scanner.offsetHandle,
                        Time.deltaTime * 10);
                }
                PointingAlien();
            }
        }
    }

    private void LateUpdate()
    {
        if (movePlayer && PlayerController.isFocusPlayGame)
        {
            float mousePosX = Input.mousePosition.x;
            if (mousePosX < 100)
            {
                float force = Mathf.Clamp01(mousePosX / 50);

                PlayerController.Instance.DoRotate(force, true);

            }
            else if (Mathf.Abs(toolCam.pixelWidth - mousePosX) < 100)
            {
                float force = Mathf.Clamp01(Mathf.Abs(toolCam.pixelWidth - mousePosX) / 50);
                PlayerController.Instance.DoRotate(force, false);
            }
        }
    }

    public void ShowScanner(float duration, bool isRest)
    {
        ResetScanner();
        transform.localScale = Vector3.one;
        transform.localPosition = Vector3.zero;
        scanner.transform.localPosition = isRest ? restTransform.localPosition : activeTransform.localPosition;
        scanner.transform.localEulerAngles = isRest ? restTransform.localEulerAngles : activeTransform.localEulerAngles;
        scanner.transform.DOScale(isRest ? restTransform.localScale : activeTransform.localScale, duration);
    }

    public void HideScanner(float duration)
    {
        scanner.transform.DOScale(0, duration);
    }

    public void ResetScanner()
    {
        if (scanner != null)
        {
            scanner.transform.localScale = Vector3.zero;
            scanner.transform.localPosition = activeTransform.localPosition;
            scanner.transform.localEulerAngles = activeTransform.localEulerAngles;
        }
    }

    public void StartScan()
    {
        if (PlayerController.isStartCheckAline)
        {

            // GameAnalytics.ToolUserDetect(TOOL_STATE.SCAN);
            scanner.ActiveScreen();
            //Add logic no internet here
            scanner.transform.DOLocalRotate(Vector3.zero, 0.1f).OnComplete(() =>
            {
                isScannerAvailable = true;
                SoundManager.instance.PlayNoise(SoundType.Scanner);
                cameraManager.ActiveScanner();
            });
            scanner.transform.DOScale(activeTransform.localScale * 0.9f, 0.1f);
            if (!GameManager.Instance.isPassTut)
            {
                // UIManager.Instance.inGameController.tutorialController.HideTwistedHand();
            }
        }
    }

    void PointingAlien()
    {
        if (!GameManager.Instance.isPassTut)
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.tag.Equals(StringConstant.ALIEN_TAG))
                {
                    playerManager.tool.ShowGunGuideArrow();
                    // playerManager.pointedAlien = hit.collider.gameObject.GetComponent<CharacterComponent>();
                }
            }
        }
    }

    void CheckingInternet()
    {
        // if (PlayerPrefsManager.CurrentIndex >= 3)
        // {
        //     // _ = CheckInternet.Instance.CheckInternetConnectionAsync(isConnected =>
        //     {
        //         if (isConnected)
        //         {
        //             scanner.ActiveInternet();
        //             Debug.Log("Internet Available!");
        //         }
        //         else
        //         {
        //             scanner.NoInternetScanner();
        //             // CheckInternet.Instance.ShowPanelNoInternet();
        //             Debug.Log("Internet Not Available");
        //
        //         }
        //     });
        // }
    }
}
