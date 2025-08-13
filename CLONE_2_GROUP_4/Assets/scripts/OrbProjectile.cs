using UnityEngine;

public class OrbProjectile : MonoBehaviour
{
    private Transform playerTransform;
    private Vector3 initialDirection;
    private float speed;
    private float maxRange;
    private float damage;
    private LayerMask damageLayers;

    private Vector3 startPosition;
    private bool isReturning = false;
    private bool hasHitOnForward = false;
    private bool hasHitOnReturn = false;

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
        if (playerTransform == null)
        {
            Destroy(gameObject);
            return;
        }

        if (!isReturning)
        {
            transform.position += initialDirection * speed * Time.deltaTime;

            if (Vector3.Distance(startPosition, transform.position) >= maxRange)
            {
                isReturning = true;
            }
        }
        else
        {
            Vector3 returnDirection = (playerTransform.position - transform.position).normalized;
            transform.position += returnDirection * speed * Time.deltaTime;

            if (Vector3.Distance(playerTransform.position, transform.position) < 0.5f)
            {
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collider is on a damageable layer
        if (((1 << other.gameObject.layer) & damageLayers) != 0)
        {
            // Apply damage logic
            if (!isReturning && !hasHitOnForward)
            {
                hasHitOnForward = true;
            }
            else if (isReturning && !hasHitOnReturn)
            {
                hasHitOnReturn = true;
            }
        }
    }
}
