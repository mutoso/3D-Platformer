using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 50;
    [SerializeField] float jumpForce = 10;
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

        float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");
        movementInput = new Vector2(horizontalAxis, verticalAxis);

        if (Input.GetButtonDown("Jump") && onGround)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode.Impulse);
            anim.SetTrigger("jump");
        }

        anim.SetFloat("speed", movementVector.magnitude);
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
}
