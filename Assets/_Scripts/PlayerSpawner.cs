using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public static PlayerSpawner Instance;
    [SerializeField] private Player _player;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
    }
    
    public void SpawnPlayer()
    {
        Instantiate(_player.transform, _player.transform.position, Quaternion.identity);
    }
}
