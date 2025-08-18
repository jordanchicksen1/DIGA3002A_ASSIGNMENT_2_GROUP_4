using System.Collections;
using UnityEngine;

public class boss : MonoBehaviour
{
    private Transform player;
    public bool startBossFight = false;
    public float bossStartTime = 3f;
    public bossHealth bossHealth;

    //movetowards
    public bool pointA = false;
    public bool pointB = false;
    public bool pointC = false;
    public bool pointD = false;
    public bool pointE = false;
    public bool pointF = false;
    public bool pointG = false;

    public Transform stayingPoint;
    public Transform pA;
    public Transform pB;
    public Transform pC;
    public Transform pD;
    public Transform pE;
    public Transform pF;
    public Transform pG;
    public float bossSpeed;
    public float originalBossSpeed;

    //shoots projectiles at the player in waves
    public GameObject bullet;
    public Transform shootPoint1;
    public Transform shootPoint2;
    public Transform shootPoint3;
    public Transform shootPoint4;
    public Transform shootPoint5;
    public Transform shootPoint6;
    public float shootTime;
    public float shootRecoveryTime;
    public float shootTime2;
    public float shootRecoveryTime2;
    public float bulletSpeed;

    //spawning other enemies
    //spawning other enemies
    public GameObject spawnedEnemy;
    public GameObject spawnedEnemy2;
    public Transform enemySpawnPoint1;
    public Transform enemySpawnPoint2;
    public float spawnTime;
    public float spawnRecoveryTime;

    public GameObject bossHealthBar;

    public void Start()
    {
        
        player = GameObject.FindWithTag("Player").transform;
        originalBossSpeed = bossSpeed;
        StartCoroutine(StartTheDamnBossFight());
    }
    void Update()
    {
        //movement stuff
        {
            if (startBossFight == true && pointA == false && pointB == false && pointC == false && pointD == false && pointE == false && pointF == false && pointG == false)
            {
                this.gameObject.transform.LookAt(player);
                transform.position = Vector3.MoveTowards(transform.position, pA.transform.position, bossSpeed * Time.deltaTime);
            }

            if (startBossFight == true && pointA == true && pointB == false && pointC == false && pointD == false && pointE == false && pointF == false && pointG == false)
            {
                this.gameObject.transform.LookAt(player);
                transform.position = Vector3.MoveTowards(transform.position, pB.transform.position, bossSpeed * Time.deltaTime);
            }

            if (startBossFight == true && pointA == false && pointB == true && pointC == false && pointD == false && pointE == false && pointF == false && pointG == false)
            {
                this.gameObject.transform.LookAt(player);
                transform.position = Vector3.MoveTowards(transform.position, pC.transform.position, bossSpeed * Time.deltaTime);
            }

            if (startBossFight == true && pointA == false && pointB == false && pointC == true && pointD == false && pointE == false && pointF == false && pointG == false)
            {
                this.gameObject.transform.LookAt(player);
                transform.position = Vector3.MoveTowards(transform.position, pD.transform.position, bossSpeed * Time.deltaTime);
            }

            if (startBossFight == true && pointA == false && pointB == false && pointC == false && pointD == true && pointE == false && pointF == false && pointG == false)
            {
                this.gameObject.transform.LookAt(player);
                transform.position = Vector3.MoveTowards(transform.position, pE.transform.position, bossSpeed * Time.deltaTime);
            }

            if (startBossFight == true && pointA == false && pointB == false && pointC == false && pointD == false && pointE == true && pointF == false && pointG == false)
            {
                this.gameObject.transform.LookAt(player);
                transform.position = Vector3.MoveTowards(transform.position, pF.transform.position, bossSpeed * Time.deltaTime);
            }

            if (startBossFight == true && pointA == false && pointB == false && pointC == false && pointD == false && pointE == false && pointF == true && pointG == false)
            {
                this.gameObject.transform.LookAt(player);
                transform.position = Vector3.MoveTowards(transform.position, pG.transform.position, bossSpeed * Time.deltaTime);
            }

            if (startBossFight == true && pointA == false && pointB == false && pointC == false && pointD == false && pointE == false && pointF == false && pointG == true)
            {
                this.gameObject.transform.LookAt(player);
                transform.position = Vector3.MoveTowards(transform.position, pA.transform.position, bossSpeed * Time.deltaTime);
            }

            if (startBossFight == false)
            {
                transform.position = Vector3.MoveTowards(transform.position, stayingPoint.transform.position, bossSpeed * Time.deltaTime);
            }
        }

        //shooting stuff
        if(startBossFight == true)
        {
            shootTime += Time.deltaTime;
            shootTime2 += Time.deltaTime;

            if (shootTime > shootRecoveryTime)
            {
                shootTime = 0;
                {
                    var projectile = Instantiate(bullet, shootPoint1.position, shootPoint1.rotation);

                    var rb = projectile.GetComponent<Rigidbody>();
                    rb.linearVelocity = shootPoint1.forward * bulletSpeed;

                    Destroy(projectile, 2f);
                }

                {
                    var projectile2 = Instantiate(bullet, shootPoint2.position, shootPoint2.rotation);

                    var rb2 = projectile2.GetComponent<Rigidbody>();
                    rb2.linearVelocity = shootPoint2.forward * bulletSpeed;

                    Destroy(projectile2, 2f);
                }

                {
                    var projectile3 = Instantiate(bullet, shootPoint3.position, shootPoint3.rotation);

                    var rb3 = projectile3.GetComponent<Rigidbody>();
                    rb3.linearVelocity = shootPoint3.forward * bulletSpeed;

                    Destroy(projectile3, 2f);
                }

            }

            if (shootTime2 > shootRecoveryTime2)
            {
                shootTime2 = 0;
                {
                    var projectile4 = Instantiate(bullet, shootPoint4.position, shootPoint4.rotation);

                    var rb4 = projectile4.GetComponent<Rigidbody>();
                    rb4.linearVelocity = shootPoint4.forward * bulletSpeed;

                    Destroy(projectile4, 2f);
                }

                {
                    var projectile5 = Instantiate(bullet, shootPoint5.position, shootPoint5.rotation);

                    var rb5 = projectile5.GetComponent<Rigidbody>();
                    rb5.linearVelocity = shootPoint5.forward * bulletSpeed;

                    Destroy(projectile5, 2f);
                }

                {
                    var projectile6 = Instantiate(bullet, shootPoint6.position, shootPoint6.rotation);

                    var rb6 = projectile6.GetComponent<Rigidbody>();
                    rb6.linearVelocity = shootPoint6.forward * bulletSpeed;

                    Destroy(projectile6, 2f);
                }

            }
        }

        //spawning stuff
        if(startBossFight == true)
        {
            spawnTime += Time.deltaTime;

            if (spawnTime > spawnRecoveryTime)
            {
                spawnTime = 0;
                {
                   var spawnedEnemyFirst =   Instantiate(spawnedEnemy, enemySpawnPoint1.position, enemySpawnPoint1.rotation);
                   var spawnedEnemySecond = Instantiate(spawnedEnemy2, enemySpawnPoint2.position, enemySpawnPoint2.rotation);

                    Destroy(spawnedEnemyFirst, spawnRecoveryTime);
                    Destroy(spawnedEnemySecond, spawnRecoveryTime);
                }


            }
        }

    }

