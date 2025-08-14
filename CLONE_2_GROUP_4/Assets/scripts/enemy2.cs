using System.Collections;
using UnityEngine;

public class enemy2 : MonoBehaviour
{
    public bool isInEnemy2Range = false;

    //looking and moving towards player
    public float enemy2Speed = 8f;
    private Transform playerTransform;
    public Transform stayingPoint;

    //shooting bullet at player
    public GameObject bullet;
    public Transform spawnPoint;
    public float shootTime;
    public float shootRecoveryTime;
    public float bulletSpeed;

    public void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        if (isInEnemy2Range == true)
        {
            this.gameObject.transform.LookAt(playerTransform);
            transform.position = Vector3.MoveTowards(transform.position, playerTransform.transform.position, enemy2Speed * Time.deltaTime);

            shootTime += Time.deltaTime;

            if (shootTime > shootRecoveryTime)
            {
                shootTime = 0;
                StartCoroutine(ShootingThreeBullets());
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, stayingPoint.transform.position, enemy2Speed * Time.deltaTime);
        }

    }

    public IEnumerator ShootingThreeBullets()
    {
        yield return new WaitForSeconds(0f);
        var projectile = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);

        var rb = projectile.GetComponent<Rigidbody>();
        rb.linearVelocity = spawnPoint.forward * bulletSpeed;

        Destroy(projectile, 2f);
        
        yield return new WaitForSeconds(0.5f);
        var projectile2 = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);

        var rb2 = projectile2.GetComponent<Rigidbody>();
        rb2.linearVelocity = spawnPoint.forward * bulletSpeed;

        Destroy(projectile2, 2f);

        yield return new WaitForSeconds(0.5f);
        var projectile3 = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);

        var rb3 = projectile3.GetComponent<Rigidbody>();
        rb3.linearVelocity = spawnPoint.forward * bulletSpeed;

        Destroy(projectile3, 2f);
    }
}
