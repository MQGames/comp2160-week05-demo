using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FireLaser : MonoBehaviour
{
    [SerializeField] private float maxDistance = 5;
    [SerializeField] private float speed = 50;
    [SerializeField] private LayerMask enemyLayerMask;
    [SerializeField] private ParticleSystem explosionPrefab;
    [SerializeField] private Scorekeeper scorekeeper;

    private bool firing = false;
    private bool ending = false;
    private float distance = 0;
    private float hitDistance = 0;
    private GameObject target;

    private Actions actions;
    private InputAction shootAction;

    void Awake()
    {
        actions = new Actions();
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
        // The end of the laser beam catches up with the start

        if (ending)
        {
            distance += speed * Time.deltaTime;
            if (distance >= hitDistance) 
            {
                distance = hitDistance;
                ending = false;
            }

            Vector3 start = transform.TransformPoint(distance * Vector3.up);
            Vector3 end = transform.TransformPoint(hitDistance * Vector3.up);
            var lineRenderer = GetComponent<LineRenderer>();
            lineRenderer.SetPosition(0, start);
            lineRenderer.SetPosition(1, end);
        }

        // The start of the laser beam is moving towards the target

        if (firing)
        {
            distance += speed * Time.deltaTime;
            if (distance >= hitDistance)
            {
                // hit the target
                distance = 0;
                firing = false;
                ending = true;
                
                // if we hit an enemy, make it explode
                if (target != null)
                {
                    var particles = Instantiate(explosionPrefab);
                    particles.transform.position = target.transform.position;
                    Destroy(target);

                    scorekeeper.KilledEnemy();
                }
            }

            Vector3 start = transform.TransformPoint(0 * Vector3.up);
            Vector3 end = transform.TransformPoint(distance * Vector3.up);
            var lineRenderer = GetComponent<LineRenderer>();
            lineRenderer.SetPosition(0, start);
            lineRenderer.SetPosition(1, end);
        }
        
        // if the player presses shoot, start the laser
        if (shootAction.WasPressedThisFrame() && !firing && !ending) 
        {
            firing = true;
            distance = 0;

            Vector2 origin = transform.position;
            Vector2 direction = transform.up;

            var hit = Physics2D.Raycast(origin, direction, maxDistance, enemyLayerMask); 
            if (hit.collider == null)
            {                
                hitDistance = maxDistance;
                target = null;
            }
            else
            {
                hitDistance = hit.distance;
                target = hit.collider.gameObject;
            }
        }

    }
}
