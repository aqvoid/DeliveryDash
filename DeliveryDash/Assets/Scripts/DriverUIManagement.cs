using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DriverUIManagement : MonoBehaviour
{
    private int currentPackages;

    [Header("UI")]
    [SerializeField] internal TMP_Text boostText;
    [SerializeField] private TMP_Text packagesText;
    [SerializeField] private GameObject victoryWindow;

    private void Awake()
    {
        ToggleBoostText(false);
    }

    private void Update()
    {
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

}
