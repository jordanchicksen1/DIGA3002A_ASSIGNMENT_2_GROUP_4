using UnityEngine;

public class enemy4 : MonoBehaviour
{
    public bool isInEnemy4Range = false;

  

    //looking and moving towards player
    public float enemySpeed = 2f;
    private Transform playerTransform;
    public Transform stayingPoint;
    

    //shooting bullet at player
    public GameObject bullet;
    public Transform spawnPoint;
    public Transform spawnPoint2;
    public Transform spawnPoint3;
    public float shootTime;
    public float shootRecoveryTime;
    public float bulletSpeed;


    public void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
        Debug.Log("found player enemy4");
    }
    void Update()
    {
        if (isInEnemy4Range == true)
        {
            this.gameObject.transform.LookAt(playerTransform);
            transform.position = Vector3.MoveTowards(transform.position, playerTransform.transform.position, enemySpeed * Time.deltaTime);

            shootTime += Time.deltaTime;

            if (shootTime > shootRecoveryTime)
            {
                shootTime = 0;
                {
                    var projectile = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);

                    var rb = projectile.GetComponent<Rigidbody>();
                    rb.linearVelocity = spawnPoint.forward * bulletSpeed;

                    Destroy(projectile, 2f);
                }

                {
                    var projectile2 = Instantiate(bullet, spawnPoint2.position, spawnPoint2.rotation);

                    var rb2 = projectile2.GetComponent<Rigidbody>();
                    rb2.linearVelocity = spawnPoint2.forward * bulletSpeed;

                    Destroy(projectile2, 2f);
                }

                {
                    var projectile3 = Instantiate(bullet, spawnPoint3.position, spawnPoint3.rotation);

                    var rb3 = projectile3.GetComponent<Rigidbody>();
                    rb3.linearVelocity = spawnPoint3.forward * bulletSpeed;

                    Destroy(projectile3, 2f);
                }

            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, stayingPoint.transform.position, enemySpeed * Time.deltaTime);
        }

    }
}
