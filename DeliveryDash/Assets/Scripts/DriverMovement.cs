using System;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.InputSystem;

public class DriverMovement : MonoBehaviour
{
    // References
    private Rigidbody2D rb;

    private float defaultAcceleration;

    // Input
    private float moveInput;
    private float rotateInput;
    private bool brakeInput;

    private PhysicsHandler physicsHandler;

    [Header("=== Movement ===")]
    [SerializeField] private float baseAcceleration = 15f;
    [SerializeField] private float maxSpeed = 30f;
    [SerializeField] private float steering = 400f;
    [SerializeField] private float friction = 2f;
    [SerializeField, Range(0f, 1f)] private float sideSlipFactor = 0.5f; // 0 - no side slip, 1 - full side slip

    [Header("=== References ===")]
    [SerializeField] private BoostController boostController;

    public float Acceleration { get => baseAcceleration; private set => baseAcceleration = value; }


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        GetDefaultAcceleration();

        PhysicsHandler[] funcs = { ApplyMovement, ApplySteering, ApplyFriction, LimitSpeed };

        foreach (var func in funcs)
            physicsHandler += func;
    }

    private void Update() => ReadInput();
    private void FixedUpdate() => physicsHandler?.Invoke();

    private void GetDefaultAcceleration() => defaultAcceleration = baseAcceleration;
    public void SetAcceleration(float newAcceleration) => baseAcceleration = newAcceleration;
    public void ResetAcceleration() => baseAcceleration = defaultAcceleration;

    private void ReadInput()
    {
        moveInput = rotateInput = 0f;
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
        float sideSpeed = Vector2.Dot(rb.linearVelocity, rightVector) * sideSlipFactor;

        // apply new velocity 
        rb.linearVelocity = forwardVector * forwardSpeed + rightVector * sideSpeed;

        // engine force
        Vector2 engineForce = forwardVector * moveInput * baseAcceleration * rb.mass;
        rb.AddForce(engineForce);

        // brakes
        if (brakeInput && rb.linearVelocity.magnitude > 0.1f)
        {
            Vector2 brakeForceVector = -rb.linearVelocity.normalized * baseAcceleration * rb.mass;
            rb.AddForce(brakeForceVector);
        }
    }

    private void ApplySteering()
    {
        Vector2 forwardVector = transform.up;
        float forwardSpeed = Vector2.Dot(rb.linearVelocity, forwardVector);

        float speedFactor = Mathf.Clamp01(Mathf.Abs(forwardSpeed) / maxSpeed);
        float deltaAngle = -rotateInput * steering * speedFactor * Time.fixedDeltaTime; // rotate depending on speed, cannot rotate if has no speed

        rb.MoveRotation(rb.rotation + deltaAngle);
    }

    private void ApplyFriction() => rb.AddForce(-rb.linearVelocity * rb.mass * friction);

    private void LimitSpeed()
    {
        if (rb.linearVelocity.magnitude > maxSpeed)
            rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
    }

    private delegate void PhysicsHandler();

}
