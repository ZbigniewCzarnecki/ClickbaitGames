using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int _damage = 1;
    private float _speed = 25f;
    private float _fixedDistance = 50f;

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
        if (other.TryGetComponent(out Health power))
        {
            power.DecreaseHealth(_damage);
            ObjectPoolManager.ReturnObjectToPool(gameObject);
        }
    }
}
