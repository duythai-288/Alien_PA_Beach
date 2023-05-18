using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeviceInfo : MonoBehaviour
{
    // Start is called before the first frame update
    const string pluginName = "com.monster.unity3d.detectdevice.DetectDevicePlugin";

    static AndroidJavaClass pluginClass;
    static AndroidJavaObject pluginInstance;

    public static AndroidJavaClass PluginClass
    {
        get
        {
            if (pluginClass == null)
            {
                pluginClass = new AndroidJavaClass(pluginName);
            }
            return pluginClass;
        }
    }

    public static AndroidJavaObject PluginInstance
    {
        get
        {
            if (pluginInstance == null)
            {
                pluginInstance = PluginClass.CallStatic<AndroidJavaObject>("getInstance");
            }
            return pluginInstance;
        }
    }

    private void Start()
    {
        GetFPSPerDevice();
    }

    public void GetFPSPerDevice()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            Application.targetFrameRate = PluginInstance.Call<int>("frameRateDevice");
            Debug.Log("Check FPS: " + Application.targetFrameRate);
        }
    }
}
