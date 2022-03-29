using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotInput : MonoBehaviour
{
    BotDifficults difficult = new BotDifficults();

    public Rigidbody2D rb = null;

    ApplyHorizontalMove app_horMove;

    ApplyJump app_jumpMove;

    ApplyForce app_force;

    GroundDetector groundDetector = null;

    PlayerInput targetPlayer = null;

    public void Start()
    {
        targetPlayer = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody2D>();
        app_horMove = GetComponent<ApplyHorizontalMove>();
        app_jumpMove = GetComponent<ApplyJump>();
        app_force = GetComponent<ApplyForce>();
        groundDetector = GetComponent<GroundDetector>();
    }

    public void Update()
    {
        if (targetPlayer) return;

        var inputs = difficult.ReadInputs(gameObject);

        var x = inputs.x;
        app_horMove.Trigger (rb, x);

        bool jump = inputs.jump;
        if (groundDetector.IsGrounded && jump) app_jumpMove.Trigger(rb);

        bool force = inputs.force;
        if (force) app_force.Trigger(rb, x);
    }
}
