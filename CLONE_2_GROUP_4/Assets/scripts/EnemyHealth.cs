using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    
    //Variables to increment the killcount in a level
    public GameObject spawnerScript;
    
    public float maxHealth = 50f;
    public float currentHealth;
    public Image healthBar;
    //ublic TextMeshProUGUI healthText;
    public GameObject enemyWhole;
    private float baseSpeed;



    public void Start()
    {
        spawnerScript = GameObject.Find("EnemySpawner");
        
        currentHealth = maxHealth;
        updateHealthBar();

        if (enemyWhole.GetComponent<enemy1>()  != null)
        {
            baseSpeed = enemyWhole.GetComponent<enemy1>().enemySpeed;
        }
        else if (enemyWhole.GetComponent<enemy2>() != null)
        {
            baseSpeed = enemyWhole.GetComponent<enemy2>().enemy2Speed;
        }
        else if (enemyWhole.GetComponent<enemy3>() != null)
        {
            baseSpeed = enemyWhole.GetComponent<enemy3>().enemy3Speed;
        }
        else if (enemyWhole.GetComponent<enemy4>() != null)
        {
            baseSpeed = enemyWhole.GetComponent<enemy4>().enemySpeed;
        }
        else if (enemyWhole.GetComponent<enemy5>() != null)
        {
            baseSpeed = enemyWhole.GetComponent<enemy5>().enemySpeed;
        }
    }

    public void Update()
    {
        if (currentHealth <= 0)
        {
            spawnerScript.GetComponent<enemySpawning>().enemiesKilled += 1;
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

    [ContextMenu("Enemy Hit")]
    public void EnemyHit(float dmg)
    {
        currentHealth = currentHealth - dmg;
        updateHealthBar();
    }
    [ContextMenu("Enemy Charmed")]
    public void EnemyCharmed(float dmg, float charmDuration, float charmSpeed)
    {
        currentHealth = currentHealth - dmg;
        if (enemyWhole.GetComponent<enemy1>() != null)
        {
            enemyWhole.GetComponent<enemy1>().enemySpeed *= charmSpeed;
            Invoke(nameof(ResetSpeed), charmDuration);
        }
        else if (enemyWhole.GetComponent<enemy2>() != null)
        {
            enemyWhole.GetComponent<enemy2>().enemy2Speed *= charmSpeed;
            Invoke(nameof(ResetSpeed), charmDuration);
        }
        else if (enemyWhole.GetComponent<enemy3>() != null)
        {
            enemyWhole.GetComponent<enemy3>().enemy3Speed *= charmSpeed;
            Invoke(nameof(ResetSpeed), charmDuration);
        }
        else if (enemyWhole.GetComponent<enemy4>() != null)
        {
            enemyWhole.GetComponent<enemy4>().enemySpeed *= charmSpeed;
            Invoke(nameof(ResetSpeed), charmDuration);
        }
        else if (enemyWhole.GetComponent<enemy5>() != null)
        {
            enemyWhole.GetComponent<enemy5>().enemySpeed *= charmSpeed;
            Invoke(nameof(ResetSpeed), charmDuration);
        }

        updateHealthBar();
    }

    private void ResetSpeed()
    {
        if (enemyWhole != null)
        {
            if (enemyWhole.GetComponent<enemy1>() != null)
            {
                enemyWhole.GetComponent<enemy1>().enemySpeed = baseSpeed;
            }
            else if (enemyWhole.GetComponent<enemy2>() != null)
            {
                enemyWhole.GetComponent<enemy2>().enemy2Speed = baseSpeed;
            }
            else if (enemyWhole.GetComponent<enemy3>() != null)
            {
                enemyWhole.GetComponent<enemy3>().enemy3Speed = baseSpeed;
            }
            else if (enemyWhole.GetComponent<enemy4>() != null)
            {
                enemyWhole.GetComponent<enemy4>().enemySpeed = baseSpeed;
            }
            else if (enemyWhole.GetComponent<enemy5>() != null)
            {
                enemyWhole.GetComponent<enemy5>().enemySpeed = baseSpeed;
            }
        }
    }
}
