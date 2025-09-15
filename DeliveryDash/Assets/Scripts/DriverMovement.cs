using UnityEngine;
using UnityEngine.InputSystem;

public class DriverMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 moveInput;

    private float boostedAcceleration;
    private float startAcceleration;

    [Header("Movement")]
    [SerializeField] private float acceleration = 5f;
    [SerializeField] private float maxSpeed = 10f;
    [SerializeField] private float steering = 200f;
    [SerializeField] private float friction = 0.95f;
    

    [SerializeField] [Range(1f, 2f)] private float boostMultiplier = 1.5f;

    [Header("References")]
    [SerializeField] private DriverUIManagement driverUIManagement;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        boostedAcceleration = acceleration * boostMultiplier;
        startAcceleration = acceleration;
    }


    private void FixedUpdate()
    {
        float move = 0f;
        float rotate = 0f;

        if (Keyboard.current.wKey.isPressed)
        {
            move = 1f;
            if (Keyboard.current.dKey.isPressed) rotate = 1f;
            if (Keyboard.current.aKey.isPressed) rotate = -1f;
        }
        if (Keyboard.current.sKey.isPressed)
        {
            move = -1f;
            if (Keyboard.current.dKey.isPressed) rotate = -1f;
            if (Keyboard.current.aKey.isPressed) rotate = 1f;
        }




        rb.AddForce(transform.up * move * acceleration);
        rb.rotation -= rotate * steering * Time.fixedDeltaTime * (rb.linearVelocity.magnitude / maxSpeed);
        rb.linearVelocity *= friction;

        if (rb.linearVelocity.magnitude > maxSpeed)
            rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Boost"))
        {
            Destroy(collision.gameObject);
            driverUIManagement.ToggleBoostText(true);
            acceleration = boostedAcceleration;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        driverUIManagement.ToggleBoostText(false);
        acceleration = startAcceleration;
    }
}
