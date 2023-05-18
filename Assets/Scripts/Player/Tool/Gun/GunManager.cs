using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GunManager : MonoBehaviour
{
    public GunDataManager gunManager;
    PlayerController gameManager;
    void Start()
    {
        gameManager = PlayerController.Instance;
        int iGun = PlayerPrefsManager.CurrentGun;
        GenerateGun(iGun);
    }

    public bool SetUnlockProgressScanner()
    {
        return false;
    }

    public void GenerateGun(int iGun)
    {
        // Destroy(gameManager.gunController.gun.gameObject);
        // GameObject gun = Instantiate(gunManager.guns[iGun].prefab, transform);
        // gameManager.beam = gunManager.guns[iGun].beam.GetComponent<Bullet>();
        // gameManager.gunController.gun = gun.GetComponent<Gun>();
        // transform.localPosition = gunManager.guns[iGun].prefab.transform.localPosition;
    }

}
