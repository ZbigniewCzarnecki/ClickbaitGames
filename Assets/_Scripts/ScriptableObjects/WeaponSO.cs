using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Weapon", order = 1)]
public class WeaponSO : ScriptableObject
{
    public string weaponName;
    
    public int damage;
    
    public float fireRateMax;
    public float bulletSpeed;
    public float bulletFixedDistance;
}