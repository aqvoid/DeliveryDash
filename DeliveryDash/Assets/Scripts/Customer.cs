using UnityEngine;

public class Customer : MonoBehaviour
{
    private void OnDestroy()
    {
        FindFirstObjectByType<PackagesController>()?.RemoveCustomer();
    }
}
