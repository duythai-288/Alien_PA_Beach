using UnityEngine;

[System.Serializable]
public class GroupSubjectModel
{
    public Vector3 position = Vector3.zero;
    public int numberSubject;
    public int numberAlien;
    public SubjectModel[] subjects;
    
    public Vector3[] escapePath;

    public override string ToString()
    {
        return $"{numberSubject} {numberAlien}";
    }

}
