using UnityEngine;

public class GroundTrigger : MonoBehaviour, IInteractable
{
    Transform _parentTransform;
    
    private void Start()
    {
        _parentTransform = transform.parent;
    }
    public void OnInteract()
    {
        GameManager.GroundSpawner.MoveGroundToNewPosition(_parentTransform);
    }
}
