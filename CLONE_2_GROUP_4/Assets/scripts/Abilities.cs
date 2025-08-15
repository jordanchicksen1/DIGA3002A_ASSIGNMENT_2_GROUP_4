using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;


public class Abilities : MonoBehaviour
{
    [Header("Q Ability Settings")]
    [SerializeField] private GameObject orbPrefab;
    [SerializeField] private float orbSpeed = 10f;
    [SerializeField] private float maxRange = 7f;
    [SerializeField] private float damage = 30f;
    [SerializeField] private LayerMask damageLayers;

    [Header("W Ability Settings")]
    [SerializeField] private GameObject foxFirePrefab;
    [SerializeField] private float speedBoost = 1.5f;
    [SerializeField] private float speedBoostDuration = 1.5f;
    [SerializeField] private int foxFireCount = 3;
    [SerializeField] private float foxFireDamage = 20f;
    [SerializeField] private float foxFireDetectionRange = 5f;
    [SerializeField] private float foxFireSpeed = 8f;
    [SerializeField] private float foxFireDuration = 4f; 
    private float originalSpeed;

    [Header("E Ability - Charm")]
    [SerializeField] private GameObject charmPrefab;
    [SerializeField] private float charmSpeed = 12f;
    [SerializeField] private float charmMaxRange = 8f;
    [SerializeField] private float charmDamage = 15f;
    [SerializeField] private float charmDuration = 1.5f;
    [SerializeField] private float charmSlow = 0.5f;

    [Header("R Ability - Spirit Rush")]
    public float rCooldown = 30f;
    public bool rAbilityActive = false;
    [SerializeField] private float dashDistance = 5f;
    [SerializeField] private float dashDuration = 0.3f;
    [SerializeField] private int maxDashes = 3;
    [SerializeField] private float timeBetweenDashes = 1f;
    [SerializeField] private GameObject dashEffectPrefab;
    private int remainingDashes;
    private bool isDashing = false;
    private Vector3 dashTarget;
    private float dashStartTime;
    private Vector3 dashStartPosition;
    private float rLastCastTime = -999f;
    private CharacterController characterController;


    private PlayersPersistence player;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        player = GetComponent<PlayersPersistence>();
        if (player != null)
        {
            originalSpeed = player.playerSpeed;
        }
    }

    private void Start()
    {
        player = GetComponent<PlayersPersistence>();
    }

    void Update()
    {
       
    }

    public void CastQAbility()
    {
        Vector3 direction = (player.abilityTarget.position - player.transform.position).normalized;

        GameObject orb = Instantiate(orbPrefab, transform.position, Quaternion.identity);
        OrbProjectile orbScript = orb.GetComponent<OrbProjectile>();

        orbScript.Initialize(transform, direction, orbSpeed, maxRange, damage, damageLayers);
    }

    public void CastEAbility()
    {
        Vector3 direction = (player.abilityTarget.position - transform.position).normalized;

        GameObject charm = Instantiate(charmPrefab, transform.position, Quaternion.identity);
        CharmProjectile charmScript = charm.GetComponent<CharmProjectile>();

        charmScript.Initialize(transform, direction, charmSpeed, charmMaxRange, charmDamage, charmDuration, charmSlow, damageLayers);
    }

    public void CastWAbility()
    {
        if (player != null)
        {
            player.playerSpeed = originalSpeed * speedBoost;
            Invoke(nameof(ResetSpeed), speedBoostDuration);
        }

        float angleStep = 360f / foxFireCount;
        for (int i = 0; i < foxFireCount; i++)
        {
            float angle = i * angleStep;
            SpawnFoxFire(angle);
        }

    }

    private void SpawnFoxFire(float startAngle)
    {
        GameObject foxFire = Instantiate(foxFirePrefab, transform.position, Quaternion.identity);
        FoxFireProjectile foxFireScript = foxFire.GetComponent<FoxFireProjectile>();

        foxFireScript.Initialize(
            transform,
            foxFireDamage,
            foxFireDetectionRange,
            foxFireSpeed,
            foxFireDuration,
            damageLayers,
            startAngle
        );
    }

    private void ResetSpeed()
    {
        if (player != null)
        {
            player.playerSpeed = originalSpeed;
        }
    }

    public bool CanDash
    {
        get { return remainingDashes > 0 || !rAbilityActive; }
    }

    public void CastRAbility(bool initialCast = true)
    {
        if (isDashing) return;

        // Only check full cooldown on first dash
        if (initialCast && Time.time - rLastCastTime < rCooldown) return;

        Vector3 direction = (player.abilityTarget.position - transform.position).normalized;

        dashTarget = transform.position + direction * dashDistance;

        // Initialize dash sequence if first dash
        if (initialCast)
        {
            remainingDashes = maxDashes;
            rLastCastTime = Time.time;
            rAbilityActive = true;
        }

        StartCoroutine(PerformDash());
    }


    private IEnumerator PerformDash()
    {
        isDashing = true;
        dashStartTime = Time.time;
        dashStartPosition = transform.position;

        // Spawn fox-fire for this dash
        SpawnFoxFire(Random.Range(0f, 360f));

        // Spawn dash effect
        if (dashEffectPrefab != null)
        {
            Instantiate(dashEffectPrefab, transform.position, Quaternion.identity);
        }

        // Perform dash movement
        while (Time.time - dashStartTime < dashDuration)
        {
            player.ClearMovementTarget();
            float progress = (Time.time - dashStartTime) / dashDuration;
            Vector3 newPosition = Vector3.Lerp(dashStartPosition, dashTarget, progress);
            characterController.Move(newPosition - transform.position);
            yield return null;
        }

        // Snap to final position
        characterController.Move(dashTarget - transform.position);

        isDashing = false;
        remainingDashes--;

        // End ability if no more dashes
        if (remainingDashes <= 0)
        {
            rAbilityActive = false;
        }
    }
}

