using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class scenechanger : MonoBehaviour
{
    //Load layer levels according to what layer the player is on (current layer on player script)
    //Find layers according to current layer level by searching for resources that have layer_(currentlevel) in the name
    //Store them in this list
    public List<string> scenes = new List<string>();
    public GameObject player;
    public GameObject[] levels;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        int currentLayer = player.GetComponent<PlayersPersistence>().currentLayer;
        Debug.Log(currentLayer);

        levels = Resources.LoadAll<GameObject>("Assets/Scenes/Levels");
        String layerToFind = "Layer" + (currentLayer+1).ToString();
        GameObject[] currentLayerLevels = levels.Where(go => go.name.Contains("layerToFind")).ToArray();
        
        foreach (GameObject obj in currentLayerLevels)
        {
            Debug.Log("Found resource: " + obj.name);
        }
        
        Debug.Log("The level started!!");
    }
    
    void Update()
    {
        
    }
}
