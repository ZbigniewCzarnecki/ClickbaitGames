using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IInteract interact))
        {
            interact.OnInteract();
        }
    }
}
