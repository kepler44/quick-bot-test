using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyHorizontalMove : MonoBehaviour
{
    public float speed = 2;

    public void Trigger(Rigidbody2D rb, float x)
    {
        var v = rb.velocity;
        v.x = x * speed;
        rb.velocity = v;
    }
}
