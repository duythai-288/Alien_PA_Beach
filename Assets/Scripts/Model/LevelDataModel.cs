using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class LevelDataModel
{
    [SerializeField] EnvironmentModel environmentModel = new EnvironmentModel();
    [SerializeField] GamePath cameraPath = new GamePath();
    [SerializeField] List<GroupSubjectModel> groupSubject;

    public EnvironmentModel EnvironmentModel
    {
        get => EnvironmentModel;
        set => EnvironmentModel = value;
    }
    public PathCamModel PathCamModel
    {
        get => PathCamModel;
        set => PathCamModel = value;
    }
    public List<GroupSubjectModel> GroupSubject
    {
        get => groupSubject;
        set => groupSubject = value;
    }
    public override string ToString()
    {
        return $"environmentModel {environmentModel} pathCamModel {cameraPath} groupSubject {groupSubject}";
    }
}
