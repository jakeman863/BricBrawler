using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;

    public float jumpHeight;
    public float jumpRate = 0.5f;
    private float nextJump;
    public int amntJumps;

    private bool grounded;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;

    private Rigidbody2D rb2d;

    private string playerNum;

    public int hitCheck;

    public AudioClip jumpSound;
    public AudioClip hitSound;
    public AudioSource soundSource;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        playerNum = this.name;
        hitCheck = 0;
    }

    void FixedUpdate()
    {
        hitCheck = gameObject.GetComponent<DamageController>().hitCheck;
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        if (grounded)
        {
            amntJumps = 1;
        }

        if((Input.GetAxis(playerNum + "_Movement") > 0 || Input.GetAxis(playerNum + "_Movement") < 0) && hitCheck == 0)
        {
            rb2d.velocity = new Vector2(Input.GetAxis(playerNum + "_Movement") * moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
    }

    void Update()
    {
        checkOutOfBounds();

        if (Input.GetButtonDown(playerNum + "_Jump") && (grounded || amntJumps < 2) && Time.time > nextJump)
        {
            soundSource.clip = jumpSound;
            soundSource.Play();

            rb2d.velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
            amntJumps += 1;
            nextJump = Time.time + jumpRate;
        }
    }

    private void checkOutOfBounds()
    {
        if (this.gameObject.GetComponent<Transform>().position.x >= 3 || this.gameObject.GetComponent<Transform>().position.x <= -3 || this.gameObject.GetComponent<Transform>().position.y <= -2 || this.gameObject.GetComponent<Transform>().position.y >= 2)
        {
            Destroy(this.gameObject);
        }
    }
}
