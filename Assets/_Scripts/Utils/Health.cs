using UnityEngine;
using System;
using UnityEngine.Serialization;

public class Health : MonoBehaviour
{
    public event Action OnIncreaseHealthAction;
    public event Action OnDecreaseHealthAction;
    public event Action OnBelowZeroHealthAction;
    
    
    [SerializeField] private int _health = 10;
    private int _currentHealth;
    
    public int CurrentHealth => _currentHealth;

    private void Awake()
    {
        _currentHealth = _health;
    }

    public void IncreaseHealth(int health)
    {
        _currentHealth += health;
        OnIncreaseHealthAction?.Invoke();
    }

    public void DecreaseHealth(int health)
    {
        _currentHealth -= health;
        
        if (_currentHealth <= 0)
        {
            _currentHealth = 0;
            OnBelowZeroHealthAction?.Invoke();
            Destroy(gameObject);
            return;
        }
        
        OnDecreaseHealthAction?.Invoke();
    }
}
