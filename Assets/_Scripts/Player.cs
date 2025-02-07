using System;
using UnityEngine;
using UnityEngine.AI;

public class Player: MonoBehaviour 
{
    [SerializeField] private Transform _target;
    
    private NavMeshAgent _agent;
    private Vector3 _startPos;
    
    [SerializeField] private float _forwardSpeed = 10f;
    [SerializeField] private float _turnSpeed = 10f;
    
    private PlayerTarget _playerTarget;
    
    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _startPos = transform.position;
    }

    private void Start()
    {
        _playerTarget = Instantiate(_target, transform.position, Quaternion.identity).GetComponent<PlayerTarget>();
        _playerTarget.SetupTarget(_forwardSpeed, _turnSpeed);
        
        CinemachineCameraFollow.Instance.SetTarget(transform);
    }

    void Update()
    {
        MoveToTarget();
        Reset();
    }

    private void MoveToTarget()
    {
        Vector3 direction = (_playerTarget.transform.position - _agent.transform.position);
        Vector3 movement = direction * (_forwardSpeed * Time.deltaTime);
        _agent.Move(movement);
    }

    private void Reset()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.position = _startPos;
            _playerTarget.transform.position = _startPos;
        }
    }
}