using System;
using UnityEngine;

public class LookAtCamera : MonoBehaviour {
    
    private Camera _mainCam;
    
    private enum Mode {
        LookAt,
        LookAtInverted,
        CameraForward,
        CameraForwardInverted,
    }
    
    [SerializeField] private Mode _mode;

    private void Awake()
    {
        _mainCam = Camera.main;
    }

    private void LateUpdate() {
        switch (_mode) {
            case Mode.LookAt:
                transform.LookAt(_mainCam.transform);
                break;
            case Mode.LookAtInverted:
                Vector3 dirFromCamera = transform.position - _mainCam.transform.position;
                transform.LookAt(transform.position + dirFromCamera);
                break;
            case Mode.CameraForward:
                transform.forward = _mainCam.transform.forward;
                break;
            case Mode.CameraForwardInverted:
                transform.forward = -_mainCam.transform.forward;
                break;
        }
    }

}