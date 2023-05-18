using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class UFOController : MonoBehaviour
{
    public Transform ufoTransform;
    public Vector3 farPosition, nearPosition;
    public float inDuration, outDuration, abductorBeamDuration, dropDuration = 3;

    public float outterOpacity, innerOpacity;
    public MeshRenderer outterBeam, innerBeam;

    public float intensity = 15f;
    public Light light;

    public MergeObject mergeObject;
    public ParticleSystem dust;

    

    public void GoClose()
    {
        ufoTransform.gameObject.SetActive(true);
        ResetUFO();
        ufoTransform.DOMove(nearPosition, inDuration).OnComplete(() => 
        {
            AppearAbductorBeam();
            
        });
    }

    public void GoFar()
    {
        ufoTransform.DOMove(farPosition, outDuration).OnComplete(() =>
        {
            ufoTransform.gameObject.SetActive(false);
            dust.gameObject.SetActive(false);
        });
    }

    void AppearAbductorBeam()
    {
        Action onEndAppearAction = () =>
        {
            mergeObject.gameObject.SetActive(true);
            mergeObject.DoFloating();
            mergeObject.transform.position = ufoTransform.position;
            mergeObject.transform.DOMove(Vector3.zero, dropDuration)
            .SetEase(Ease.Linear)
            .OnComplete(() => 
            {
                mergeObject.DoStop();
                DisapearAbductorBeam(() => GoFar());
                
            });
            
        };
        light.DOIntensity(intensity, abductorBeamDuration);
        dust.gameObject.SetActive(true);
        dust.Play();
        StartCoroutine(IEAppearBeam(onEndAppearAction));
    }

    IEnumerator IEAppearBeam(Action onEndAppearAction)
    {
        float elaspedTime = 0;
        Color color = Color.white;
        WaitForEndOfFrame waitForEndOfFrame = new WaitForEndOfFrame();
        float ratio = 0;
        string colorProperties = "_BaseColor";
        Material outterMat = outterBeam.sharedMaterial;
        Material innerMat = innerBeam.sharedMaterial;
        while (elaspedTime <= abductorBeamDuration)
        {
            ratio = elaspedTime / abductorBeamDuration;
            color.a = ratio * outterOpacity;
            outterMat.SetColor(colorProperties, color);
            color.a = ratio * innerOpacity;
            innerMat.SetColor(colorProperties, color);
            elaspedTime += Time.deltaTime;
            yield return waitForEndOfFrame;
        }

        onEndAppearAction?.Invoke();
    }

    void DisapearAbductorBeam(Action onEndAction)
    {
        light.DOIntensity(0, abductorBeamDuration);
        dust.Stop();
        StartCoroutine(IEDisappearBeam(onEndAction));
    }

    IEnumerator IEDisappearBeam(Action onEndAction)
    {
        float elaspedTime = 0;
        Color color = Color.white;
        WaitForEndOfFrame waitForEndOfFrame = new WaitForEndOfFrame();
        float ratio = 0;
        string colorProperties = "_BaseColor";
        Material outterMat = outterBeam.sharedMaterial;
        Material innerMat = innerBeam.sharedMaterial;
        while (elaspedTime <= abductorBeamDuration)
        {
            ratio = 1 - elaspedTime / abductorBeamDuration;
            color.a = ratio * outterOpacity;
            outterMat.SetColor(colorProperties, color);
            color.a = ratio * innerOpacity;
            innerMat.SetColor(colorProperties, color);
            elaspedTime += Time.deltaTime;
            yield return waitForEndOfFrame;
        }
        onEndAction?.Invoke();
    }

    void ResetUFO()
    {
        Material outterMat = outterBeam.sharedMaterial;
        Material innerMat = innerBeam.sharedMaterial;
        Color color = Color.white;
        color.a = 0;
        outterMat.SetColor("_BaseColor", color);
        innerMat.SetColor("_BaseColor", color);
        light.intensity = 0;
    }
}
