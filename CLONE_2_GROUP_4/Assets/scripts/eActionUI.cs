using UnityEngine;
using UnityEngine.UI;

public class eActionUI : MonoBehaviour
{
    public float maxEBar = 3f;
    public float currentEBar;
    public Image eBarPic;

    public bool shouldFillEBar = false;

    public void Start()
    {
        currentEBar = maxEBar;
    }

    public void Update()
    {
        RefillEBar();
    }

    public void RefillEBar()
    {
        if (shouldFillEBar == true && currentEBar < 3)
        {
            currentEBar += Time.deltaTime;
            updateEBar();
        }
    }

    public void UseEBar()
    {
        currentEBar = currentEBar - 3f;
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
