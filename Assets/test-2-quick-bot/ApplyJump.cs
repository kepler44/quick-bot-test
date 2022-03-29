using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ApplyJump : MonoBehaviour
{

    public float jumpForce = 5;
    public void Trigger(Rigidbody2D rb){
       var v = rb.velocity ;
       v.y = jumpForce;
       rb.velocity = v;
    }
}