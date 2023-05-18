using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergeController : MonoBehaviour
{
    public List<MergeObject> mergeObjects = new List<MergeObject>();
    public MergeObjectData mergeObjectData;

    private void Awake()
    {
        MergeObjectData.Instance = mergeObjectData;
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
