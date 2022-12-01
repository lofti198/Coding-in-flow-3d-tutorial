using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    public float movementSpeed = 6f;
    [SerializeField] float jumpForce = 5f;

    [SerializeField] Transform groundCheck;

    [SerializeField] LayerMask ground;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // TODO here check Y and if less than current platform if()

        rb.velocity = new Vector3(horizontalInput*movementSpeed,rb.velocity.y,verticalInput*movementSpeed);
        if(Input.GetButtonDown("Jump") && IsGrounded())
        {
            Jump(); //rb.velocity = new Vector3(rb.velocity.x,jumpForce,rb.velocity.z);
        }
       
        // if(Input.GetKeyDown("up"))
        // {
        //     rb.velocity = new Vector3(0,0,5);
        // }
        // if(Input.GetKeyDown("right"))
        // {
        //     rb.velocity = new Vector3(5,0,0);
        // }
        // if(Input.GetKeyDown("down"))
        // {
        //     rb.velocity = new Vector3(0,0,-5);
        // }
        // if(Input.GetKeyDown("left"))
        // {
        //     rb.velocity = new Vector3(-5,0,0);
        // }
    }
    void Jump(){
        rb.velocity = new Vector3(rb.velocity.x,jumpForce,rb.velocity.z);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy Head"))
        {
            Destroy(collision.transform.parent.gameObject);
            Jump();
        }
    }
    bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position,.1f,ground);
    
    }
}
