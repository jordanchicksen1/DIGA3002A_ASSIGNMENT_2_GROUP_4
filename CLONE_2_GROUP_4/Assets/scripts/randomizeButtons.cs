using UnityEngine;

public class randomizeButtons : MonoBehaviour
{
    public GameObject[] buttons;

    void start()
    {
        scrambleButtons();
    }
    
    public void scrambleButtons()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].SetActive(true);
        }
        
        int rand1 = UnityEngine.Random.Range(0, buttons.Length-1);
        int rand2;
        do
        {
            rand2 = UnityEngine.Random.Range(0, buttons.Length-1);
        } while (rand2 == rand1);
        
        buttons[rand1].SetActive(false);
        buttons[rand2].SetActive(false);
    }
}
