using UnityEngine;

[System.Serializable]
public class MysteryBoxModel
{
    public SpawnMysteryBoxType spawnMysteryBoxType;
    public MysteryBoxItemType mysteryBoxItemType;
    public MysteryBoxLevelType mysteryBoxLevelType;
    public Vector3 position, rotation;

    public float speed;
    public Vector3[] movePath;
    public float beginPathDelayDuration, completePathDelayDuration;
}
