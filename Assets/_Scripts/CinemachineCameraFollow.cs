using UnityEngine;
using Unity.Cinemachine;

public class CinemachineCameraFollow : MonoBehaviour
{
    public static CinemachineCameraFollow Instance;
    private CinemachineCamera _cinemachineCamera;
    
    // private CinemachineFollow _cinemachineFollow;
    //
    // private Transform _cachedTransform;
    // private Quaternion _targetRotation;
    //
    // [SerializeField] private float _rotationSpeed = 8.0f;
    // [SerializeField] private float _offsetSpeed = 1.0f;
    // [SerializeField] private float _rotationMultiplier = 0.5f;  
    // [SerializeField] private float _offsetMultiplier = 1.0f;  
    
    private Transform _targetTransform;  
    
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
        
        _cinemachineCamera = GetComponent<CinemachineCamera>();
        //_cinemachineFollow = GetComponent<CinemachineFollow>();
        
        // _cachedTransform = transform;
        // _targetRotation = _cachedTransform.rotation;
    }

    public void SetTarget(Transform target)
    {
        _targetTransform = target;
        _cinemachineCamera.Follow = _targetTransform;
    }
    
    // void LateUpdate()
    // {
    //     if (_targetTransform)
    //     {
    //         float newRotationY = -_targetTransform.position.x * _rotationMultiplier;
    //         _targetRotation = Quaternion.Euler(_cachedTransform.eulerAngles.x, newRotationY, _cachedTransform.eulerAngles.z);
    //
    //         float newOffsetPosX = _targetTransform.position.x * _offsetMultiplier;
    //         Vector3 currentOffset = _cinemachineFollow.FollowOffset;
    //         currentOffset.x = Mathf.Lerp(currentOffset.x, newOffsetPosX, Time.deltaTime * _offsetSpeed);
    //         _cinemachineFollow.FollowOffset = currentOffset;
    //     }
    //     
    //     _cachedTransform.rotation = Quaternion.Slerp(_cachedTransform.rotation, _targetRotation, Time.deltaTime * _rotationSpeed);
    // }
}
