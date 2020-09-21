using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 10;
    [SerializeField]
    float jumpSpeed = 10;

    bool isGrounded = true;

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        rb.velocity = new Vector3(h * moveSpeed, rb.velocity.y, v * moveSpeed);
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
        Ray r = new Ray(transform.position, transform.up * -1);
        Debug.DrawRay(r.origin, (transform.up * -1)*1, Color.red, 10.0f);
        RaycastHit hit;
        if (Physics.Raycast(r, out hit))
        {
            if (hit.distance <= 1)
            {
                isGrounded = true;
            }
            else
            {
                isGrounded = false;
            }
        }
    }
    void Jump()
    {
        if (isGrounded == true)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpSpeed, rb.velocity.z);
            isGrounded = false;
        }
        else
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, rb.velocity.z);
        }
    }
}
