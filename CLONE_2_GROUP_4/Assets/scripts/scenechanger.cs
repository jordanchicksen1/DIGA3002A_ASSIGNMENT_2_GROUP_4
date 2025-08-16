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
        player.GetComponent<PlayersPersistence>().levelDone = false;
        levelToLoad += "_";
        levelToLoad += sub.ToString();
        Debug.Log(levelToLoad);
        SceneManager.LoadScene(levelToLoad);
        levelToLoad = "";
        player.GetComponent<PlayersPersistence>().currentLayer += 1;
        levelToLoad = "Layer";
        int currentLayer = player.GetComponent<PlayersPersistence>().currentLayer;
        levelToLoad += (currentLayer+1).ToString();
        player.transform.position = new Vector3(0,1.5f,0);
    }
}
