using UnityEngine;

public class Weapon : MonoBehaviour, IInteractable
{
    [SerializeField] private WeaponSO _weaponData; 
    
    public void Interact()
    {
        GameManager.PlayerManager.PlayerWeapon.SetupNewWeapon(_weaponData);
        Destroy(gameObject);
    }
}
