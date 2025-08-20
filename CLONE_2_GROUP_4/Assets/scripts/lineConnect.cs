using UnityEngine;

public class lineConnect : MonoBehaviour
{
    public GameObject player;
    public GameObject portal;
    private LineRenderer lineRenderer;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        portal = GameObject.FindGameObjectWithTag("Portal");
        lineRenderer = gameObject.GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
    }

    void Update()
    {
        lineRenderer.SetPosition(0, portal.transform.position);
        lineRenderer.SetPosition(1, player.transform.position);
    }
}
