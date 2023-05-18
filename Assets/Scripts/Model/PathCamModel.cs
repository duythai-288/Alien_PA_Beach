using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PathCamModel
{
    public Vector3 position;
    public Vector3[] pathFollowing;
    
    public override string ToString()
    {
        return $"{pathFollowing} {position}";
    }

}
