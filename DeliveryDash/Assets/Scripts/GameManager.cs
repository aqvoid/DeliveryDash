using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PackagesController packagesScript;
    [SerializeField] private DriverUIManagement driverUIManagement;

    public bool GameWon { get; private set; }

    private void Update()
    {
        if (!GameWon && packagesScript.CurrentPackages <= 0) WinGame();
    }

    private void WinGame()
    {
        GameWon = true;
        driverUIManagement.ShowVictory();
        Time.timeScale = 0;
    }
}
