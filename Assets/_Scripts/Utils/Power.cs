using UnityEngine;
using System;

public class Power : MonoBehaviour
{
    public event Action OnIncreasePowerAction;
    public event Action OnDecreasePowerAction;
    public event Action OnBelowZeroPowerAction;
    
    
    [SerializeField] private int _power = 10;
    private int _currentPower;
    
    public int CurrentPower => _currentPower;

    private void Awake()
    {
        _currentPower = _power;
    }

    public void IncreasePower(int power)
    {
        _currentPower += power;
        OnIncreasePowerAction?.Invoke();
    }

    public void DecreasePower(int power)
    {
        _currentPower -= power;
        
        if (_currentPower <= 0)
        {
            _currentPower = 0;
            OnBelowZeroPowerAction?.Invoke();
            Destroy(gameObject);
            return;
        }
        
        OnDecreasePowerAction?.Invoke();
    }
}
