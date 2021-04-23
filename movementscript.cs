using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementscript : MonoBehaviour
{

    public float moveSpeed;
    Vector3 moveDirection;
    float horizontalMovement;
    float verticalMovement;
    float rbdrag = 6;
    float moveMultiplier = 20f;

    Rigidbody rb;
    private void Update()
    {
        myInput();
        controlDrag();
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }
    void myInput()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");
        moveDirection = transform.forward * verticalMovement + transform.right * horizontalMovement;
    }

    void controlDrag()
    {
        rb.drag = rbdrag;
    }

    private void FixedUpdate()
    {
        movePlayer(); 
    }

    void movePlayer()
    {
        rb.AddForce(moveDirection.normalized * moveSpeed * moveMultiplier, ForceMode.Acceleration);
    }
}
