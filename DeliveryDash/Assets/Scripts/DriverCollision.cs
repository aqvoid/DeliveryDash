using UnityEngine;

public class DriverCollision : MonoBehaviour
{
    private bool hasPackage;
    [SerializeField] [Range(0f, 1f)] private float delay = 0.5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Package") && !hasPackage)
        {
            Debug.Log("Picked up package");
            hasPackage = true;
            Destroy(collision.gameObject, delay);
        }

        if (collision.CompareTag("Customer") && hasPackage)
        {
            Debug.Log("Delivered Package");
            hasPackage = false;
        }
    }
}
