using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endTheDamnGame : MonoBehaviour
{
    public void EndGame()
    {
        StartCoroutine(EndTheDamnGame());
    }
   public IEnumerator EndTheDamnGame()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("END");
    }
}
