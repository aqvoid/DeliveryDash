using UnityEngine;

public class PackagesController : MonoBehaviour
{
    public int InitialPackages { get; private set; }
    public int CurrentPackages { get; private set; }

    public void RemoveCustomer() => CurrentPackages--;

    public void AddCustomer()
    {
        CurrentPackages++;
        InitialPackages++;
    }
}
