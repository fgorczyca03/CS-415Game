using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;

    public Transform orientation;

    float hInput;
    float vInput;

    Vector3 moveDir;

    Rigidbody rb;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        MyInput();
    }

    public void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        hInput = Input.GetAxisRaw("Horizontal");
        vInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        // Calculate Movement Direction
        moveDir = orientation.forward * vInput + orientation.right * hInput;
        moveDir.y = 0f; // Ensure movement is only horizontal
        moveDir.Normalize();

        // Set the velocity directly
        rb.velocity = moveDir * moveSpeed;
    }
}