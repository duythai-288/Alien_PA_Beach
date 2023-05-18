using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Slot", menuName = "Data/Bag Slot")]
public class BagSlotSO : ScriptableObject
{
    public int id;
    public UnlockSlotType unlockType;
    public int price;
}