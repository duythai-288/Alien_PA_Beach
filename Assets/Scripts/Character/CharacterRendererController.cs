using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRendererController : MonoBehaviour
{

    [SerializeField] private Camera _cam;
    [SerializeField] private Renderer _renderer;
    private void LateUpdate()
    {

        if (!_renderer) _renderer = GetComponent<Renderer>();
        if (!_cam) _cam = Camera.main;

        // var planes = GeometryUtility.CalculateFrustumPlanes(_cam);

        // _renderer.enabled = GeometryUtility.TestPlanesAABB(planes, _renderer.bounds);
    }
}
