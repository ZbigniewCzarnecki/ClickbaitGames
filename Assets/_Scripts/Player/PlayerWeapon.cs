using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private Transform _bulletPrefab;
   
    private float _bulletFireRate;
    [SerializeField] private float _bulletFireRateMax = .2f;
    [SerializeField] private int _bulletDamage = 1;
    [SerializeField] private float _bulletSpeed = 25f;
    [SerializeField] private float _bulletFixedDistance = 50f;
    
    void Update()
    {    
        _bulletFireRate += Time.deltaTime;

        if (_bulletFireRate >= _bulletFireRateMax)
        {
            _bulletFireRate = 0f;
            
            Bullet bullet = ObjectPoolManager.SpawnObject<Bullet>(_bulletPrefab.gameObject, transform.position, Quaternion.identity, ObjectPoolManager.PoolType.Bullet);
            bullet.SetupBullet(_bulletDamage, _bulletSpeed, _bulletFixedDistance);
        }
    }
}
