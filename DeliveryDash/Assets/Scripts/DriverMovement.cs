using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class DriverMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    private float boostAcceleration;
    private float defaultAcceleration;

    // Input
    private float moveInput;
    private float rotateInput;
    private bool brakeInput;

    private PhysicsHandler physicsHandler;

    [Header("Movement")]
    [SerializeField] private float acceleration = 15f;
    [SerializeField] private float maxSpeed = 30f;
    [SerializeField] private float steering = 400f;
    [SerializeField] private float friction = 2f;
    [SerializeField] private float brakeForce = 20f;
    [SerializeField, Range(0f, 1f)] private float sideSlipFactor = 0.5f; // 0 - no side slip, 1 - full side slip
    [SerializeField, Range(1f, 2f)] private float boostMultiplier = 1.5f;

    [Header("References")]
    [SerializeField] private DriverUIManagement driverUIManagement;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        boostAcceleration = acceleration * boostMultiplier;
        defaultAcceleration = acceleration;

        PhysicsHandler[] funcs = { ApplyMovement, ApplySteering, ApplyFriction, LimitSpeed };

        foreach (var func in funcs)
            physicsHandler += func;
    }

    private void Update()
    {
        ReadInput();
    }

    private void FixedUpdate()
    {
        physicsHandler?.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Boost"))
        {
            Destroy(collision.gameObject);
            driverUIManagement.ToggleBoostText(true);
            acceleration = boostAcceleration;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        driverUIManagement.ToggleBoostText(false);
        acceleration = defaultAcceleration;
    }

    private void ReadInput()
    {
        moveInput = 0f;
        rotateInput = 0f;
        brakeInput = false;

        if (Keyboard.current.wKey.isPressed) moveInput = 1f;
        if (Keyboard.current.sKey.isPressed) moveInput = -1f;
        if (Keyboard.current.dKey.isPressed) rotateInput = 1f;
        if (Keyboard.current.aKey.isPressed) rotateInput = -1f;

        if (Keyboard.current.spaceKey.isPressed) brakeInput = true;
    }

    private void ApplyMovement()
    {
        // get vectors and current speeds by vectors
        Vector2 forwardVector = transform.up;
        Vector2 rightVector = transform.right;

        float forwardSpeed = Vector2.Dot(rb.linearVelocity, forwardVector);
        float sideSpeed = Vector2.Dot(rb.linearVelocity, rightVector);

        // make inertion less to the sides
        sideSpeed *= sideSlipFactor;

        // apply new velocity 
        rb.linearVelocity = forwardVector * forwardSpeed + rightVector * sideSpeed;

        Vector2 engineForce = (Vector2)(transform.up * moveInput) * (acceleration * rb.mass);
        rb.AddForce(engineForce);

        // brakes
        if (brakeInput && rb.linearVelocity.magnitude > 0.1f)
        {
            Vector2 brakeForceVector = -rb.linearVelocity.normalized * brakeForce * rb.mass;
            rb.AddForce(brakeForceVector);
        }
    }

    private void ApplySteering()
    {
        Vector2 forwardVector = transform.up;
        float forwardSpeed = Vector2.Dot(rb.linearVelocity, forwardVector);

        float speedFactor = Mathf.Clamp01(Mathf.Abs(forwardSpeed) / maxSpeed);

        // rotate depending on speed, cannot rotate if has no speed
        float deltaAngle = -rotateInput * steering * speedFactor * Time.fixedDeltaTime;
        rb.MoveRotation(rb.rotation + deltaAngle);
    }

    private void ApplyFriction()
    {
        Vector2 drag = -rb.linearVelocity * rb.mass * friction;
        rb.AddForce(drag);
    }

    private void LimitSpeed()
    {
        if (rb.linearVelocity.magnitude > maxSpeed)
            rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
    }

    public delegate void PhysicsHandler();

}
