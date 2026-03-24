using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.UIElements.Experimental;

public class MagunsEffect : MonoBehaviour
{
    public float kickForce = 1.0f;
    public float spinAmount = 1.0f; // ปรับทิศทางหลังเตะไปแล้ว ซ้าย/ขวา
    public float magusStrength = 0.5f;
    private Rigidbody _rb;
    private bool _isShoot  = false;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame && !_isShoot)
        {
            // ปรับทิศทางตอนเตะ
            _rb.AddForce(new Vector3(-1,4f,kickForce),ForceMode.Impulse);
            // ให้ลูกบอลหมุนเวลาเคลื่อนที่
            _rb.AddRelativeTorque(Vector3.up * spinAmount);
            _isShoot = true;
        }
    }
    void FixedUpdate()
    {
        if (_isShoot) return;
        Vector3 velocity = _rb.linearVelocity;
        Vector3 spin = _rb.angularVelocity;
        // Cross Product หาทิศทางให้บอลเคลื่อที่ไป
        Vector3 magusForce = Vector3.Cross(spin, velocity);
        magusForce *= magusStrength;
        _rb.AddForce(magusForce);
    }
}

