using TMPro;
using UnityEngine;

public class VictoryWindowController : MonoBehaviour
{
    [SerializeField] private StopwatchController stopwatchController;
    [SerializeField] private TMP_Text stopwatchResultText;

    [SerializeField] private PackagesController packagesController;
    [SerializeField] private TMP_Text packagesResultText;

    [SerializeField] private DriverUIManagement driverUIManagement;

    private void ApplyPackagesResult() => packagesResultText.text = $"Packages Delivered: {packagesController.InitialPackages}";

    private void ApplyStopwatchResult(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);
        int milliseconds = Mathf.FloorToInt((time * 100) % 100);

        stopwatchResultText.text = "Time passed: " + string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
    }

    public void Show()
    {   
        ApplyPackagesResult();
        ApplyStopwatchResult(stopwatchController.ElapsedTime);
    }
}
