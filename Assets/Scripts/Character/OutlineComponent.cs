using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineComponent : MonoBehaviour
{
    public SkinnedMeshRenderer render;

    float outlineWidth = 0.05f;

    public IEnumerator ShowOutline()
    {

        if (render != null)
        {
            WaitForSeconds waitForSeconds = new WaitForSeconds(0.01f);
            Material material = render.material;
            float outlineStep = 0;
            while (outlineStep <= outlineWidth)
            {
                yield return waitForSeconds;
                outlineStep += 0.01f / 10;
                material.SetFloat("_OutlineWidth", outlineStep);
            }
            PlayerController.Instance.isDetected = true;
        }
    }
}
