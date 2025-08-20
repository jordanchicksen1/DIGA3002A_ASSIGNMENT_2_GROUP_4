using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadHub : MonoBehaviour
{
    public void load()
    {
        SceneManager.LoadScene("Assets/Scenes/Levels/Hub.unity");
    }
}
