using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MergeObject: MonoBehaviour
{
    public MergeState status = MergeState.OnGround;
    public PlayerAutoMoveOnNavMesh moveComponent;
    public SkinnedMeshRenderer render;


    public void DoPick()
    {
        status = MergeState.OnPicked;
        moveComponent.DoStop();
    }

    public void DoOnGround()
    {
        status = MergeState.OnGround;
        moveComponent.DoRun();
        
    }

    public void DoStop()
    {
        moveComponent.DoStop();
    }

    public void DoRun()
    {
        if (status != MergeState.OnGround) return;
        moveComponent.DoRun();
    }

    public void DoFloating()
    {
        moveComponent.Floating();
    }

    
}
