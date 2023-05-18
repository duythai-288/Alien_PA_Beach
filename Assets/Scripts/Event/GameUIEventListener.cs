

using UnityEngine;
using UnityEngine.Events;

public class GameUIEventListener : MonoBehaviour
{
    public GameUIEventSO eventSO;
    public GameUIDataEvent responseStartGame;
    public GameUIDataEvent responseEndGame;

    private void OnEnable() => eventSO.RegisterListener(this);

    private void OnDisable() => eventSO.UnregisterListener(this);

    public void OnStartGameEventRaised(bool isStartGame) => responseStartGame.Invoke(isStartGame);
    public void OnEndGameEventRaised(bool isWin) => responseEndGame.Invoke(isWin);
}

[System.Serializable]
public class GameUIDataEvent : UnityEvent<bool> { }