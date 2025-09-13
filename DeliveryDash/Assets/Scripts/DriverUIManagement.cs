using TMPro;
using UnityEngine;

public class DriverUIManagement : MonoBehaviour
{
    internal static TMP_Text boostText;

    [Header("UI")]
    [SerializeField] private GameObject canvasGameObject;


    void Awake()
    {
        boostText = canvasGameObject.GetComponentInChildren<TMP_Text>();
        boostText.gameObject.SetActive(false);
    }
    
}
