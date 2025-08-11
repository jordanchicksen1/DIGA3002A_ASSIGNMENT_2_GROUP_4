using System.Collections;
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

    //player actions stuff
    public float artCooldownTime = 3f;
    //actions ui
    public qActionUI qActionUI;
    public bool canUseQAction = true;
    public ParticleSystem qActionRepresentation;
    public wActionUI wActionUI;
    public bool canUseWAction = true;
    public ParticleSystem wActionRepresentation;
    public eActionUI eActionUI;
    public bool canUseEAction = true;
    public ParticleSystem eActionRepresentation;
    public rActionUI rActionUI;
    public bool canUseRAction = true;
    public ParticleSystem rActionRepresentation;
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
        if(isPaused == false && canUseQAction == true)
        {
            qActionUI.UseQBar();
            qActionRepresentation.Play();
            canUseQAction = false;
            StartCoroutine(GiveBackQBar());
        }
    }

    public void WAction()
    {
        if (isPaused == false && canUseWAction == true)
        {
            wActionUI.UseWBar();
            wActionRepresentation.Play();
            canUseWAction = false;
            StartCoroutine(GiveBackWBar());
        }
    }

    public void EAction()
    {
        if (isPaused == false && canUseEAction == true)
        {
            eActionUI.UseEBar();
            eActionRepresentation.Play();
            canUseEAction = false;
            StartCoroutine(GiveBackEBar());
        }
    }

    public void RAction()
    {
        if (isPaused == false && canUseRAction == true)
        {
            rActionUI.UseRBar();
            rActionRepresentation.Play();
            canUseRAction = false;
            StartCoroutine(GiveBackRBar());
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "MoveTarget")
        {
            Destroy(other.gameObject);
        }
    }

    public IEnumerator GiveBackQBar()
    {
        yield return new WaitForSeconds(0.5f);
        qActionUI.shouldFillQBar = true;
        yield return new WaitForSeconds(artCooldownTime);
        canUseQAction = true;
        qActionUI.shouldFillQBar = false;
    }

    public IEnumerator GiveBackWBar()
    {
        yield return new WaitForSeconds(0.5f);
        wActionUI.shouldFillWBar = true;
        yield return new WaitForSeconds(artCooldownTime);
        canUseWAction = true;
        wActionUI.shouldFillWBar = false;
    }

    public IEnumerator GiveBackEBar()
    {
        yield return new WaitForSeconds(0.5f);
        eActionUI.shouldFillEBar = true;
        yield return new WaitForSeconds(artCooldownTime);
        canUseEAction = true;
        eActionUI.shouldFillEBar = false;
    }

    public IEnumerator GiveBackRBar()
    {
        yield return new WaitForSeconds(0.5f);
        rActionUI.shouldFillRBar = true;
        yield return new WaitForSeconds(artCooldownTime);
        canUseRAction = true;
        rActionUI.shouldFillRBar = false;
    }
}

