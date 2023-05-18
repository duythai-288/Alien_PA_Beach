using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class ScannerManager : MonoBehaviour
{
    public ScannerDataManager scannerManager;
    public Scanner scanner;
    //public GameObject gunMesh;
    public Transform onScreen => scanner.onScreen.transform;
    public Transform offScreen => scanner.offScreen.transform;
    public Transform noInternet => scanner.noInternet.transform;

    public Transform holoScreen => scanner.holoScreen.transform;
    PlayerController gameManager;

    void Start()
    {
        gameManager = PlayerController.Instance;
        int iScanner = PlayerPrefsManager.CurrentScanner;
        GenerateScanner(iScanner);
    }

    public void GenerateScanner(int iScanner)
    {
        // Destroy(gameManager.scannerController.scanner.gameObject);
        // GameObject scanner = Instantiate(scannerManager.scanners[iScanner].prefab, transform);
        // gameManager.scannerController.scanner = scanner.GetComponent<Scanner>();
        // transform.localPosition = scannerManager.scanners[iScanner].prefab.transform.localPosition;
    }
}
