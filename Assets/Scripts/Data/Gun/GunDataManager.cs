using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GunDataManager", menuName = "Data/GunDataManager")]
public class GunDataManager : ScriptableObject
{
    public GunDataSO[] guns;
}
