using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionComponent : MonoBehaviour
{
    public MergeObject mergeObject;
    public void OnTriggerEnter(Collider other)
    {
        mergeObject.DoRun();
    }
}
