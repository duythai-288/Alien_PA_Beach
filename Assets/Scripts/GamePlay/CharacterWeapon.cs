using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterWeapon : MonoBehaviour
{
    public GameObject gunPrefab;
    public Transform gunHolder;

    public void DrawGun()
    {
        GameObject gun = Instantiate(gunPrefab, gunHolder);
        gun.transform.localScale = Vector3.one * 3;
        gun.transform.SetLayer(StringConstant.DEFAULT_LAYER);
    }
}
