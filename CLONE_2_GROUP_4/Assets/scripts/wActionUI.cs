using UnityEngine;
using UnityEngine.UI;

public class wActionUI : MonoBehaviour
{
    public float maxWBar;
    public float currentWBar;
    public Image wBarPic;

    public bool shouldFillWBar = false;

    public Player player;

    public void Start()
    {
        maxWBar = player.artCooldownTime;
        currentWBar = maxWBar;
    }

    public void Update()
    {
        RefillWBar();
    }

    public void RefillWBar()
    {
        if (shouldFillWBar == true && currentWBar < player.artCooldownTime)
        {
            currentWBar += Time.deltaTime;
            updateWBar();
        }
    }

    public void UseWBar()
    {
        currentWBar = currentWBar - player.artCooldownTime;
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
