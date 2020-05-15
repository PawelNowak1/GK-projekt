using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    [SerializeField]
    private float jumpForce = 5.0f;
    [SerializeField]
    private bool grounded = false;
    private bool resetJump = false;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        move();
        checkGround();
    }

    void checkGround()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 1f, 1 << 8);
        Debug.DrawRay(transform.position, 1f * Vector2.down, Color.green);

        if (hitInfo.collider != null)
        {
            if (resetJump == false)
                grounded = true;
        }
    }

    void move()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space) && grounded == true)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce);
            grounded = false;
            resetJump = true;
            StartCoroutine(ResetJumpRoutine());
        }
        rigidBody.velocity = new Vector2(horizontalInput, rigidBody.velocity.y);

    }
    IEnumerator ResetJumpRoutine()
    {
        yield return new WaitForSeconds(0.2f);
        resetJump = false;
    }
}
