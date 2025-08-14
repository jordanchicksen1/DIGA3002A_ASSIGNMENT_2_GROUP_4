using UnityEngine;
using UnityEngine.Rendering;

public class enemy1 : MonoBehaviour
{
    public bool isInEnemyRange = false;

    //looking and moving towards player
    public float enemySpeed = 8f;
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
        if(isInEnemyRange == true)
        {
            this.gameObject.transform.LookAt(playerTransform);
            transform.position = Vector3.MoveTowards(transform.position, playerTransform.transform.position, enemySpeed * Time.deltaTime);

            shootTime += Time.deltaTime;

            if (shootTime > shootRecoveryTime)
            {
                shootTime = 0;
                var projectile = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);

                var rb = projectile.GetComponent<Rigidbody>();
                rb.linearVelocity = spawnPoint.forward * bulletSpeed;

                Destroy(projectile, 2f);
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, stayingPoint.transform.position, enemySpeed * Time.deltaTime);
        }

    }
}
