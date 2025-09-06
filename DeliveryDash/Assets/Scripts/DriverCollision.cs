using UnityEngine;

public class DriverCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Bump");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Package"))
        {
            Debug.Log("Pickup package");
        }

        if (collision.CompareTag("Customer"))
        {
            Debug.Log("Delivered Package");
        }
    }
}
