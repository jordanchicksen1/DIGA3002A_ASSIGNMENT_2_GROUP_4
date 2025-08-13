using System.Collections;
using UnityEngine;

public class enemy3 : MonoBehaviour
{
    public bool isInEnemy3Range = false;
    //looking and moving towards player
    public float enemy3Speed = 2f;
    public float originalEnemy3Speed = 2f;
    public Transform player;
    public Transform stayingPoint;

    //shooting laser at player
    public GameObject laser;
    public float laserTime;
    public float laserRecoveryTime;
    public float rotationSpeed;

    public bool isDoingLaser = false;
    public Transform enemyNose;
    public float minRange;

    public healthManager healthManager;

    public void Update()
    {
        if (isInEnemy3Range)
        {
            if (!isDoingLaser)
            {

                transform.LookAt(player);
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, enemy3Speed * Time.deltaTime);
            }
            else
            {

                transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
            }


            laserTime += Time.deltaTime;
            if (laserTime > laserRecoveryTime && !isDoingLaser)
            {
                StartCoroutine(ShootingLaser());
            }
        }
        else
        {

            transform.position = Vector3.MoveTowards(transform.position, stayingPoint.transform.position, enemy3Speed * Time.deltaTime);
        }
    }

    public IEnumerator ShootingLaser()
    {

        enemy3Speed = 0f;
        isDoingLaser = true;
        laser.SetActive(true);
        Ray ray = new Ray(enemyNose.position, enemyNose.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, minRange))
        {

            if (hit.collider.CompareTag("Player"))
            {
                healthManager.PlayerHit();
            }
        }
            yield return new WaitForSeconds(2f);


            enemy3Speed = originalEnemy3Speed;
            laser.SetActive(false);
            isDoingLaser = false;
            laserTime = 0;
        }
    }


