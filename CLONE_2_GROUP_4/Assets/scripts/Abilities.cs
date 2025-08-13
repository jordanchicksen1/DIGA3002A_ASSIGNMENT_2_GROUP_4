using UnityEngine;
using UnityEngine.InputSystem;


public class Abilities : MonoBehaviour
{
    [Header("Q Ability Settings")]
    [SerializeField] private GameObject orbPrefab;
    [SerializeField] private float orbSpeed = 10f;
    [SerializeField] private float maxRange = 7f;
    [SerializeField] private float damage = 30f;
    [SerializeField] private LayerMask damageLayers;

    private Player player;

    private void Start()
    {
        player = GetComponent<Player>();
    }

    void Update()
    {
       
    }

    public void CastQAbility()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        mousePos.z = 0;

        //Vector3 direction = (mousePos - transform.position).normalized;
        Vector3 direction = (player.abilityTarget.position - player.transform.position).normalized;

        GameObject orb = Instantiate(orbPrefab, transform.position, Quaternion.identity);
        OrbProjectile orbScript = orb.GetComponent<OrbProjectile>();

        orbScript.Initialize(transform, direction, orbSpeed, maxRange, damage, damageLayers);
    }
}

