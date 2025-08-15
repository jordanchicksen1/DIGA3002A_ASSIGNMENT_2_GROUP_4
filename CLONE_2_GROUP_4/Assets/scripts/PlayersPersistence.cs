using System.Collections;
using UnityEditor;
using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayersPersistence : MonoBehaviour
{
    //UI stuff for level selects
    public GameObject levelSelection;
    public GameObject instruction;
    public bool levelDone = false;
    private InputAction confirmEnd;
    
    //Persistent variable testing
    public int currentLayer = 0;
    
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

    //health stuff
    public healthManager healthManager;
    public bool hasBeenHit = false;
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

        confirmEnd = InputSystem.actions.FindAction("ConfirmEnd");
        DontDestroyOnLoad(this.gameObject); //DontDestroyOnLoad for persistence
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
        
        //Confirming
        if (confirmEnd.WasPressedThisFrame())
        {
            if (!levelDone)
            {
                instruction.SetActive(false);
                levelDone = true;
                levelSelection.SetActive(true);
            } else if (levelDone)
            {
                instruction.SetActive(true);
                levelDone = false;
                levelSelection.SetActive(false);
            }
            
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
                //Debug.Log("Spawned at: " + hit.point);
                Destroy(spawned, 10f);
            }
            else
            {
                //Debug.Log("Right-click not on target layer");
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
            //Debug.Log("should pause");
        }

        else if(isPaused == true)
        {
            isPaused = false;
            pauseScreen.SetActive(false);
            Time.timeScale = 1f;
            //Debug.Log("should unpause");
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

        if(other.tag == "EnemyProjectile" && hasBeenHit == false)
        {
            hasBeenHit = true;
            healthManager.PlayerHit();
            Destroy(other.gameObject);
            Debug.Log("player got hit");
            StartCoroutine(ProjectileIssue());

        }

        if (other.tag == "LaserLine" && hasBeenHit == false)
        {
            healthManager.PlayerHit();
            hasBeenHit = true;
            StartCoroutine(ProjectileIssue());
        }

    }
    
    private void OnTriggerStay(Collider other)
    {
        Debug.Log($"OnTriggerStay: {other.name}");

        if (other.CompareTag("EnemyDetectionTrigger"))
        {
            enemy1 enemy1 = other.GetComponentInParent<enemy1>();

            if (enemy1 != null)
            {
                enemy1.isInEnemyRange = true;
                Debug.Log("is in the trigger");
            }
        }

        if (other.CompareTag("Enemy2DetectionTrigger"))
        {
            enemy2 enemy2 = other.GetComponentInParent<enemy2>();

            if (enemy2 != null)
            {
                enemy2.isInEnemy2Range = true;
                Debug.Log("is in the trigger2");
            }
        }

        if (other.CompareTag("Enemy3DetectionTrigger"))
        {
            enemy3 enemy3 = other.GetComponentInParent<enemy3>();

            if (enemy3 != null)
            {
                enemy3.isInEnemy3Range = true;
                Debug.Log("is in the trigger3");
            }

        }

        if (other.CompareTag( "Enemy4DetectionTrigger"))
        {
            enemy4 enemy4 = other.GetComponentInParent<enemy4>();

            if (enemy4 != null)
            {
                enemy4.isInEnemy4Range = true;
                Debug.Log("is in the trigger4");
            }

        }

        if (other.CompareTag("Enemy5DetectionTrigger"))
        {
            enemy5 enemy5 = other.GetComponentInParent<enemy5>();

            if (enemy5 != null)
            {
                enemy5.isInEnemy5Range = true;
                Debug.Log("is in the trigger4");
            }

        }

        if(other.tag == "DamageZone")
        {
            healthManager.DamageZoneHit();
        }

        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("EnemyDetectionTrigger"))
        {
            enemy1 enemy1 = other.GetComponentInParent<enemy1>();

            if (enemy1 != null)
            {
                enemy1.isInEnemyRange = false;
                Debug.Log("is in the trigger");
            }
        }

        if (other.CompareTag("Enemy2DetectionTrigger"))
        {
            enemy2 enemy2 = other.GetComponentInParent<enemy2>();

            if (enemy2 != null)
            {
                enemy2.isInEnemy2Range = false;
                Debug.Log("is in the trigger2");
            }
        }

        if (other.CompareTag("Enemy3DetectionTrigger"))
        {
            enemy3 enemy3 = other.GetComponentInParent<enemy3>();

            if (enemy3 != null)
            {
                enemy3.isInEnemy3Range = false;
                Debug.Log("is in the trigger3");
            }

        }

        if (other.CompareTag("Enemy4DetectionTrigger"))
        {
            enemy4 enemy4 = other.GetComponentInParent<enemy4>();

            if (enemy4 != null)
            {
                enemy4.isInEnemy4Range = false;
                Debug.Log("is in the trigger4");
            }

        }

        if (other.CompareTag("Enemy5DetectionTrigger"))
        {
            enemy5 enemy5 = other.GetComponentInParent<enemy5>();

            if (enemy5 != null)
            {
                enemy5.isInEnemy5Range = false;
                Debug.Log("is in the trigger4");
            }

        }
    }

    public IEnumerator GiveBackQBar()
    {
        yield return new WaitForSeconds(0f);
        qActionUI.shouldFillQBar = true;
        yield return new WaitForSeconds(artCooldownTime);
        canUseQAction = true;
        qActionUI.shouldFillQBar = false;
    }

    public IEnumerator GiveBackWBar()
    {
        yield return new WaitForSeconds(0f);
        wActionUI.shouldFillWBar = true;
        yield return new WaitForSeconds(artCooldownTime);
        canUseWAction = true;
        wActionUI.shouldFillWBar = false;
    }

    public IEnumerator GiveBackEBar()
    {
        yield return new WaitForSeconds(0f);
        eActionUI.shouldFillEBar = true;
        yield return new WaitForSeconds(artCooldownTime);
        canUseEAction = true;
        eActionUI.shouldFillEBar = false;
    }

    public IEnumerator GiveBackRBar()
    {
        yield return new WaitForSeconds(0f);
        rActionUI.shouldFillRBar = true;
        yield return new WaitForSeconds(artCooldownTime);
        canUseRAction = true;
        rActionUI.shouldFillRBar = false;
    }

    public IEnumerator ProjectileIssue()
    {
        yield return new WaitForSeconds(0.01f);
        hasBeenHit = false;
    }
}

