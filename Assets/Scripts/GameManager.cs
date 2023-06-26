using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject enemyTankPrefab; 
    public int numberOfTanksToSpawn = 5; 
    public Transform[] spawnPoints; 

    private int tanksDestroyed = 0; 

    private void Start()
    {
        SpawnEnemyTanks();
    }

    private void SpawnEnemyTanks()
    {
        for (int i = 0; i < numberOfTanksToSpawn; i++)
        {
            if (i >= spawnPoints.Length) 
                break;

            Transform spawnPoint = spawnPoints[i];
            GameObject enemyTank = Instantiate(enemyTankPrefab, spawnPoint.position, spawnPoint.rotation);

            EnemyTankController tankController = enemyTank.GetComponent<EnemyTankController>();
            if (tankController != null)
            {
                tankController.enabled = true;
            }
        }
    }

    public void TankDestroyed()
    {
        tanksDestroyed++;

        if (tanksDestroyed >= numberOfTanksToSpawn)
        {
            GoToMainMenu();
        }
    }
    private void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
