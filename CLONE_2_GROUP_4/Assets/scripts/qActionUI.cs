using UnityEngine;
using UnityEngine.UI;

public class qActionUI : MonoBehaviour
{
    public float maxQBar;
    public float currentQBar;
    public Image qBarPic;

    public bool shouldFillQBar = false;

    public Player player;

    public void Start()
    {
       maxQBar = player.artCooldownTime;
        currentQBar = maxQBar;
    }

    public void Update()
    {
        RefillQBar();
    }

    public void RefillQBar()
    {
        if (shouldFillQBar == true && currentQBar < player.artCooldownTime)
        {
            currentQBar += Time.deltaTime;
            updateQBar();
        }
    }

    public void UseQBar()
    {
        currentQBar = currentQBar - player.artCooldownTime;
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
