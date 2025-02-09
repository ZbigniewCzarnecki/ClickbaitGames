using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private Transform _bulletPrefab;
   
    private float _timer;
    [SerializeField] private float _maxTime = .2f;

    void Update()
    {    
        _timer += Time.deltaTime;

        if (_timer >= _maxTime)
        {
            _timer = 0f;
            Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
        }
    }
}
