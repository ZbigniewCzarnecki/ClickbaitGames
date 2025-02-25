using TMPro;
using UnityEngine;

public class PowerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _powerText;
    private Health _health;
    
    private void Awake()
    {
        _health = GetComponentInParent<Health>();
    }

    private void Start()
    {
        _health.OnDecreaseHealthAction += HealthOnDecreaseHealthAction;
        UpdateUI();
    }

    private void OnDisable()
    {
        _health.OnDecreaseHealthAction -= HealthOnDecreaseHealthAction;
    }

    private void HealthOnDecreaseHealthAction()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        _powerText.text = _health.CurrentHealth.ToString();
    }
}
