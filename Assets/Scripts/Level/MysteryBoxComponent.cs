using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class MysteryBoxComponent : MonoBehaviour
{
    public SpawnMysteryBoxType spawnMysteryBoxType = SpawnMysteryBoxType.DefaultSpawn;
    public MysteryBoxItemType mysteryBoxItemType = MysteryBoxItemType.GunSkin;
    public MysteryBoxLevelType mysteryBoxLevelType = MysteryBoxLevelType.Bronze;

    public float speed;
    public List<Vector3> movePath = new List<Vector3>();
    public float beginPathDelayDuration, completePathDelayDuration;

    private void Start()
    {
        //transform.DOScale(Vector3.one, 1f).SetLoops(-1, LoopType.Yoyo);
        transform.DOMoveY(transform.position.y - 0.5f, 1f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
    }
}
