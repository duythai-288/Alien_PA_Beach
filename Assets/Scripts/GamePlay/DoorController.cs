using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoorController : MonoBehaviour
{
    public Transform doorLeft;
    public Transform doorRight;
    public Transform doorSlideRight;
    public Transform doorSlideLeft;
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag.Equals(StringConstant.PLAYER_TAG))
        {
            if (doorLeft != null)
            {
                doorLeft.DOLocalRotate(new Vector3(0, 135, 0), 1.5f);
            }
            if (doorRight != null)
            {
                doorRight.DOLocalRotate(new Vector3(0, -135, 0), 1.5f);
            }
            if (doorSlideRight != null)
            {
                doorSlideRight.DOLocalMove(new Vector3(doorSlideRight.localPosition.x - 1.4f, doorSlideRight.localPosition.y, doorSlideRight.localPosition.z), 1.5f);
            }
            if (doorSlideLeft != null)
            {
                doorSlideLeft.DOLocalMove(new Vector3(doorSlideLeft.localPosition.x + 1.4f, doorSlideLeft.localPosition.y, doorSlideLeft.localPosition.z), 1.5f);
            }
        }
    }
}
