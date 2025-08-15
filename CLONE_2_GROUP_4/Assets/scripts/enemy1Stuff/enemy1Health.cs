using UnityEngine;
using UnityEngine.UI;

public class enemy1Health : MonoBehaviour
{
    public float maxHealth = 40f;
    public float currentHealth;
    public Image healthBar;
    //ublic TextMeshProUGUI healthText;
    public GameObject enemyWhole;



    public void Start()
    {
        currentHealth = maxHealth;
        updateHealthBar();
    }

    public void Update()
    {
        if (currentHealth <= 0)
        {
            Destroy(enemyWhole);
        }
    }

    public void updateHealth(float amount)
    {
        currentHealth += amount;

        updateHealthBar();

    }

    public void updateHealthBar()
    {
        float targetFillAmount = currentHealth / maxHealth;
        healthBar.fillAmount = targetFillAmount;
        //ealthText.text = currentHealth.ToString();
    }

    [ContextMenu("Enemy Hit Small")]
    public void EnemyHitSmall()
    {
        currentHealth = currentHealth - 10f;
        updateHealthBar();
    }

    [ContextMenu("Enemy Hit Medium")]
    public void EnemyHitMedium()
    {
        currentHealth = currentHealth - 20f;
        updateHealthBar();
    }

    [ContextMenu("Enemy Hit Large")]
    public void EnemyHitLarge()
    {
        currentHealth = currentHealth - 30f;
        updateHealthBar();
    }



}
