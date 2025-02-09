using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _damage = 1;
    [SerializeField] private float _speed = 25f;
    [SerializeField] private float _fixedDistance = 50f;
    
    private void Start()
    {
        Invoke(nameof(DestroyBulletAfterCertainTime), CalculateDistance());
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
    
    private void DestroyBulletAfterCertainTime()
    {
        Destroy(gameObject);
    }

    public void SetupBullet(int bulletDamage, float bulletSpeed, float fixedDistance)
    {
        _damage = bulletDamage;
        _speed = bulletSpeed;
        _fixedDistance = fixedDistance;
    }
}
