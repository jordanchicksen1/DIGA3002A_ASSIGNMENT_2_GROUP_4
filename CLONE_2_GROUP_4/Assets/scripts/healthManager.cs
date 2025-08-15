using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class healthManager : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;
    public Image healthBar;
   //ublic TextMeshProUGUI healthText;
    public GameObject gameOverScreen;



    public void Start()
    {
        currentHealth = maxHealth;
        updateHealthBar();
    }

    public void Update()
    {
        if (currentHealth <= 0)
        {
            gameOverScreen.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
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

    [ContextMenu("PlayerHit")]
    public void PlayerHit()
    {
        currentHealth = currentHealth - 10f;
        updateHealthBar();
      //healthText.text = currentHealth.ToString();

    }

    [ContextMenu("PlayerHitMore")]
    public void PlayerHitMore()
    {
        currentHealth = currentHealth - 30f;
        updateHealthBar();
        //healthText.text = currentHealth.ToString();

    }

    [ContextMenu("Damage Zone")]
    public void DamageZoneHit()
    {
        currentHealth = currentHealth - 0.1f;
        updateHealthBar();
       //ealthText.text = currentHealth.ToString();

    }


    [ContextMenu("PlayerHeal")]
    public void PlayerHeal()
    {
        currentHealth = currentHealth + 10f;
        updateHealthBar();
       //ealthText.text = currentHealth.ToString();

    }
}
