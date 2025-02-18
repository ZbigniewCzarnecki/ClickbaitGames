using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{
    [SerializeField] private int _damage = 5;
    
    public void OnInteract()
    {
        GameManager.PlayerManager.Power.DecreasePower(_damage);
        Destroy(gameObject);
    }
}
