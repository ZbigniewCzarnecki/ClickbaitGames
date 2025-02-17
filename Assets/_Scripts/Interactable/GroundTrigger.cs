using UnityEngine;

public class GroundTrigger : MonoBehaviour, IInteract
{
    Transform _parentTransform;
    
    private void Start()
    {
        _parentTransform = transform.parent;
    }
    public void OnInteract()
    {
        GameManager.Instance.GroundSpawner.MoveGroundToNewPosition(_parentTransform);
    }
}
