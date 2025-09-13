using UnityEngine;
using UnityEngine.InputSystem;

public class DriverMovement : MonoBehaviour
{
    [SerializeField] private float currentSpeed = 0.1f;
    [SerializeField] private float rotateSpeed = 2f;
    [SerializeField] private float regularSpeed = 20f;
    [SerializeField] [Range(1f, 2f)] private float boostMultiplier = 1.5f;
    private float boostSpeed;

    void Awake()
    {
        currentSpeed = regularSpeed;
        boostSpeed = regularSpeed * boostMultiplier;
    }

    void Update()
    {
        float move = 0;
        float rotate = 0;

        if (Keyboard.current.wKey.isPressed)
        {
            move = 1f;
        }
        
        else if (Keyboard.current.sKey.isPressed)
        {
            move = -1f;
        }

        if (Keyboard.current.dKey.isPressed)
        {
            rotate = -1f;
        }

        else if (Keyboard.current.aKey.isPressed)
        {
            rotate = 1f;
        }

        float moveAmount = move * currentSpeed * Time.deltaTime;
        float rotateAmount = rotate * rotateSpeed * Time.deltaTime;

        transform.Translate(0, moveAmount, 0);
        transform.Rotate(0, 0, rotateAmount);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Boost"))
        {
            currentSpeed = boostSpeed;
            Destroy(collision.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        currentSpeed = regularSpeed;
    }
}
