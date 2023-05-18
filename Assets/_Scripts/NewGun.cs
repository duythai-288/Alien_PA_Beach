using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class NewGun : MonoBehaviour
{

    public bool canFire = false;
    public GameObject gunObj;
    public Transform ActivePos, RestPos;
    public Camera mainCam;
    public Bullet beamBullet;
    public Transform gunHead;

    private int bulletFire = 0;
    public void GunActive()
    {
        canFire = true;
        gunObj.transform.DOMove(ActivePos.position, 1f);
        gunObj.transform.DOScale(ActivePos.localScale, 1f);
        gunObj.transform.DORotate(ActivePos.rotation.eulerAngles,1f);

    }
    
    public void Rest()
    {
        canFire = false;
        gunObj.transform.DOMove(RestPos.position, 1f);
        gunObj.transform.DOScale(RestPos.localScale, 1f);
        gunObj.transform.DORotate(RestPos.rotation.eulerAngles,1f);
    }

    private void Update()
    {
        if(!canFire) return;

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray2 = mainCam.ScreenPointToRay(Input.mousePosition );
            // Debug.DrawLine(mainCam.transform.position, ray2.GetPoint(100), Color.red, 100);
            RaycastHit hitInfo;
            bulletFire++;
            if (Physics.Raycast(ray2, out hitInfo))
            {
                if (hitInfo.collider.gameObject.tag.Equals("Alien"))
                {
                    Fire(hitInfo.transform);
                }
            }
        }
    }

    private void Fire(Transform target)
    {
        Debug.Log($"Fire");
        Luna.Unity.Analytics.LogEvent("fire_alien", 1);
        AudioController.Instance.PlayOne(1);
        var beam = Instantiate(beamBullet);
        beam.Initialize(gunHead.position,
            target.position - 2 * Vector3.up);

        Destroy(beam.gameObject, 1.2f);
        target.gameObject.TryGetComponent<AlienDead>(out AlienDead alien);
        if (alien)
        {
            alien.AlienDeadAnim();
            GameController.Instance.UI.NoSuggest(2);
            Luna.Unity.Analytics.LogEvent(Luna.Unity.Analytics.EventType.LevelWon, bulletFire);
        }
    }

    
}
