using UnityEditor;
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

    //pause stuff
    public bool isPaused = false;
    public GameObject pauseScreen;
    private void OnEnable()
    {
        var playerInput = new Controls();

        playerInput.Player.Enable();

        playerInput.Player.Target.performed += ctx => Target();

        playerInput.Player.Pause.performed += ctx => Pause();

        playerInput.Player.QAction.performed += ctx => QAction();

        playerInput.Player.WAction.performed += ctx => WAction();

        playerInput.Player.EAction.performed += ctx => EAction();

        playerInput.Player.RAction.performed += ctx => RAction();
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
        if(isPaused == false)
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
    }

    public void Pause()
    {
        if(isPaused == false)
        {
            isPaused = true;
            pauseScreen.SetActive(true);
            Time.timeScale = 0f;
            Debug.Log("should pause");
        }

        else if(isPaused == true)
        {
            isPaused = false;
            pauseScreen.SetActive(false);
            Time.timeScale = 1f;
            Debug.Log("should unpause");
        }
    }

    public void QAction()
    {

    }

    public void WAction()
    {

    }

    public void EAction()
    {

    }

    public void RAction()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "MoveTarget")
        {
            Destroy(other.gameObject);
        }
    }
}
