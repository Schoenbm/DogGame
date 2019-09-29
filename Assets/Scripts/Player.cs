using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public int m_MoveSpeed; //How fast the player moves
    public int m_jumpForce; //How high will it jump

    private bool isGrounded; //Check if player is on the ground
    private Rigidbody2D rb;
    

    // Start is called before the first frame update
    void Start()
    {
        isGrounded = false;

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        if (isGrounded)
        {
            rb.AddForce(Vector2.up * m_jumpForce);
            isGrounded = false;
        }

        transform.position = Vector3.right * Input.GetAxis("Horizontal") * m_MoveSpeed * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "platform" && rb.velocity.y == 0)
        {
            isGrounded = true;
        }
    }
}
