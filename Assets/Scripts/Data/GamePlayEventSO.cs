using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Event/GamePlayEvent", fileName = "GamePlayEvent")]
public class GamePlayEventSO : ScriptableObject
{
    private List<GamePlayEventListener> listeners = new List<GamePlayEventListener>();

    public virtual void SetCamPathRaise(GamePath cameraPath)
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
            listeners[i].OnGetCamPathEventRaised(cameraPath);
    }

    public virtual void SetEnvironmentRaise(EnvironmentModel environment)
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
            listeners[i].OnGetEnvironmentRaised(environment);
    }

    public virtual void RegisterListener(GamePlayEventListener listener) => listeners.Add(listener);

    public virtual void UnregisterListener(GamePlayEventListener listener) => listeners.Remove(listener);
}
