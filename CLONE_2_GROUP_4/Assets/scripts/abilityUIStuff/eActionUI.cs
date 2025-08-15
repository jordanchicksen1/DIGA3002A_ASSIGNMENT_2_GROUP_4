using UnityEngine;
using UnityEngine.UI;

public class eActionUI : MonoBehaviour
{
    public float maxEBar;
    public float currentEBar;
    public Image eBarPic;

    public bool shouldFillEBar = false;

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
            maxEBar = playerScript.artCooldownTime;
            currentEBar = maxEBar;
        }
        else
        {
            Debug.LogError("Player script not found on: " + player.name);
        }
    }

    public void Update()
    {
        RefillEBar();
    }

    public void RefillEBar()
    {
        if (shouldFillEBar == true && currentEBar < playerScript.artCooldownTime)
        {
            currentEBar += Time.deltaTime;
            updateEBar();
        }
    }

    public void UseEBar()
    {
        currentEBar = currentEBar - playerScript.artCooldownTime;
        updateEBar();
    }
    public void updateE(float amount)
    {
        currentEBar += amount;
        updateEBar();

    }

    public void updateEBar()
    {
        float targetFillAmount = currentEBar / maxEBar;
        eBarPic.fillAmount = targetFillAmount;
    }
}
