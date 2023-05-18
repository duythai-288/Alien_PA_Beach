using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
// using RenderPipeline = UnityEngine.Rendering.RenderPipelineManager;

public class CamManager : MonoBehaviour
{
	//public Camera cameraA;
	public Camera cameraB;
    public Camera mainCamera;

	//public Material cameraMatA;
	public Material cameraMatB;
    public RenderTexture tempTexture;
    static bool isActiveScanner = false;
    public const int delayRender = 0;
    public static int renderCount = 0;

    public void Start()
    {
        tempTexture = new RenderTexture(Screen.width, Screen.height, 2);
        cameraMatB.mainTexture = tempTexture;
        cameraB.targetTexture = tempTexture;
        //Application.targetFrameRate = 60;
    }

    public void ActiveScanner()
    {
        if (isActiveScanner) return;
        isActiveScanner = true;
        renderCount = 2;
        // RenderPipeline.beginCameraRendering += UpdateCamera;
    }

    public void DeactiveScanner()
    {
        if (!isActiveScanner) return;
        isActiveScanner = false;
        // RenderPipeline.beginCameraRendering -= UpdateCamera;
    }

    // void UpdateCamera(ScriptableRenderContext SRC, Camera camera)
    // {
    //     if (camera != mainCamera) return;
    //     if (renderCount < delayRender)
    //     {
    //         renderCount++;
    //         return;
    //     }
    //     else renderCount = 0;
    //     // UniversalRenderPipeline.RenderSingleCamera(SRC, cameraB);
    // }
}
