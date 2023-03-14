using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Playermovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private float horizontal;
    public float playerSpeed = 2;
    public float jumpForce = 2;
    public bool isgrounded;
    public float fallforce=-1.5f;
    public LayerMask groundLayerMask;
    public float raycastLength = 2;
    private Animator anim;
    private int score;
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    Text score_text;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(x:horizontal * playerSpeed, rb.velocity.y);
        horizontal = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, y: jumpForce);
        }
        if(rb.velocity.x != 0)
        {
            anim.SetBool("ismovement", true);
        }
        else 
        {
            anim.SetBool("ismovement", false);
        }
        if (horizontal < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (horizontal > 0)
        {
            spriteRenderer.flipX = false;
        }
        isgrounded = (bool)Physics2D.Raycast((Vector2)transform.position, Vector2.down, raycastLength, (int)groundLayerMask);
        Debug.DrawRay(start: transform.position, dir: Vector3.down * raycastLength, Color.green);



        anim.SetBool(name:"isGrounded", isgrounded);

    }
    public void Score_update()
    {
        score++;
        score_text.text = "SCORE : " + score;
    }

}
