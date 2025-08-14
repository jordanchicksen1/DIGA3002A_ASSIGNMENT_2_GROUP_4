using UnityEngine;

public class CharmProjectile : MonoBehaviour
{
    private Transform playerTransform;
    private Vector3 initialDirection;
    private float speed;
    private float maxRange;
    private float damage;
    private LayerMask damageLayers;

    private Vector3 startPosition;
    private bool hasHit = false;

    public void Initialize(Transform player, Vector3 direction, float projectileSpeed, float range, float dmg, LayerMask layers)
    {
        playerTransform = player;
        initialDirection = direction;
        speed = projectileSpeed;
        maxRange = range;
        damage = dmg;
        damageLayers = layers;
        startPosition = player.position;
    }

    void Update()
    {
        if (hasHit) return;

        transform.position += initialDirection * speed * Time.deltaTime;

        if (Vector3.Distance(startPosition, transform.position) >= maxRange)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (hasHit) return;

        // Check if the collider is on a damageable layer
        if (((1 << other.gameObject.layer) & damageLayers) != 0)
        {
            // Apply charm effect
      
            hasHit = true;
            Destroy(gameObject);
        }
    }
}
