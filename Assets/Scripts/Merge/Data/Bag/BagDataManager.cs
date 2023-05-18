using UnityEngine;

[CreateAssetMenu(fileName = "BagDataManager", menuName = "Data/Bag Manager")]
public class BagDataManager : ScriptableObject
{
    public BagSlotSO[] slots;

    public bool CheckSlotUnlocked(int id)
    {
        return true;
    }

    public SlotStatus GetSlotStatus(int id)
    {
        return SlotStatus.Unlocked;
    }

//#if UNITY_EDITOR
//    [MyBox.ButtonMethod]
//    public void SetBagSlotID()
//    {
//        for (int i = 0; i < slots.Length; ++i) slots[i].id = i;

//        UnityEditor.AssetDatabase.Refresh();
//        UnityEditor.AssetDatabase.SaveAssets();
//    }
//#endif
}
