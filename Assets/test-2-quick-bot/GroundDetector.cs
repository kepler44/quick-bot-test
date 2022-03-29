using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    public Vector2 boxArea = Vector2.zero;

    void Start()
    {
    }

    public bool IsGrounded
    {
        get
        {
            return Physics2D.OverlapBox(transform.position, boxArea, 0, 1 >> 6);
        }
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, boxArea);
    }
}
