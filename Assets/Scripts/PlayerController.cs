using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 50;
    [SerializeField] float jumpForce = 5;
    [SerializeField] float groundCheckDistance = 1;
    [SerializeField] Animator anim;

    Rigidbody rb;
    Vector2 movementInput;
    Vector3 movementVector;
    bool onGround = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        onGround = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance);

        anim.SetFloat("speed", movementVector.magnitude);

        // Fix "Look rotation viewing vector is zero" warning
        if (movementVector != Vector3.zero)
        {
            anim.transform.forward = movementVector;
        }
    }

    void FixedUpdate()
    {
        movementVector = new Vector3(movementInput.x, 0, movementInput.y).normalized * speed;
        rb.AddForce(movementVector);
    }

    public void OnJump()
    {
        if (onGround)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode.Impulse);
            anim.SetTrigger("jump");
        }
    }
   
    public void OnMovement(InputValue value)
    {
        movementInput = value.Get<Vector2>();
    }
}
