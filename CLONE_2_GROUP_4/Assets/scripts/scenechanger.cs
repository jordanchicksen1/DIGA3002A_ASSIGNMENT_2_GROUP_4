using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scenechanger : MonoBehaviour
{
    //Build a scene name string then load that scene
    public GameObject player;
    private string levelToLoad;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        levelToLoad = "Layer";
        int currentLayer = player.GetComponent<PlayersPersistence>().currentLayer;
        levelToLoad += (currentLayer+1).ToString();
        Debug.Log(levelToLoad);
    }

    public void subLevelLoad(int sub)
    {
        levelToLoad += "_";
        levelToLoad += sub.ToString();
        Debug.Log(levelToLoad);
        SceneManager.LoadScene(levelToLoad);
        levelToLoad = "";
        player.GetComponent<PlayersPersistence>().currentLayer += 1;
        player.GetComponent<PlayersPersistence>().levelDone = false;
        player.GetComponent<PlayersPersistence>().instruction.SetActive(true);
        player.GetComponent<PlayersPersistence>().levelSelection.SetActive(false);
        levelToLoad = "Layer";
        int currentLayer = player.GetComponent<PlayersPersistence>().currentLayer;
        levelToLoad += (currentLayer+1).ToString();
    }
}
