using UnityEngine;
using UnityEngine.UI;

public class wActionUI : MonoBehaviour
{
    public float maxWBar = 3f;
    public float currentWBar;
    public Image wBarPic;

    public bool shouldFillWBar = false;

    public void Start()
    {
        currentWBar = maxWBar;
    }

    public void Update()
    {
        RefillWBar();
    }

    public void RefillWBar()
    {
        if (shouldFillWBar == true && currentWBar < 3)
        {
            currentWBar += Time.deltaTime;
            updateWBar();
        }
    }

    public void UseWBar()
    {
        currentWBar = currentWBar - 3f;
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
