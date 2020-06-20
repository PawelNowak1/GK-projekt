using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour, IDamageable
{
    public GameManager gameManager;

    private Rigidbody2D rigidBody;
    private float jumpForce = 8.0f;
    private bool grounded = false;
    private bool resetJump = false;
    private float speed = 3.5f;
    private PlayerAnim playerAnim;
    private SpriteRenderer playerSprite;
    private int HealthScore = 4;

    public int Health {
        get { return HealthScore; }
        set { HealthScore = value; }
    }
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<PlayerAnim>();
        playerSprite = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (gameManager.PlayerCanMove())
        //{
            move();
            checkGround();

            if (CrossPlatformInputManager.GetButtonDown("A_Button") && grounded == true)
            {
                playerAnim.Attack();
            }
        //}
    }

    void checkGround()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 1.25f, 1 << 8);
        Debug.DrawRay(transform.position, 1.25f * Vector2.down, Color.green);

        if (hitInfo.collider != null)
        {
            if (resetJump == false)
            {
                playerAnim.Jump(false);
                grounded = true;
            }
        }
    }

    void move()
    {
            float horizontalInput = CrossPlatformInputManager.GetAxis("Horizontal");

            if (horizontalInput > 0)
            {
                playerSprite.flipX = false;

            }
            else if (horizontalInput < 0)
            {
                playerSprite.flipX = true;
            }

            if ((Input.GetKeyDown(KeyCode.Space) || CrossPlatformInputManager.GetButtonDown("B_Button")) && grounded == true)
            {
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce);
                grounded = false;
                resetJump = true;
                StartCoroutine(ResetJumpRoutine());
                playerAnim.Jump(true);
            }

            rigidBody.velocity = new Vector2(horizontalInput * speed, rigidBody.velocity.y);
            playerAnim.Move(horizontalInput);

    }
    IEnumerator ResetJumpRoutine()
    {
        yield return new WaitForSeconds(0.2f);
        resetJump = false;
    }

    public void Damage()
    {
        Debug.Log("HealthScore: " + HealthScore);
        if (HealthScore > 0)
        {
            HealthScore -= 1;
            gameManager.SetHealtLabels(HealthScore);

            if(HealthScore == 0)
            {
                gameManager.GameOver();
            }
        }
    }
}
