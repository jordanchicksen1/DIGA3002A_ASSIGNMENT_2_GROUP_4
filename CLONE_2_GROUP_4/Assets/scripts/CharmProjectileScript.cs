using UnityEngine;

public class CharmProjectile : MonoBehaviour
{
    private Transform playerTransform;
    private Vector3 initialDirection;
    private float speed;
    private float maxRange;
    private float damage;
    private LayerMask damageLayers;
    private float slow;
    private float duration;

    private Vector3 startPosition;
    private bool hasHit = false;

    public void Initialize(Transform player, Vector3 direction, float projectileSpeed, float range, float dmg, float charmDuration, float charmSpeed, LayerMask layers)
    {
        playerTransform = player;
        initialDirection = direction;
        speed = projectileSpeed;
        maxRange = range;
        damage = dmg;
        duration = charmDuration;
        slow = charmSpeed;
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
            other.GetComponent<EnemyHealth>().EnemyCharmed(damage, duration, slow);
            hasHit = true;
            Destroy(gameObject);
        }
    }
}
