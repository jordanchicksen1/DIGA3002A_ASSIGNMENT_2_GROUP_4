using UnityEngine;
using UnityEngine.UI;

public class eActionUI : MonoBehaviour
{
    public float maxEBar;
    public float currentEBar;
    public Image eBarPic;

    public bool shouldFillEBar = false;

    public Player player;

    public void Start()
    {
        maxEBar = player.artCooldownTime;
        currentEBar = maxEBar;
    }

    public void Update()
    {
        RefillEBar();
    }

    public void RefillEBar()
    {
        if (shouldFillEBar == true && currentEBar < player.artCooldownTime)
        {
            currentEBar += Time.deltaTime;
            updateEBar();
        }
    }

    public void UseEBar()
    {
        currentEBar = currentEBar - player.artCooldownTime;
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
