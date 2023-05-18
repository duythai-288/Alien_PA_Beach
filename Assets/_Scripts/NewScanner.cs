using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class NewScanner : MonoBehaviour
{
    public bool scannerRun = false, scannerStart = false;
    public GameObject scannerObj;
    public Camera mainCam;
    public Vector3 offsetHandle;

    public Transform ActivePos, RestPos;
    private bool _alienCheck = false;


    private void Start()
    {
        // mainCam = Camera.main;
    }

    public void Rest()
    {
        scannerRun = false;
        scannerObj.transform.DOMove(RestPos.position, 1f);
        scannerObj.transform.DOScale(RestPos.localScale, 1f);
        scannerObj.transform.DORotate(RestPos.rotation.eulerAngles,1f);
    }
    
    public void ActiveScan()
    {
        scannerRun = false;
        scannerObj.transform.DOMove(ActivePos.position, 1f);
        scannerObj.transform.DOScale(ActivePos.localScale, 1f);
        scannerObj.transform.DORotate(ActivePos.rotation.eulerAngles,1f);
    }

    private void Update()
    {
        if (!scannerRun) return;

        if (Input.GetMouseButtonUp(0))
        {
            return;
        }

        if (Input.GetMouseButton(0))
        {
            if (!scannerStart)
            {
                GameController.Instance.StartScanner();
                scannerStart = true;
            }

            Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
            Vector3 pos = ray.GetPoint(1);

            Vector3 scannerPos = pos;
            scannerObj.transform.position = Vector3.Lerp(scannerObj.transform.position,
                scannerPos,
                Time.deltaTime * 10);


            if (_alienCheck) return;
            Ray ray2 = mainCam.ScreenPointToRay(Input.mousePosition + new Vector3(0, 80, 0));
            // Debug.DrawLine(mainCam.transform.position, ray2.GetPoint(100), Color.red, 100);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray2, out hitInfo))
            {
                if (hitInfo.collider.gameObject.tag.Equals("Alien"))
                {
                    GameController.Instance.CheckAlien();
                    _alienCheck = true;
                }
            }
        }
    }

   
}