using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MergeObjectData", menuName = "Data/MergeObjectData")]
public class MergeObjectData : ScriptableObject
{
    public BaseMergeObject[] alienData;
    public static MergeObjectData Instance;
}
