using UnityEngine;
using UnityEngine.UI;

public class rActionUI : MonoBehaviour
{

    public float maxRBar = 3f;
    public float currentRBar;
    public Image rBarPic;

    public bool shouldFillRBar = false;

    public void Start()
    {
        currentRBar = maxRBar;
    }

    public void Update()
    {
        RefillRBar();
    }

    public void RefillRBar()
    {
        if (shouldFillRBar == true && currentRBar < 3)
        {
            currentRBar += Time.deltaTime;
            updateRBar();
        }
    }

    public void UseRBar()
    {
        currentRBar = currentRBar - 3f;
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
