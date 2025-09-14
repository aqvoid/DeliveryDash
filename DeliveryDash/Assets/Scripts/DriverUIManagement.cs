using TMPro;
using UnityEngine;

public class DriverUIManagement : MonoBehaviour
{
    internal static TMP_Text boostText;
    
    private int currentPackages;
    private TMP_Text packagesText;

    [Header("UI")]
    [SerializeField] private GameObject canvasGameObject;


    void Awake()
    {
        packagesText = GameObject.Find("Packages Text").GetComponent<TMP_Text>();
        boostText = GameObject.Find("Boost Text").GetComponent<TMP_Text>();
        boostText.gameObject.SetActive(false);
    }

    private void Update()
    {
        currentPackages = GameObject.FindGameObjectsWithTag("Customer").Length;
        packagesText.text = $"Packages left: {currentPackages}";
    }
}
