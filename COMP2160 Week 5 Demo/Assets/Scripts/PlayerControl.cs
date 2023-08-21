using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    [SerializeField]
    private float speed = 5;

    [SerializeField]
    private float turnSpeed = 5;

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

        if (shootAction.WasPressedThisFrame()) 
        {

        }
    }
}
