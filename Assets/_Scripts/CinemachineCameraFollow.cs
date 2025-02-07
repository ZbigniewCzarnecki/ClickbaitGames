using UnityEngine;
using Unity.Cinemachine;

public class CinemachineCameraFollow : MonoBehaviour
{
    public static CinemachineCameraFollow Instance;
    private CinemachineCamera _cinemachineCamera;
    
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
        
        _cinemachineCamera = GetComponent<CinemachineCamera>();
    }

    public void SetTarget(Transform target)
    {
        _cinemachineCamera.Follow = target;
    }
}
