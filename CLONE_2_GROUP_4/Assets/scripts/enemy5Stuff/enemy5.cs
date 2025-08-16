using UnityEngine;

public class enemy5 : MonoBehaviour
{
    public bool isInEnemy5Range = false;

    //looking and moving towards player
    public float enemySpeed = 8f;
    private Transform playerTransform;
    public Transform stayingPoint;
    
    public void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
        Debug.Log("found player");
    }
    void Update()
    {
        if (isInEnemy5Range == true)
        {
            this.gameObject.transform.LookAt(playerTransform);
            transform.position = Vector3.MoveTowards(transform.position, playerTransform.transform.position, enemySpeed * Time.deltaTime);

           
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, stayingPoint.transform.position, enemySpeed * Time.deltaTime);
        }

    }
}
