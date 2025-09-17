using UnityEngine;

public class PackagesController : MonoBehaviour
{
    public int InitialPackages { get; private set; }
    public int CurrentPackages { get; private set; }

    private void Start()
    {
        CurrentPackages = GameObject.FindGameObjectsWithTag("Customer").Length;
        InitialPackages = CurrentPackages;
    }

    public void RemoveCustomer() => CurrentPackages--;
}
