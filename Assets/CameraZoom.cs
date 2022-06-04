using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraZoom : MonoBehaviour
{
    float minFov  = 10f;
    float maxFov  = 29f;
    float sensitivity  = 10f;
    CinemachineVirtualCamera virtualCamera;

    private void Start()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();   
    }
    private void Update()
    {
        var zoom = virtualCamera.m_Lens.OrthographicSize;
        zoom -= Input.GetAxis("Mouse ScrollWheel") * sensitivity;
        zoom = Mathf.Clamp(zoom, minFov, maxFov);
        virtualCamera.m_Lens.OrthographicSize = zoom;
    }
}
