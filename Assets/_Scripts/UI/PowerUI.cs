using TMPro;
using UnityEngine;

public class PowerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _powerText;
    private Power _power;
    
    private void Awake()
    {
        _power = GetComponentInParent<Power>();
    }

    private void Start()
    {
        _power.OnDecreasePowerAction += Power_OnDecreasePowerAction;
        UpdateUI();
    }

    private void OnDisable()
    {
        _power.OnDecreasePowerAction -= Power_OnDecreasePowerAction;
    }

    private void Power_OnDecreasePowerAction()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        _powerText.text = _power.CurrentPower.ToString();
    }
}
