using UnityEngine;

public class PlayerFollowTarget : MonoBehaviour
{
    private float _forwardSpeed;
    private float _horizontalSpeed;
    private readonly float _minX = 5f;
    
    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 forwardMovement = Vector3.forward * (_forwardSpeed * Time.deltaTime);
        
        float horizontalInput = 0f;
        if (InputManager.RightInput)
        {
            horizontalInput = _horizontalSpeed;
        }
        else if (InputManager.LeftInput)
        {
            horizontalInput = -_horizontalSpeed;
        }
        Vector3 horizontalMovement = Vector3.right * (horizontalInput * Time.deltaTime);
        
        transform.Translate(forwardMovement + horizontalMovement, Space.World);
        
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -_minX, _minX);
        transform.position = clampedPosition;
    }


    
    public void Setup(float forwardSpeed, float horizontalSpeed)
    {
        _forwardSpeed = forwardSpeed;
        _horizontalSpeed = horizontalSpeed;
    }
}