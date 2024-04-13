using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float speed = 5;
    [SerializeField] float jumpForce = 10;

    Vector2 movementInput;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");
        movementInput = new Vector2(horizontalAxis, verticalAxis);

        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode.Impulse);
        }
    }

    void FixedUpdate()
    {
        rb.AddForce(new Vector3(movementInput.x, 0, movementInput.y) * speed);
    }
}
