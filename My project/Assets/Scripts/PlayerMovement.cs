using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jump;
    private Rigidbody2D rigidbody2D;
    private Animator animator;
    private bool grounded;

    public Collider2D collider2D;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        rigidbody2D.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rigidbody2D.velocity.y);

        if (horizontalInput > 0.01f)
            transform.localScale = Vector3.one;
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);
        
        if (Input.GetKey(KeyCode.Space) && grounded)
            Jump();

        if (Input.GetKeyDown(KeyCode.C) && !collider2D.isTrigger)
            collider2D.isTrigger = true;
        else if(Input.GetKeyDown(KeyCode.C) && collider2D.isTrigger)
            collider2D.isTrigger = false;

        if (Input.GetKeyDown(KeyCode.G) && rigidbody2D.gravityScale != 0)
            rigidbody2D.gravityScale = 0;
        else if(Input.GetKeyDown(KeyCode.G) && rigidbody2D.gravityScale == 0)
            rigidbody2D.gravityScale = 1;

        animator.SetBool("Walk", horizontalInput != 0);
        animator.SetBool("isGrounded", grounded);
    }

    private void Jump()
    {
        rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jump);
        animator.SetTrigger("Jump");
        grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.tag == "Ground")
            grounded = true;
    }
}
