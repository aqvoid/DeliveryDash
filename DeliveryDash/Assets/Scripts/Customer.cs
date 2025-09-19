using UnityEngine;

public class Customer : MonoBehaviour
{
    private PackagesController packagesController;

    private void Awake()
    {
        packagesController = GetComponentInParent<PackagesController>();
        packagesController?.AddCustomer();
    }
    private void OnDestroy() => packagesController?.RemoveCustomer();
}
