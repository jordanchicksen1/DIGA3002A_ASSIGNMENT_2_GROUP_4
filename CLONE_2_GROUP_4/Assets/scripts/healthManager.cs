using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class healthManager : MonoBehaviour
{
    public float maxHealth = 10f;
    public float currentHealth;
    public Image healthBar;
    public TextMeshProUGUI healthText;
    public GameObject gameOverScreen;



    public void Start()
    {
        currentHealth = maxHealth;
        updateHealthBar();
    }

    public void Update()
    {
        if (currentHealth == 0)
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
    }

    [ContextMenu("PlayerHit")]
    public void PlayerHit()
    {
        currentHealth = currentHealth - 1f;
        updateHealthBar();
        healthText.text = currentHealth.ToString();

    }

    [ContextMenu("PlayerHeal")]
    public void PlayerHeal()
    {
        currentHealth = currentHealth + 1f;
        updateHealthBar();
        healthText.text = currentHealth.ToString();

    }
}
