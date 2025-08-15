using UnityEngine;

public class FoxFireProjectile : MonoBehaviour
{
    private Transform playerTransform;
    private float damage;
    private float detectionRange;
    private float speed;
    private float lifetime;
    private LayerMask enemyLayers;

    private Transform currentTarget;
    private bool isAttached = true;
    private float orbitAngle;
    private float orbitDistance = 1f;
    private float orbitSpeed = 180f;
    private float timeAlive = 0f;

    public void Initialize(Transform player, float dmg, float range, float projectileSpeed, float duration, LayerMask layers, float startAngle)
    {
        playerTransform = player;
        damage = dmg;
        detectionRange = range;
        speed = projectileSpeed;
        lifetime = duration;
        enemyLayers = layers;
        orbitAngle = startAngle;
    }

    void Update()
    {
        timeAlive += Time.deltaTime;

        if (timeAlive >= lifetime)
        {
            Destroy(gameObject);
            return;
        }

        if (playerTransform == null)
        {
            Destroy(gameObject);
            return;
        }

        if (isAttached)
        {
            OrbitPlayer();
            CheckForTargets();
        }
        else if (currentTarget != null)
        {
            ChaseTarget();
        }
        else
        {
            // No target found, return to player
            ReturnToPlayer();
        }
    }

    private void OrbitPlayer()
    {
        orbitAngle += orbitSpeed * Time.deltaTime;
        if (orbitAngle > 360f) orbitAngle -= 360f;

        Vector3 orbitDirection = Quaternion.Euler(0, orbitAngle, 0) * Vector3.right;
        Vector3 orbitPosition = playerTransform.position + orbitDirection * orbitDistance;
        transform.position = Vector3.Lerp(transform.position, orbitPosition, 10f * Time.deltaTime);
    }

    private void CheckForTargets()
    {
        Collider[] hits = Physics.OverlapSphere(playerTransform.position, detectionRange, enemyLayers);

        if (hits.Length > 0)
        {
            // Find closest enemy
            Transform closest = null;
            float closestDistance = Mathf.Infinity;

            foreach (Collider hit in hits)
            {
                // Skip if this is the current target (for when multiple fox-fires exist)
                if (currentTarget != null && hit.transform == currentTarget) continue;

                float distance = Vector3.Distance(transform.position, hit.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closest = hit.transform;
                }
            }

            if (closest != null)
            {
                currentTarget = closest;
                isAttached = false;
            }
        }
    }

    private void ChaseTarget()
    {
        if (currentTarget == null)
        {
            ReturnToPlayer();
            return;
        }

        Vector3 direction = (currentTarget.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;

        /*if (Vector3.Distance(transform.position, currentTarget.position) < 0.5f)
        {
            DealDamage();
            Destroy(gameObject);
        }
        */
    }

    private void ReturnToPlayer()
    {
        if (Vector3.Distance(transform.position, playerTransform.position) < 0.5f)
        {
            isAttached = true;
        }
        else
        {
            Vector3 direction = (playerTransform.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the collider is on a damageable layer
        if (((1 << other.gameObject.layer) & enemyLayers) != 0)
        {        
            other.GetComponent<EnemyHealth>().EnemyHit(damage);
            Destroy(gameObject);
        }
    }

    private void DealDamage()
    {
        if (currentTarget != null)
        {
            currentTarget.GetComponent<EnemyHealth>().EnemyHit(damage);
        }
    }
}