using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    //player variables
    public GameObject moveTarget;
    public Transform target;
    public LayerMask targetLayer;

    public float playerSpeed;
    public float playerRotationSpeed;
    private CharacterController characterController;
    private void OnEnable()
    {
        var playerInput = new Controls();

        playerInput.Player.Enable();

        playerInput.Player.Target.performed += ctx => Target();
    }


    public void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }


    void Update()
    {
        //gameObject.transform.LookAt(moveTargetTransform);
        //transform.position = Vector3.MoveTowards(transform.position, moveTargetTransform.transform.position, playerSpeed * Time.deltaTime);

        if (target != null)
        {
            //look there
            Vector3 direction = (target.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(direction);

            //move there
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * playerRotationSpeed);
            transform.position = Vector3.MoveTowards(transform.position, target.position, playerSpeed * Time.deltaTime);
        }
    }

    public void Target()
    {
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, targetLayer))
        {


            GameObject spawned = Instantiate(moveTarget, hit.point, Quaternion.identity);
            target = spawned.transform.Find("thePoint");
            Debug.Log("Spawned at: " + hit.point);
            Destroy(spawned, 10f);
        }
        else
        {
            Debug.Log("Right-click not on target layer");
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "MoveTarget")
        {
            Destroy(other.gameObject);
        }
    }
}
