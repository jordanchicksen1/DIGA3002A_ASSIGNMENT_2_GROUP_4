using System;
using UnityEngine;

public class Persistence : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject); //DontDestroyOnLoad for persistence
    }
}
