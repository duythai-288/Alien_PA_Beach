using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SubjectModel
{
    public Vector3 position;
    public Vector3 rotation;
    public bool isAlien;

    public CharacterEnum characterType = CharacterEnum.Army;

    [Header("Emotion")]
    public EmotionEnum emotion = EmotionEnum.Smile;

    [Header("Scary")]
    public ScaryEnum scaryType = ScaryEnum.None;
    public Vector3 scaryPosition;
    public Vector3 scaryRotation;

    [Header("Move")]
    public MoveType moveType = MoveType.None;
    public float speed;
    public int timeLoop;
    public List<Vector3> movePath = new List<Vector3>();
    public float beginPathDelayDuration, completePathDelayDuration;

    [Header("Animation")]
    public CharacterAnimationEnum startAnimation;
    public CharacterAnimationEnum beginPathAnimation = CharacterAnimationEnum.Movement, completePathAnimation = CharacterAnimationEnum.Idle;

    public bool isChildren
    {
        get
        {
            switch (characterType)
            {
                case CharacterEnum.Female_childe:
                    return true;
                default:
                    return false;
            }
        }
    }

    public bool isSitting
    {
        get
        {
            switch (startAnimation)
            {
                case CharacterAnimationEnum.Mix_Sit_Idle:
                case CharacterAnimationEnum.Female_Typing_On_Chair:
                case CharacterAnimationEnum.Male_Laugh_On_Chair:
                case CharacterAnimationEnum.Pull_Plant:
                case CharacterAnimationEnum.Pull_Plant_Fast:
                case CharacterAnimationEnum.Plant_A_Plant:
                case CharacterAnimationEnum.Sitting_Shake_Leg:
                case CharacterAnimationEnum.Male_Nod_Sit:
                case CharacterAnimationEnum.Sitting_Clap:
                case CharacterAnimationEnum.Stay_Down:
                    return true;
                default:
                    return false;
            }
        }
    }

    public bool isLayDown
    {
        get
        {
            switch (startAnimation)
            {
                case CharacterAnimationEnum.Sitting_Back:
                case CharacterAnimationEnum.Sleeping:
                case CharacterAnimationEnum.Convulsing:
                case CharacterAnimationEnum.Flying:
                case CharacterAnimationEnum.Push_Up:
                case CharacterAnimationEnum.Electric_Death:
                    return true;
                default:
                    return false;
            }
        }
    }

    public bool isDucking
    {
        get
        {
            switch (startAnimation)
            {
                case CharacterAnimationEnum.Female_Idle_Meditate:
                case CharacterAnimationEnum.Crouch:
                case CharacterAnimationEnum.Ducking:
                case CharacterAnimationEnum.Ducking_Loop:
                case CharacterAnimationEnum.Flair:
                    return true;
                default:
                    return false;
            }
        }
    }
}

