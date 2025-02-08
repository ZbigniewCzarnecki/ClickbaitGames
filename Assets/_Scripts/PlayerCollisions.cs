using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    [SerializeField] private LayerMask _collisionLayerMask;
    
    private void OnTriggerEnter(Collider other)
    {
        if((_collisionLayerMask.value & (1 << other.transform.gameObject.layer)) > 0)
        {
            GameManager.Instance.GroundSpawner.SpawnGround();
        }
    }
}
