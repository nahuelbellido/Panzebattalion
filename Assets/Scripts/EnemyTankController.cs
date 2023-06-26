using UnityEngine;

public class EnemyTankController : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;
    private GameManager gameManager; 

    private void Start()
    {
        currentHealth = maxHealth;
        gameManager = FindObjectOfType<GameManager>(); 
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);

        if (currentHealth <= 0f)
        {
            Destroy(gameObject); 
            gameManager.TankDestroyed(); 
        }
    }
}
