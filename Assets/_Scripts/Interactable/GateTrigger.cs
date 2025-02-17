using UnityEngine;

public class GateTrigger : MonoBehaviour, IInteract
{
    public void OnInteract()
    {
        Debug.Log("Gate Trigger");
    }
}
