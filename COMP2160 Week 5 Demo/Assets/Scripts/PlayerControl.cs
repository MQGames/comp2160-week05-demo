using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerControl : MonoBehaviour
{
    [SerializeField]
    private float speed = 5;
    [SerializeField]
    private float turnSpeed = 5;
    [SerializeField]
    private float laserMaxDistance = 5;
    [SerializeField]
    private float laserSpeed = 50;
    [SerializeField]
    private LayerMask enemyLayerMask;
    [SerializeField]
    private ParticleSystem explosionPrefab;
    [SerializeField]
    private int scorePerKill = 10;
    [SerializeField]
    private string scoreFormat = "Score: {0}";
    [SerializeField]
    private TMP_Text scoreText;

    private bool laserFiring = false;
    private bool laserEnding = false;
    private float laserDistance = 0;
    private float laserHitDistance = 0;
    private GameObject laserTarget;
    private int score = 0;

    private Actions actions;
    private InputAction forwardAction;
    private InputAction turnAction;
    private InputAction shootAction;

    void Awake()
    {
        actions = new Actions();
        forwardAction = actions.playerMovement.forward;
        turnAction = actions.playerMovement.turn;
        shootAction = actions.playerMovement.shoot;
    }

    void OnEnable()
    {
        actions?.playerMovement.Enable();
    }

    void OnDisable() 
    {
        actions?.playerMovement.Disable();
    }

    void Update()
    {
        var fwd = forwardAction.ReadValue<float>();
        transform.Translate(fwd * speed * Vector3.up * Time.deltaTime, Space.Self);

        var turn = turnAction.ReadValue<float>();
        transform.Rotate(0, 0, turnSpeed * turn * Time.deltaTime, Space.Self);

        var pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = (pos.x + 1) % 1;
        pos.y = (pos.y + 1) % 1;
        transform.position = Camera.main.ViewportToWorldPoint(pos);

        if (laserEnding)
        {
            laserDistance += laserSpeed * Time.deltaTime;
            if (laserDistance >= laserHitDistance) 
            {
                laserDistance = laserHitDistance;
                laserEnding = false;
            }

            Vector3 start = transform.TransformPoint(laserDistance * Vector3.up);
            Vector3 end = transform.TransformPoint(laserHitDistance * Vector3.up);
            var lineRenderer = GetComponent<LineRenderer>();
            lineRenderer.SetPosition(0, start);
            lineRenderer.SetPosition(1, end);
        }

        if (laserFiring)
        {
            laserDistance += laserSpeed * Time.deltaTime;
            if (laserDistance >= laserHitDistance)
            {
                laserDistance = 0;
                laserFiring = false;
                laserEnding = true;
                
                if (laserTarget != null)
                {
                    var particles = Instantiate(explosionPrefab);
                    particles.transform.position = laserTarget.transform.position;
                    Destroy(laserTarget);
                    score += scorePerKill;
                    scoreText.text = string.Format(scoreFormat, score);
                }
            }

            Vector3 start = transform.TransformPoint(0 * Vector3.up);
            Vector3 end = transform.TransformPoint(laserDistance * Vector3.up);
            var lineRenderer = GetComponent<LineRenderer>();
            lineRenderer.SetPosition(0, start);
            lineRenderer.SetPosition(1, end);
        }
        
        if (shootAction.WasPressedThisFrame() && !laserFiring && !laserEnding) 
        {
            laserFiring = true;
            laserDistance = 0;

            Vector2 origin = transform.position;
            Vector2 direction = transform.up;

            var hit = Physics2D.Raycast(origin, direction, laserMaxDistance, enemyLayerMask); 
            if (hit.collider == null)
            {                
                laserHitDistance = laserMaxDistance;
                laserTarget = null;
            }
            else
            {
                laserHitDistance = hit.distance;
                laserTarget = hit.collider.gameObject;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider) 
    {
        if (collider.gameObject.CompareTag("Enemy"))
        {
            var particles = Instantiate(explosionPrefab);
            particles.transform.position = transform.position;
            Destroy(gameObject);
        }
    }
}
