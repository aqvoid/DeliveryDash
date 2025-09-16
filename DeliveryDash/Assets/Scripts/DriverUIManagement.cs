using TMPro;
using UnityEngine;

public class DriverUIManagement : MonoBehaviour
{
    internal static TMP_Text boostText;
    
    private int currentPackages;
    private TMP_Text packagesText;

    [SerializeField] private Stopwatch stopwatchScript;
    [SerializeField] private TMP_Text stopwatchText;

    void Awake()
    {

        packagesText = GameObject.Find("Packages Text").GetComponent<TMP_Text>();
        boostText = GameObject.Find("Boost Text").GetComponent<TMP_Text>();
        boostText.gameObject.SetActive(false);
    }
    private void Update()
    {
        ChangeStopwatchText(stopwatchScript.ElapsedTime);

        currentPackages = GameObject.FindGameObjectsWithTag("Customer").Length;
        packagesText.text = $"Packages left: {currentPackages}";
    }

    private void ChangeStopwatchText(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);
        int milliseconds = Mathf.FloorToInt((time * 100) % 100);

        stopwatchText.text = "Time passed: " + string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
    }
}
