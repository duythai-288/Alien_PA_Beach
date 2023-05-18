using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Level", fileName = "Level")]
public class LevelDataSO : ScriptableObject
{
    public EnvironmentModel environmentModel;
    public GamePath cameraPath = new GamePath();
    // [NonReorderable]
    // public GroupSubjectModel[] groups;
    // [NonReorderable]
    // public DecorateAssetModel[] decorations;
    // [NonReorderable]
    // public MysteryBoxModel[] mysteryBoxes;
    //
    // public void Init(LevelDataSO data)
    // {
    //     environmentModel = data.environmentModel;
    //     cameraPath = data.cameraPath;
    //     groups = data.groups;
    //     decorations = data.decorations;
    //     mysteryBoxes = data.mysteryBoxes;
    // }
}
