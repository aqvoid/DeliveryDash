using UnityEngine;
using UnityEngine.InputSystem;

public class DriverMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 0.1f;
    [SerializeField] private float rotateSpeed = 2f;

    void Start()
    {
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

        float moveAmount = move * moveSpeed * Time.deltaTime;
        float rotateAmount = rotate * rotateSpeed * Time.deltaTime;

        transform.Translate(0, moveAmount, 0);
        transform.Rotate(0, 0, rotateAmount);
    }
}
