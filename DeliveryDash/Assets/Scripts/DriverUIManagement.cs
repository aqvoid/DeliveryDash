using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DriverUIManagement : MonoBehaviour
{

    [Header("=== Packages ===")]
    [SerializeField] private PackagesController packagesScript;
    [SerializeField] private TMP_Text packagesText;

    [Header("=== Boost ===")]
    [SerializeField] private BoostController boostScript;
    [SerializeField] private TMP_Text boostText;

    [Header("=== Victory Window ===")]
    [SerializeField] private VictoryWindowController victoryWindow;

    [Header("=== Stopwatch ===")]
    [SerializeField] private StopwatchController stopwatchScript;
    [SerializeField] private TMP_Text stopwatchText;

    [Header("=== Game Menu Texts ===")]
    [SerializeField] private GameObject[] gameMenuTexts;

    [Header("=== Game Manager ===")]
    [SerializeField] private GameManager gameManager;


    void Start() => ToggleBoostText(false);
    
    private void Update()
    {
        ChangeStopwatchText(stopwatchScript.ElapsedTime);
        ChangePackagesText(packagesScript.CurrentPackages);

        ToggleVictoryWindow(gameManager.GameWon);
        ToggleUIElements(!gameManager.GameWon);
    }

    private void ToggleVictoryWindow(bool state) => victoryWindow.gameObject.SetActive(state);

    private void ToggleUIElements(bool state)
    {
        foreach (GameObject gameObject in gameMenuTexts) gameObject.SetActive(state);
    }

    private void ChangeStopwatchText(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);
        int milliseconds = Mathf.FloorToInt((time * 100) % 100);

        stopwatchText.text = "Time passed: " + string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
    }

    private void ChangePackagesText(int packagesCount) => packagesText.text = $"Packages left: {packagesCount}";
    
    public void ToggleBoostText(bool state) => boostText.gameObject.SetActive(state);

    public void RestartButton() => SceneManager.LoadScene(0);
    public void QuitButton() => Application.Quit();

    public void ShowVictory() => victoryWindow.Show();
}
