using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LandDataManager", menuName = "Data/Land/Land Manager")]
public class LandDataManager : ScriptableObject
{
    public LandSO[] lands;
}
