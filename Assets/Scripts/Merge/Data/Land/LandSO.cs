using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Land", menuName ="Data/Land/Land SO")]
public class LandSO : ScriptableObject
{
    public int id;
    public GameObject prefab;
    public int price;
}
