using System;
using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _damage = 1;
    [SerializeField] private float _speed = 25f;
    [SerializeField] private float _fixedDistance = 50f;

    private Coroutine _returnToPoolTimerCoroutine;
    
    private void OnEnable()
    {
        _returnToPoolTimerCoroutine = StartCoroutine(ReturnToPoolAfterTime());
    }
    
    private void Update()
    {
        MoveForward();
    }
    
    private void MoveForward()
    {
        transform.position += transform.forward * (_speed * Time.deltaTime);
    }
    
    private float CalculateDistance()
    {
        return _fixedDistance / _speed;
    }
    
    private IEnumerator ReturnToPoolAfterTime()
    {
        float elapsedTime = 0f;
        while (elapsedTime < CalculateDistance())
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        
        ObjectPoolManager.ReturnObjectToPool(gameObject);
    }
    
    public void SetupBullet(int bulletDamage, float bulletSpeed, float fixedDistance)
    {
        _damage = bulletDamage;
        _speed = bulletSpeed;
        _fixedDistance = fixedDistance;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Power power))
        {
            power.DecreasePower(_damage);
            ObjectPoolManager.ReturnObjectToPool(gameObject);
        }
    }
}
