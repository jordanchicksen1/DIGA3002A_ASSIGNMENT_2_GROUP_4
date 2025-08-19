using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
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

    public void upgrade(string stat)
    {
        //Reference to ability script
        Abilities abilities = player.GetComponent<Abilities>();
        
        switch (stat)
        {
            case "Range":
                abilities.maxRange++;
                abilities.foxFireDetectionRange++;
                abilities.charmMaxRange++;
                break;
            case "Damage":
                abilities.damage++;
                abilities.foxFireDamage++;
                abilities.charmDamage++;
                break;
            case "Speed":
                abilities.speedBoost++;
                abilities.speedBoostDuration++;
                abilities.dashDistance++;
                abilities.dashDuration++;
                abilities.timeBetweenDashes++;
                break;
            case "ProjSpeed":
                abilities.orbSpeed++;
                abilities.foxFireSpeed++;
                abilities.charmSpeed++;
                break;
            case "Multi":
                abilities.foxFireCount++;
                abilities.maxDashes++;
                break;
        }
    }

    public void subLevelLoad(int sub)
    {
        player.GetComponent<PlayersPersistence>().levelDone = false;
        player.GetComponent<PlayersPersistence>().levelSelection.SetActive(false);
        levelToLoad += "_";
        levelToLoad += sub.ToString();
        Debug.Log(levelToLoad);
        if (levelToLoad.Contains("Layer5"))
        {
            SceneManager.LoadScene("Assets/Scenes/Levels/bossRoom.unity");
        }
        else
        {
            SceneManager.LoadScene(levelToLoad);
        }
        levelToLoad = "";
        player.GetComponent<PlayersPersistence>().currentLayer += 1;
        levelToLoad = "Layer";
        int currentLayer = player.GetComponent<PlayersPersistence>().currentLayer;
        levelToLoad += (currentLayer+1).ToString();
        player.transform.position = new Vector3(0,1.5f,0);
    }
}
