using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(LineRenderer))]
public class FireLaser : MonoBehaviour
{
    [SerializeField] private float maxDistance = 5;
    [SerializeField] private float speed = 50;
    [SerializeField] private LayerMask enemyLayerMask;
    [SerializeField] private ParticleSystem explosionPrefab;
    [SerializeField] private Scorekeeper scorekeeper;

    private enum State { 
        Waiting, Growing, Shrinking
    }
    private State state = State.Waiting;
    private float distance = 0;
    private float hitDistance = 0;
    private GameObject target;

    private Actions actions;
    private InputAction shootAction;
    private LineRenderer lineRenderer;

    void Awake()
    {
        actions = new Actions();
        shootAction = actions.playerMovement.shoot;

        lineRenderer = GetComponent<LineRenderer>();
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
        // Refactored update to make the FSM explicit

        switch (state) 
        {
            case State.Waiting:
                DoWait();
                break;

            case State.Growing:
                DoGrow();
                break;

            case State.Shrinking:
                DoShrink();
                break;
        }
    }

    private void DoWait()
    {
        if (shootAction.WasPressedThisFrame()) 
        {
            state = State.Growing;
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

    private void DoGrow()
    {
        // The start of the laser beam is moving towards the target

        distance += speed * Time.deltaTime;
        if (distance >= hitDistance)
        {
            // hit the target
            distance = 0;
            state = State.Shrinking;
            
            // if we hit an enemy, make it explode
            if (target != null)
            {
                var particles = Instantiate(explosionPrefab);
                particles.transform.position = target.transform.position;
                Destroy(target);

                scorekeeper.KilledEnemy();
            }
        }

        DrawLaser(0, distance);
    }

    private void DoShrink()
    {
        distance += speed * Time.deltaTime;
        if (distance >= hitDistance) 
        {
            distance = hitDistance;
            state = State.Waiting;
        }

        DrawLaser(distance, hitDistance);
    }

    private void DrawLaser(float startDistance, float endDistance) 
    {
        // calculate start and end points in the local coordinate space of the ship
        // then tranform them into world coordinates for the line renderer
        Vector3 start = transform.TransformPoint(startDistance * Vector3.up);
        Vector3 end = transform.TransformPoint(endDistance * Vector3.up);
        lineRenderer.SetPosition(0, start);
        lineRenderer.SetPosition(1, end);
    }

}
