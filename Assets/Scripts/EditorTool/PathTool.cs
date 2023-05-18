using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PathTool : MonoBehaviour
{
    public float anchorHandleSize = 0.15f;
    public bool editView;
    public bool isLoop;
    public List<Vector3> points = new List<Vector3>();

    public Action<int, Vector3> updatePosition;
    Vector3 root;

    public void SetPoints(Vector3[] points, Vector3 root)
    {
        this.root = root;
        var pointList = new List<Vector3>();
        for (int i = 0; i < points.Length; ++i) pointList.Add(points[i] + root);
        this.points = pointList;
    }

    public void UpdatePoint(int index, Vector3 position, bool invokeAction = true)
    {
        points[index] = position;
        if(invokeAction)
            updatePosition?.Invoke(index, position - root);
    }

}
