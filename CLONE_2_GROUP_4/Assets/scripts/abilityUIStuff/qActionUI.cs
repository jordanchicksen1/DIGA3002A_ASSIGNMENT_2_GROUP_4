using UnityEngine;
using UnityEngine.UI;

public class qActionUI : MonoBehaviour
{
    public float maxQBar;
    public float currentQBar;
    public Image qBarPic;

    public bool shouldFillQBar = false;

    public PlayersPersistence playerScript;

    
    public void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");

        if (player == null)
        {
            Debug.LogError("No object with tag 'Player' found!");
            return;
        }

       
        playerScript = player.GetComponent<PlayersPersistence>();
        if (playerScript == null)
        {
            playerScript = player.GetComponentInChildren < PlayersPersistence>();
        }

        if (playerScript != null)
        {
            maxQBar = playerScript.artCooldownTime;
            currentQBar = maxQBar;
        }
        else
        {
            Debug.LogError("Player script not found on: " + player.name);
        }

    }

    public void Update()
    {
        RefillQBar();
    }

    public void RefillQBar()
    {
        if (shouldFillQBar == true && currentQBar < playerScript.artCooldownTime)
        {
            currentQBar += Time.deltaTime;
            updateQBar();
        }
    }

    public void UseQBar()
    {
        currentQBar = currentQBar - playerScript.artCooldownTime;
        updateQBar();
    }
    public void updateQ(float amount)
    {
        currentQBar += amount;
        updateQBar();

    }

    public void updateQBar()
    {
        float targetFillAmount = currentQBar / maxQBar;
        qBarPic.fillAmount = targetFillAmount;
    }
}
