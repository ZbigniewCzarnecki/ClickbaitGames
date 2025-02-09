using UnityEngine;

public class PlayerTarget : MonoBehaviour
{
    private float _forwardSpeed = 10f;
    private float _turnSpeed = 10f;
    private float _minX = 5f;

    private void Update()
    {
        MoveForward();
        TurnSides();
    }

    private void MoveForward()
    {
        transform.Translate(Vector3.forward * (_forwardSpeed * Time.deltaTime));
    }

    private void TurnSides()
    {
        if (InputManager.RightInput)
        {
            transform.Translate(Vector3.right * (_turnSpeed * Time.deltaTime));
        }

        if (InputManager.LeftInput)
        {
            transform.Translate(Vector3.left * (_turnSpeed * Time.deltaTime));
        }

        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -_minX, _minX);
        transform.position = clampedPosition;
    }
    
    public void SetupTarget(float forwardSpeed, float turnSpeed)
    {
        _forwardSpeed = forwardSpeed;
        _turnSpeed = turnSpeed;
    }
}