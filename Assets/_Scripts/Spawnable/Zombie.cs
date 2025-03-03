using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    [SerializeField] private float _zombieSpeed = 3.5f;
    private NavMeshAgent _agent;
    private Transform _targetTransform;

    public Transform Target { get { return _targetTransform; } set { _targetTransform = value; } }
    
    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.speed = _zombieSpeed;
    }

    private void Update()
    {
        if (_targetTransform)
        {
            _agent.SetDestination(_targetTransform.position);
        }
    }
    
    public void SetupZombie(float zombieSpeed)
    {
        _zombieSpeed = zombieSpeed;

        if (_agent)
        {
            _agent.speed = _zombieSpeed;
        }
    }
}