using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    private float _moveSpeed;
    private NavMeshAgent _agent;
    private Transform _playerTransform;
    private Transform _targetTransform;
    
    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _playerTransform = transform;
    }

    private void Update()
    {
        if (!_targetTransform)
            return;

        MoveToTarget();
    }

    private void MoveToTarget()
    {
        Vector3 targetDirection = (_targetTransform.position - _playerTransform.position).normalized;
        Vector3 moveVector = targetDirection * (_moveSpeed * Time.deltaTime);

        _agent.Move(moveVector);
    }
    
    public void SetupPlayer(float moveSpeed, Transform target)
    {
        _moveSpeed = moveSpeed;
        _targetTransform = target;
    }
}
