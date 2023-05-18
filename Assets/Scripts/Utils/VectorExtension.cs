using System.Collections.Generic;
using UnityEngine;

public static class VectorExtension
{
    public static float GetDuration(this Vector3[] path, float speed)
    {
        float distance = 0;
        for (int i = 0; i < path.Length - 1; ++i)
        {
            distance += Vector3.Distance(path[i], path[i + 1]);
        }
        return distance / speed;
    }

    public static float GetDuration(this List<Vector3> path, float speed)
    {
        float distance = 0;
        for (int i = 0; i < path.Count - 1; ++i)
        {
            distance += Vector3.Distance(path[i], path[i + 1]);
        }
        return distance / speed;
    }

    public static float GetDuration(this List<Vector3> path, Vector3 start, float speed)
    {
        if (path.Count == 0) return 0;

        float distance = Vector3.Distance(path[0], start);
        for (int i = 0; i < path.Count - 1; ++i)
        {
            distance += Vector3.Distance(path[i], path[i + 1]);
        }
        return distance / speed;
    }

    public static Vector3[] GetTransformPath(this Vector3[] path, Vector3 vector, bool isLoop = false)
    {
        List<Vector3> transformedPath = new List<Vector3>();
        for (int i = 0; i < path.Length; ++i) transformedPath.Add(path[i] + vector);
        if (isLoop) transformedPath.Add(transformedPath[0]);
        return transformedPath.ToArray();
    }

    public static Vector3[] GetTransformPath(this List<Vector3> path, Vector3 vector, bool isLoop = false)
    {
        List<Vector3> transformedPath = new List<Vector3>();
        for (int i = 0; i < path.Count; ++i) transformedPath.Add(path[i] + vector);
        if (isLoop) transformedPath.Add(transformedPath[0]);
        return transformedPath.ToArray();
    }

    public static (float, float) GetRangeAngle(this Vector2 root, List<Vector2> positions)
    {
        if (positions.Count < 2) return (0, 360);
        List<float> listAngles = new List<float>();
        for (int i = 0; i < positions.Count; ++i)
        {
            Vector2 toVector = positions[i] - root;
            listAngles.Add(Vector2.SignedAngle(Vector2.right, toVector));
        }
        listAngles.Sort();

        float maxAngle = listAngles[0] + 360 - listAngles[listAngles.Count - 1];
        int iMin = 0;
        
        if (maxAngle < 180)
        {
            for (int i = 0; i < listAngles.Count - 1; ++i)
            {
                float deltaAngle = listAngles[i + 1] - listAngles[i];

                if (deltaAngle > maxAngle)
                {
                    maxAngle = deltaAngle;
                    iMin = i + 1;
                }
                if (maxAngle >= 180) break;
            }
        }
        
        float rangeAngle = 360 - maxAngle;

        float min = listAngles[iMin];
        float max = min + rangeAngle;
        return (min, max);
    }

    public static float LimitAngleTo360(this float angle)
    {
        if (angle >= 0 && angle <= 360) return angle;
        float sign = Mathf.Sign(angle);
        int gap = (int)(angle / 360f) + (sign < 0 ? 1 : 0);
        angle -= 360 * gap * sign;
        return angle;
    }
}
