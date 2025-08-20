using UnityEngine;

using UnityEngine.SceneManagement;

public class uiManager : MonoBehaviour
{
    public PlayersPersistence playersPersistence;
    public GameObject pauseScreen;
    public GameObject player;
   public void QuitMenu()
    {
        pauseScreen.SetActive(false);
        playersPersistence.isPaused = false;
        Time.timeScale = 1f;

    }
    
    public void Retry()
    {
        Destroy(player);
        SceneManager.LoadScene("Hub");
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }

   


}
