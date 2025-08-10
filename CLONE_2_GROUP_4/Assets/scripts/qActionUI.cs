using UnityEngine;
using UnityEngine.UI;

public class qActionUI : MonoBehaviour
{
    public float maxQBar = 3f;
    public float currentQBar;
    public Image qBarPic;

    public bool shouldFillQBar = false;

    public void Start()
    {
        currentQBar = maxQBar;
    }

    public void Update()
    {
        RefillQBar();
    }

    public void RefillQBar()
    {
        if (shouldFillQBar == true && currentQBar < 3)
        {
            currentQBar += Time.deltaTime;
            updateQBar();
        }
    }

    public void UseQBar()
    {
        currentQBar = currentQBar - 3f;
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
