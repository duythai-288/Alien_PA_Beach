using System;
using UnityEngine;
using UnityEngine.Events;

public class GamePlayEventListener : MonoBehaviour
{
    public GamePlayEventSO eventSO;
    public GamePathDataEvent responsePath;
    public GameEnvironmentDataEvent responseEnvi;

    private void OnEnable() => eventSO.RegisterListener(this);

    private void OnDisable() => eventSO.UnregisterListener(this);

    public void OnGetCamPathEventRaised(GamePath cameraPath) => responsePath.Invoke(cameraPath);

    public void OnGetEnvironmentRaised(EnvironmentModel environment) => responseEnvi.Invoke(environment);
}

[System.Serializable]
public class GamePathDataEvent : UnityEvent<GamePath> { }

[System.Serializable]
public class GameEnvironmentDataEvent : UnityEvent<EnvironmentModel> { }
