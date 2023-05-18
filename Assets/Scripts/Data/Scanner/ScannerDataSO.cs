using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScannerData", menuName = "Data/ScannerData")]
public class ScannerDataSO : ScriptableObject
{
    public int id;
    public Sprite icon;
    public GameObject prefab;
    public Mesh scannerMesh;
    public Material scannerMaterial;
    public Vector3 screenPos;
    public Vector3 screenScale;
    public UnlockSlotType unlockType;
    public int price;
    public bool unlock;
}
