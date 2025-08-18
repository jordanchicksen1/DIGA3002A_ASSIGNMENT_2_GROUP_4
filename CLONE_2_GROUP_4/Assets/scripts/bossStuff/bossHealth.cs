using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class bossHealth : MonoBehaviour
{
    public float maxHealth = 500f;
    public float currentHealth;
    public Image healthBar;
    
    public GameObject bossWhole;
    public GameObject endgameScriptGameobject;


    public void Start()
    {
        currentHealth = maxHealth;
        updateHealthBar();
        
    }

    public void Update()
    {
        if (currentHealth <= 0 )
        {
           
            endTheDamnGame endGame = endgameScriptGameobject.GetComponent<endTheDamnGame>();
            endGame.EndGame();
            Destroy(bossWhole);
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
