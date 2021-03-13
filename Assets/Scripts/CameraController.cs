using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraController : MonoBehaviour
{
    private CinemachineComposer composer;

    [SerializeField] private float Sensitivity = 0.1f;

    private void Start()
    {
        composer = GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineComposer>();
    }
    private void Update()
    {
        float verticle = Input.GetAxis("Mouse Y") * Sensitivity;
        composer.m_TrackedObjectOffset.y += verticle;
        composer.m_TrackedObjectOffset.y = Mathf.Clamp(composer.m_TrackedObjectOffset.y, -4, 10);
    }
}
