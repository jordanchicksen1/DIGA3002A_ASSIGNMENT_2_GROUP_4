using UnityEngine;
using UnityEngine.SceneManagement;

public class startScene : MonoBehaviour
{
    public GameObject titlePage;
    public GameObject page1;
    public GameObject playerModels;
    public GameObject page2;
    public GameObject enemiesPage2;
    public GameObject page3;
    public GameObject portalPage3;
    public GameObject page4;
    public GameObject bossPage4;
    public GameObject page5;

    public void StartButton()
    {
        titlePage.SetActive(false);
        page1.SetActive(true);
    }

    public void Next1()
    {
        page1.SetActive(false);
        playerModels.SetActive(false);
        page2.SetActive(true);
        enemiesPage2.SetActive(true);
    }

    public void Next2()
    {
        page2.SetActive(false);
        enemiesPage2.SetActive(false);
        page3.SetActive(true);
        portalPage3.SetActive(true);
    }

    public void Next3()
    {
        page3.SetActive(false);
        portalPage3.SetActive(false);
        page4.SetActive(true);
        bossPage4.SetActive(true);
    }

    public void Next4()
    {
        page4.SetActive(false);
        bossPage4.SetActive(false);
        page5.SetActive(true);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Hub");
    }

}