    public void OnTriggerEnter(Collider other)
    {
      
       if (other.tag == "PointA")
        {
            pointA = true;
            pointB = false;
            pointC = false;
            pointD = false;
            pointE = false;
            pointF = false;
            pointG = false;
            Debug.Log("is at pointA");
        }

        if (other.tag == "PointB")
        {
            pointA = false;
            pointB = true;
            pointC = false;
            pointD = false;
            pointE = false;
            pointF = false;
            pointG = false;
            Debug.Log("is at pointB");
        }

        if (other.tag == "PointC")
        {
            pointA = false;
            pointB = false;
            pointC = true;
            pointD = false;
            pointE = false;
            pointF = false;
            pointG = false;
            Debug.Log("is at pointC");
        }

        if (other.tag == "PointD")
        {
            pointA = false;
            pointB = false;
            pointC = false;
            pointD = true;
            pointE = false;
            pointF = false;
            pointG = false;
            Debug.Log("is at pointD");
        }

        if (other.tag == "PointE")
        {
            pointA = false;
            pointB = false;
            pointC = false;
            pointD = false;
            pointE = true;
            pointF = false;
            pointG = false;
            Debug.Log("is at pointE");
        }

        if (other.tag == "PointF")
        {
            pointA = false;
            pointB = false;
            pointC = false;
            pointD = false;
            pointE = false;
            pointF = true;
            pointG = false;
            Debug.Log("is at pointF");
        }

        if (other.tag == "PointG")
        {
            pointA = false;
            pointB = false;
            pointC = false;
            pointD = false;
            pointE = false;
            pointF = false;
            pointG = true;
            Debug.Log("is at pointF");
        }



    }

    public IEnumerator StartTheDamnBossFight()
    {
        yield return new WaitForSeconds(bossStartTime);
        startBossFight = true;
        bossHealthBar.SetActive(true);
    }

    public void DoubleStats()
    {
        bossSpeed = bossSpeed * 1.2f;
    }

    public void RevertStats()
    {
        bossSpeed = originalBossSpeed;
    }

    
}
