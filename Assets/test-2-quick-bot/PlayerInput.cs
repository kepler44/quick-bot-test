using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Rigidbody2D rb = null;

    ApplyHorizontalMove app_horMove;

    ApplyJump app_jumpMove;

    ApplyForce app_force;

    GroundDetector groundDetector = null;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        app_horMove = GetComponent<ApplyHorizontalMove>();
        app_jumpMove = GetComponent<ApplyJump>();
        app_force = GetComponent<ApplyForce>();
        groundDetector = GetComponent<GroundDetector>();
    }

    public void Update()
    {
        var x = 0;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) x -= 1;
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) x += 1;
        app_horMove.Trigger (rb, x);

        bool jump =
            (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Mouse0));
        if (groundDetector.IsGrounded && jump) app_jumpMove.Trigger(rb);

        bool force =
            (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.Mouse1));
        if (force) app_force.Trigger(rb, x);
    }
}
