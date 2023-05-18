//using UnityEngine;
//using System.Collections;

//public class HandHeld : MonoBehaviour
//{
//    public float PositionFrequency = 0.4f;
//    public float RotationFrequency = 0.3f;
//    public Vector3 PositionStrength = new Vector3(0.2f, 0.2f, 0);
//    public Vector3 RotationStrength = new Vector3(0, 0, 0.2f);
//    private float seed;

//    private void Awake()
//    {
//        seed = Random.value;
//    }

//    private void LateUpdate()
//    {
//        if (!PlayerController.Instance.isHandheld) return;

//        Camera.main.transform.localPosition = new Vector3(
//            PositionStrength.x * (Mathf.PerlinNoise(seed, Time.time * PositionFrequency) - 0.5f),
//            PositionStrength.y * (Mathf.PerlinNoise(seed + 1, Time.time * PositionFrequency) - 0.5f),
//            PositionStrength.z * (Mathf.PerlinNoise(seed + 2, Time.time * PositionFrequency) - 0.5f)
//        );
//    }
//}
