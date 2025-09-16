using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PackagesController packagesScript;
    [SerializeField] private DriverUIManagement driverUIManagement;

    private bool gameWon = false;

    private void Update()
    {
        if (!gameWon && packagesScript.CurrentPackages <= 0)
        {
            WinGame();
        }
    }

    private void WinGame()
    {
        gameWon = true;
        driverUIManagement.ShowVictory();
        Time.timeScale = 0;
    }
}
