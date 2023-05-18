using System.Collections;
using DG.Tweening;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public static bool isGunAvailable = false;

    private PlayerController playerManager;
    private bool movePlayer;

    public Transform spawnerTransform => gun.barrelTransform;
    public Transform posA, posB, posC;
    public GameObject arrowPoint;
    public ToolController toolControl;
    public Gun gun;
    public Transform activeTransform;
    public Transform restTransform;
    Vector3 pointDownPos;

    void Start()
    {
        playerManager = PlayerController.Instance;
        ResetGun();
    }

    private void Update()
    {
        if (PlayerController.tools == ToolPlayer.GUN && isGunAvailable && playerManager.isStartGame && PlayerController.isFocusPlayGame)
        {
            MoveFreeCam();
        }
    }

    public void ShootAlien()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            // GameAnalytics.ToolUserDetect(TOOL_STATE.SHOOT);
            var selection = hit.transform;

            if (selection.tag.Equals("Alien") || selection.tag.Equals("Human"))
            {
                // Vibration.VibrateRhythm();
                SoundManager.instance.PlaySingle(SoundType.LaserGun);
                // CharacterComponent characterComponent = selection.GetComponent<CharacterComponent>();
                // CrowdController crowdController = selection.parent.GetComponent<CrowdController>();
                // if (!characterComponent.isTakeDown)
                // {
                //     PlayerController.tools = ToolPlayer.DEFAULT;
                //     if (selection.m_tag.Equals("Alien"))
                //     {
                //         crowdController.memberDown += 1;
                //         GameManager.Instance.totalAlienDown += 1;
                //         GameManager.Instance.earnedCoin += IntConstant.COIN_EARN;
                //         selection.GetComponent<BoxCollider>().enabled = false;
                //         if (crowdController.AlienGetShoot())
                //         {
                //             // StartCoroutine(crowdController.transform.parent.GetComponent<AlienLevel>().ShowMysteryBox());
                //         }
                //     }
                //     else if (selection.m_tag.Equals("Human"))
                //     {
                //         playerManager.isStartGame = false;
                //         GameManager.Instance.earnedCoin = 0;
                //         crowdController.AlienShowUp();
                //         // crowdController.transform.parent.GetComponent<AlienLevel>().HumanGetShoot();
                //         StartCoroutine(PlayerController.Instance.HideTool());
                //         // StartCoroutine(UIManager.Instance.LoseGame());
                //     }
                //     characterComponent.isTakeDown = true;
                //     characterComponent.OnShockWave();
                //     characterComponent.StopMoving();
                //     ShootObject(selection);
                // }
            }
            else if (selection.tag.Equals("MysteryBox"))
            {
                GameManager.Instance.boxHasOpened += 1;
                MysteryBoxComponent mysteryBox = selection.parent.GetComponent<MysteryBoxComponent>();
                if (GameManager.Instance.boxHasOpened >= GameManager.Instance.numberMysteryBox)
                {
                    PlayerController.Instance.isStartGame = false;
                    StartCoroutine(PlayerController.Instance.HideTool());
                    // StartCoroutine(UIManager.Instance.WinGame(GameManager.Instance.totalAlien));
                }
                ShootObject(selection);
            }
        }
    }

    private void ShootObject(Transform transform)
    {
        toolControl.GunLookAtTarget(transform.position + Vector3.up);
        Bullet beam = Instantiate(playerManager.beam);
        beam.Initialize(toolControl.FromGunCameraToMainCamera(spawnerTransform.position),
            transform.position + Vector3.up);

        Destroy(beam.gameObject, 1.2f);
    }

    public void MoveFreeCam()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShootAlien();
            pointDownPos = Input.mousePosition;
            movePlayer = true;
            // UIManager.Instance.inGameController.guideTxt.DOScale(0, UIManager.Instance.scaleDur).SetEase(Ease.InOutSine);
        }
        if (Input.GetMouseButtonUp(0))
        {
            movePlayer = false;
        }
        if (movePlayer && Mathf.Abs(Input.mousePosition.x - pointDownPos.x) > 35 && PlayerPrefsManager.IsLevelBonus == 0)
        {
            float mousePosX = Input.mousePosition.x;
            float mousePosXDelta = mousePosX - pointDownPos.x;
            float force = Mathf.Clamp01((Mathf.Abs(mousePosX) - 35) / 50);
            if (mousePosXDelta < 0)
            {
                PlayerController.Instance.DoRotate(force, true);
            }
            else if (mousePosXDelta > 0)
            {
                PlayerController.Instance.DoRotate(force, false);
            }
        }
    }

    public void ShowGun(float duration, bool isRest = true)
    {
        ResetGun();
        transform.localScale = Vector3.one;
        transform.localPosition = Vector3.zero;
        gun.transform.localPosition = isRest ? restTransform.localPosition : activeTransform.localPosition;
        gun.transform.localEulerAngles = isRest ? restTransform.localEulerAngles : activeTransform.localEulerAngles;
        gun.transform.DOScale(isRest ? restTransform.localScale : activeTransform.localScale, duration);

    }
    public void HideGun(float duration, bool isRest = true)
    {
        gun.transform.DOScale(0, duration);
    }
    public void ResetGun(bool isRest = true)
    {
        movePlayer = false;
        gun.transform.localScale = Vector3.zero;
        gun.transform.localPosition = restTransform.localPosition;
        gun.transform.localEulerAngles = restTransform.localEulerAngles;
    }
}
