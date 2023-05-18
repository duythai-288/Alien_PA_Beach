using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterAnimationEventInvoke : MonoBehaviour
{
    public void DoCharacterTalk(string s)
    {
        Debug.Log("PrintEvent: " + s + " called at: " + Time.time);
    }

    public void StartTalking()
    {

    }
}
