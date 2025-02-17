using UnityEngine;

public class PlayerFollowTarget : MonoBehaviour
{
    private float _forwardSpeed;
    private readonly float _minX = 5f;
    
    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 direction = Vector3.forward;

        if (InputManager.RightInput)
        {
            direction += Vector3.right; 
        }
        if (InputManager.LeftInput)
        {
            direction += Vector3.left; 
        }
        
        direction.Normalize();
        
        transform.Translate(direction * (_forwardSpeed * Time.deltaTime), Space.World);
        
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -_minX, _minX);
        transform.position = clampedPosition;
    }

    
    public void Setup(float forwardSpeed)
    {
        _forwardSpeed = forwardSpeed;
    }
}