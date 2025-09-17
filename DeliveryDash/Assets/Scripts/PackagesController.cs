using UnityEngine;

public class PackagesController : MonoBehaviour
{
    private int currentPackages;

    public int InitialPackages { get; private set; }
    public int CurrentPackages { get => currentPackages; private set => currentPackages = value; }

    private void Start()
    {
        UpdatePackagesCount();
        InitialPackages = currentPackages;
    }
    private void Update() => UpdatePackagesCount();

    private void UpdatePackagesCount() => currentPackages = GameObject.FindGameObjectsWithTag("Customer").Length;
}
