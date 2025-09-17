using UnityEngine;

public class PackagesController : MonoBehaviour
{
    private int currentPackages;

    public int CurrentPackages { get => currentPackages; private set => currentPackages = value; } 

    void Update() => CurrentPackages = GameObject.FindGameObjectsWithTag("Customer").Length;
}
