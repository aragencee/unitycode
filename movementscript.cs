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
    bool isGrounded;
    float playerHeight = 2f;
    public float jumpForce = 15f;
    float airdrag = 2f;
    float airMoveMulti = 0.4f;

    Rigidbody rb;
    private void Update()
    {
        myInput();
        controlDrag();
        isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.1f);
        print(isGrounded);

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
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
        if (isGrounded)
        {
            rb.drag = rbdrag;
        }
        else
        {
            rb.drag = airdrag;
        }
    }

    private void FixedUpdate()
    {
        movePlayer(); 
    }

    void movePlayer()
    {

        if (isGrounded)
        {

        rb.AddForce(moveDirection.normalized * moveSpeed * moveMultiplier, ForceMode.Acceleration);

        }

        else
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * moveMultiplier * airMoveMulti, ForceMode.Acceleration);
        }
    }

    void Jump ()
    {
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
}
