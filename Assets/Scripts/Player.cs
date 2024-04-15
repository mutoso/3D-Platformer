using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 100;
    [SerializeField] float jumpForce = 10;
    [SerializeField] float groundCheckDistance = 1;
    [SerializeField] Animator anim;
    [SerializeField] PlayerStats playerStats;

    Rigidbody rb;
    Transform cam;
    Vector2 movementInput;
    Vector3 movementVector;
    bool onGround = false;
    bool sprintEnabled = false;

    public int Health
    {
        get
        {
            return playerStats.health;
        }
        
        set
        { 
            playerStats.health = value;
        }
    }

    public int Score
    {
        get
        {
            return playerStats.score;
        }

        set
        {
            playerStats.score = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main.transform;
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
        movementVector = ((movementInput.y * cam.forward) + (movementInput.x * cam.right)).normalized * speed;
        movementVector.y = 0;
        rb.AddForce(movementVector);
    }

    void OnJump()
    {
        if (onGround)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode.Impulse);
            anim.SetTrigger("jump");
        }
    }
   
    void OnMovement(InputValue value)
    {
        movementInput = value.Get<Vector2>();
    }

    void OnSprint()
    {
        speed = sprintEnabled ? 100 : 400;
        sprintEnabled = !sprintEnabled;
    }
}
