using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyForce : MonoBehaviour
{
    public Transform forceBar = null;

    public float moveForce = 5;

    public float forceAmount = 1;

    public void Trigger(Rigidbody2D rb, float x)
    {
        forceAmount -= Time.deltaTime;
        if (forceAmount < 0)
        {
            forceAmount = 0;
            return;
        }
        var v = rb.velocity;
        v.x = moveForce * x;
        rb.velocity = v;
    }

    public void Update()
    {
        forceAmount += Time.deltaTime;
        if (forceAmount > 1) forceAmount = 1;
        var sc = forceBar.transform.localScale;
        sc.x = forceAmount;
        forceBar.transform.localScale = sc;
    }
}
