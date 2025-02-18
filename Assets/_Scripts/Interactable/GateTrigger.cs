using UnityEngine;

public class GateTrigger : MonoBehaviour, IInteractable
{
    public void OnInteract()
    {
        Debug.Log("Gate Trigger");
    }
}
