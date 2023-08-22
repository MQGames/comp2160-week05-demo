using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    [SerializeField] private float turnSpeed = 5;
    [SerializeField] private ParticleSystem explosionPrefab;

    private Actions actions;
    private InputAction forwardAction;
    private InputAction turnAction;

    void Awake()
    {
        actions = new Actions();
        forwardAction = actions.playerMovement.forward;
        turnAction = actions.playerMovement.turn;
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

        // Wrap the ship position to the screen

        var pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = (pos.x + 1) % 1;
        pos.y = (pos.y + 1) % 1;
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }

    void OnTriggerEnter2D(Collider2D collider) 
    {
        // player can only collide with enemies (due to physics manager settings)
        var particles = Instantiate(explosionPrefab);
        particles.transform.position = transform.position;
        Destroy(gameObject);
    }
}
