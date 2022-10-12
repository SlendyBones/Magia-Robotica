using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleJump : MonoBehaviour
{
    public float jumpForce = 5f;
    public float groundDistance = 0.5f;
    private Rigidbody my_rigidbody;
    void Awake()
    {
        my_rigidbody = GetComponent<Rigidbody>();
    }
    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, groundDistance);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            my_rigidbody.velocity = Vector3.up * jumpForce;
        }
        
    }
}
