using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GunData", menuName = "Data/GunData")]
public class GunDataSO : ScriptableObject
{
    public int id;
    public Vector3 position;
    public Vector3 rotation;
    public Sprite icon;
    public GameObject prefab;
    public Material gunMaterial;
    public GameObject beam;
    public UnlockSlotType unlockType;
    public int price;
    public bool unlock;
}
