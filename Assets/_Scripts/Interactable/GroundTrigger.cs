using UnityEngine;

public class GroundTrigger : MonoBehaviour, IInteractable
{
    Transform _parentTransform;
    
    private void Start()
    {
        _parentTransform = transform.parent;
    }
    public void Interact()
    {
        GameManager.GroundSpawner.MoveGroundToNewPosition(_parentTransform);
    }
}
