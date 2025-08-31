using UnityEngine;
using UnityEngine.InputSystem;

public class Driver : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 2f;
    [SerializeField] private float moveSpeed = 0.1f;

    void Start()
    {
    }

    void Update()
    {
        if (Keyboard.current.wKey.isPressed)
        {
            Debug.Log("Pushing Forward");
        }
        
        else if (Keyboard.current.sKey.isPressed)
        {
            Debug.Log("Pushing Backward");
        }

        if (Keyboard.current.dKey.isPressed)
        {
            Debug.Log("Pushing Right");
        }

        else if (Keyboard.current.aKey.isPressed)
        {
            Debug.Log("Pushing Left");
        }
        




        //transform.Rotate(0, 0, 0.1f);
        //transform.Translate(0, 0.01f, 0);
    }
}
