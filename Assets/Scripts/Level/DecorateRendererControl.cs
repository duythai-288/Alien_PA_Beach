using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class DecorateRendererControl : MonoBehaviour
{
    [SerializeField] private Camera _cam;
    [SerializeField] private MeshRenderer _renderer;
    private void LateUpdate()
    {

        if (!_renderer) _renderer = GetComponent<MeshRenderer>();
        if (!_cam) _cam = Camera.main;

        // var planes = GeometryUtility.CalculateFrustumPlanes(_cam);

        // _renderer.enabled = GeometryUtility.TestPlanesAABB(planes, _renderer.bounds);
    }
}
