using UnityEngine;
using UnityEngine.UI;

public class wActionUI : MonoBehaviour
{
    public float maxWBar;
    public float currentWBar;
    public Image wBarPic;

    public bool shouldFillWBar = false;

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
            playerScript = player.GetComponentInChildren<PlayersPersistence>();
        }

        if (playerScript != null)
        {
            maxWBar = playerScript.artCooldownTime;
            currentWBar = maxWBar;
        }
        else
        {
            Debug.LogError("Player script not found on: " + player.name);
        }
    }

    public void Update()
    {
        RefillWBar();
    }

    public void RefillWBar()
    {
        if (shouldFillWBar == true && currentWBar < playerScript.artCooldownTime)
        {
            currentWBar += Time.deltaTime;
            updateWBar();
        }
    }

    public void UseWBar()
    {
        currentWBar = currentWBar - playerScript.artCooldownTime;
        updateWBar();
    }
    public void updateW(float amount)
    {
        currentWBar += amount;
        updateWBar();

    }

    public void updateWBar()
    {
        float targetFillAmount = currentWBar / maxWBar;
        wBarPic.fillAmount = targetFillAmount;
    }
}
