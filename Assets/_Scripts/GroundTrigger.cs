using UnityEngine;

public class GroundTrigger : MonoBehaviour
{
    [SerializeField] private LayerMask _playerLayerMask;

    private void OnTriggerEnter(Collider other)
    {
        if((_playerLayerMask.value & (1 << other.transform.gameObject.layer)) > 0)
        {
            GameManager.Instance.GroundSpawner.SpawnGround();
        }
    }
}
