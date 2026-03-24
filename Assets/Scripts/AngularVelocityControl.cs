using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class AngularVelocityControl : MonoBehaviour
{
    public float angularSpeed = 1f;
    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (Keyboard.current.aKey.isPressed)
        {
            _rb.angularVelocity = new Vector3(0, angularSpeed, 0);
        }
        else
        {
            _rb.angularVelocity = Vector3.zero;
        }
            
    }
    
}
