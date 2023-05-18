using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ToolChange : MonoBehaviour, IPointerClickHandler
{
    private bool _canChangeTool = false;

    public void ActiveGun() => _canChangeTool = true;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (!_canChangeTool) return;

        Debug.Log($"change gun");
        _canChangeTool = false;
        GameController.Instance.ChangeGun();
    }
}
