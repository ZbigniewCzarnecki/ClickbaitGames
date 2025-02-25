using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{
    private Health _health;

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    private void Start()
    {
        _health.OnBelowZeroHealthAction += Health_OnOnBelowZeroHealthAction;
    }

    private void Health_OnOnBelowZeroHealthAction()
    {
        Debug.Log("Chest: Health_OnOnBelowZeroHealthAction");
    }

    public void Interact()
    {
        GameManager.PlayerManager.Health.DecreaseHealth(_health.CurrentHealth);
        Destroy(gameObject);
    }
}
