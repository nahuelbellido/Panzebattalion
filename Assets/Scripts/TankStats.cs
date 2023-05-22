using UnityEngine;
using UnityEngine.UI;

public class TankStats : MonoBehaviour
{
    public float maxHealth = 100f;
    public float maxArmor = 100f;

    private float currentHealth;
    private float currentArmor;

    public Image healthBar;
    public Image armorBar;

    public GameObject gameOverPrefab; 

    private void Start()
    {
        currentHealth = maxHealth;
        currentArmor = maxArmor;

        UpdateHealthUI();
        UpdateArmorUI();
    }

    public void TakeDamage(float damage)
    {
        if (currentArmor > 0f)
        {
            
            currentArmor -= damage;
            currentArmor = Mathf.Clamp(currentArmor, 0f, maxArmor);
        }
        else
        {
           
            currentHealth -= damage;
            currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);

            if (currentHealth <= 0f)
            {
                
                Instantiate(gameOverPrefab);
                Destroy(gameObject); 
            }
        }

       
        UpdateHealthUI();
        UpdateArmorUI();
    }

    private void UpdateHealthUI()
    {
        
        float healthPercentage = currentHealth / maxHealth;

        
        healthPercentage = Mathf.Clamp01(healthPercentage);

        
        healthBar.fillAmount = healthPercentage;
    }

    private void UpdateArmorUI()
    {
        
        float armorPercentage = currentArmor / maxArmor;

       
        armorPercentage = Mathf.Clamp01(armorPercentage);

       
        armorBar.fillAmount = armorPercentage;
    }
}