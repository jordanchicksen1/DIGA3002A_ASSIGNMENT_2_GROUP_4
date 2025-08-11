using UnityEngine;
using UnityEngine.UI;

public class rActionUI : MonoBehaviour
{

    public float maxRBar;
    public float currentRBar;
    public Image rBarPic;

    public bool shouldFillRBar = false;

    public Player player;

    public void Start()
    {
        maxRBar = player.artCooldownTime;
        currentRBar = maxRBar;
    }

    public void Update()
    {
        RefillRBar();
    }

    public void RefillRBar()
    {
        if (shouldFillRBar == true && currentRBar < player.artCooldownTime)
        {
            currentRBar += Time.deltaTime;
            updateRBar();
        }
    }

    public void UseRBar()
    {
        currentRBar = currentRBar - player.artCooldownTime;
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
