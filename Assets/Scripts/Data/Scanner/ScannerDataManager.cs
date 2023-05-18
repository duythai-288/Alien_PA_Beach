using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScannerDataManager", menuName = "Data/ScannerDataManager")]
public class ScannerDataManager : ScriptableObject
{
    public ScannerDataSO[] scanners;
}
