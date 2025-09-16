using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DriverUIManagement : MonoBehaviour
{
    private int currentPackages;

    [Header("UI")]
    [SerializeField] internal TMP_Text boostText;
    [SerializeField] private GameObject victoryWindow;
    [SerializeField] private TMP_Text packagesText;

    [SerializeField] private Stopwatch stopwatchScript;
    [SerializeField] private TMP_Text stopwatchText;


    void Awake()
    {
        ToggleBoostText(false);

        packagesText = GameObject.Find("Packages Text").GetComponent<TMP_Text>();
        boostText = GameObject.Find("Boost Text").GetComponent<TMP_Text>();
        boostText.gameObject.SetActive(false);
    }
    
    private void Update()
    {
        ChangeStopwatchText(stopwatchScript.ElapsedTime);

        currentPackages = GameObject.FindGameObjectsWithTag("Customer").Length;
        packagesText.text = $"Packages left: {currentPackages}";
        ToggleVictoryWindow();
    }

    internal void ToggleBoostText(bool toggleText) => boostText.gameObject.SetActive(toggleText);

    private void ToggleVictoryWindow()
    {
        victoryWindow.SetActive(currentPackages > 0 ? false : true);
        Time.timeScale = victoryWindow.activeInHierarchy ? 0 : 1;
    }

    public void RestartButton() => SceneManager.LoadScene(0);
    public void QuitButton() => Application.Quit();

    private void ChangeStopwatchText(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);
        int milliseconds = Mathf.FloorToInt((time * 100) % 100);

        stopwatchText.text = "Time passed: " + string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
    }
}
