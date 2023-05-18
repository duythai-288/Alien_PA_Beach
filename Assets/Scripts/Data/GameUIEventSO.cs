using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Event/GameUIEvent", fileName = "GameUIEvent")]
public class GameUIEventSO : ScriptableObject
{
    private List<GameUIEventListener> listeners = new List<GameUIEventListener>();

    public virtual void StartGameRaise(bool isStartGame)
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
            listeners[i].OnStartGameEventRaised(isStartGame);
    }

    public virtual void EndGameRaise(bool isWin)
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
            listeners[i].OnStartGameEventRaised(isWin);
    }

    public virtual void RegisterListener(GameUIEventListener listener) => listeners.Add(listener);

    public virtual void UnregisterListener(GameUIEventListener listener) => listeners.Remove(listener);
}
