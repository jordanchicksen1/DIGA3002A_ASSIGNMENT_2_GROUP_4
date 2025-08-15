using UnityEngine;
using UnityEngine.UI;

public class rActionUI : MonoBehaviour
{

    public float maxRBar;
    public float currentRBar;
    public Image rBarPic;

    public bool shouldFillRBar = false;

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
            maxRBar = playerScript.artCooldownTime;
            currentRBar = maxRBar;
        }
        else
        {
            Debug.LogError("Player script not found on: " + player.name);
        }
    }

    public void Update()
    {
        RefillRBar();
    }

    public void RefillRBar()
    {
        if (shouldFillRBar == true && currentRBar < playerScript.artCooldownTime)
        {
            currentRBar += Time.deltaTime;
            updateRBar();
        }
    }

    public void UseRBar()
    {
        currentRBar = currentRBar - playerScript.artCooldownTime;
        updateRBar();
    }
    public void updateR(float amount)
    {
        currentRBar += amount;
        updateRBar();

    }

    public void updateRBar()
    {
        float targetFillAmount = currentRBar / maxRBar;
        rBarPic.fillAmount = targetFillAmount;
    }
}
