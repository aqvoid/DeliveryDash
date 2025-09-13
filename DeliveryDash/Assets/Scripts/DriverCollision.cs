using UnityEngine;

public class DriverCollision : MonoBehaviour
{
    private bool hasPackage;
    [SerializeField] [Range(0f, 1f)] private float delay = 0.5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Package") && !hasPackage)
        {
            hasPackage = true;
            GetComponent<ParticleSystem>().Play();
            Destroy(collision.gameObject, delay);
        }

        if (collision.CompareTag("Customer") && hasPackage)
        {
            GetComponent<ParticleSystem>().Stop();
            hasPackage = false;
            Destroy(collision.gameObject, delay);
        }
    }
}
