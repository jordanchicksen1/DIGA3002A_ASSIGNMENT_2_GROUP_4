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

    public bool isDoingLaser=false;


    public void Update()
    {
        if (isInEnemy3Range == true)
        {
            this.gameObject.transform.LookAt(player);
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, enemy3Speed * Time.deltaTime);

            laserTime += Time.deltaTime;

            if (laserTime > laserRecoveryTime)
            {
                
                StartCoroutine(ShootingLaser());
            }

            if (isDoingLaser == true) 
            { 
                transform.Rotate(0f, rotationSpeed, 0f);
            }
           
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, stayingPoint.transform.position, enemy3Speed * Time.deltaTime);
        }
    } 

    public IEnumerator ShootingLaser()
    {
        yield return new WaitForSeconds(0);
        enemy3Speed = 0f;
        laser.SetActive(true);
        isDoingLaser = true;    
        yield return new WaitForSeconds(2f);
        enemy3Speed = originalEnemy3Speed;
        laser.SetActive(false);
        isDoingLaser = false;
        laserTime = 0;
    }
}
