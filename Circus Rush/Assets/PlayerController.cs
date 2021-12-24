using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    private float horizontal;
    public float forwardSpeed;
    public float sideSpeed;
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + new Vector3(horizontal * sideSpeed, 0f, forwardSpeed) * Time.fixedDeltaTime);
    }
}
