using Unity.Mathematics;
using UnityEngine;

public class HubManager : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject player;
    void Start()
    {
        Vector3 spawn = spawnPoint.position;
        Quaternion rotation = spawnPoint.rotation;
        Instantiate(player, spawn, rotation);
    }

}
