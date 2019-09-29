using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public int m_MoveSpeed; //How fast the player moves
    public int m_JumpForce; //How high will it jump
    public int m_MaxJumps;


    private bool canJump; //Check if player is on the ground
    private Rigidbody2D rb;
    private int jumpsLeft;

    // Start is called before the first frame update
    void Start()
    {
        canJump = false;

        rb = GetComponent<Rigidbody2D>();

        jumpsLeft = m_MaxJumps;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        if (canJump && Input.GetKeyDown(KeyCode.Space)) 
        {
            rb.AddForce(Vector2.up * m_JumpForce);

            if(jumpsLeft > 0)
            {
                jumpsLeft--;
            }
            else
            {
                canJump = false;
            }
        }

        transform.position += Vector3.right * Input.GetAxis("Horizontal") * m_MoveSpeed * Time.deltaTime;
    }

    public void setCanJump(bool value)
    {
        canJump  = value;
    }

    public void resetJumps()
    {
        jumpsLeft = m_MaxJumps;
    }
}
