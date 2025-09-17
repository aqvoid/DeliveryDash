using UnityEngine;

public class DriverCollision : MonoBehaviour
{
    private bool hasPackage;

    [SerializeField] private DriverUIManagement driverUIManagement;
    [SerializeField] private BoostController boostController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Package") && !hasPackage)
        {
            hasPackage = true;
            GetComponent<ParticleSystem>().Play();
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Customer") && hasPackage)
        {
            hasPackage = false;
            GetComponent<ParticleSystem>().Stop();
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Boost"))
        {
            driverUIManagement.ToggleBoostText(true);
            boostController.ActivateBoost();
            Destroy(collision.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        driverUIManagement.ToggleBoostText(false);
        boostController.DeactivateBoost();
    }
}
