using UnityEngine;
using System;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;

    public static event Action OnInputChangedAction;
    
    private static bool _rightInput;
    private static bool _leftInput;
    
    public static bool RightInput { get { return _rightInput; } }
    public static bool LeftInput { get { return _leftInput; } }
    
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
    }
    
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            
            if (mousePosition.x < Screen.width / 2)
            {
                if (!_leftInput)
                {
                    OnInputChangedAction?.Invoke();
                    
                    _leftInput = true;
                    _rightInput = false;
                }
            }
            else
            {
                if (!_rightInput)
                {
                    OnInputChangedAction?.Invoke();
                    
                    _rightInput = true;
                    _leftInput = false;
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            _rightInput = false;
            _leftInput = false;
        }
    }
}

