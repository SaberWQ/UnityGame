using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;

    private Vector2 moveVector;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;

    private bool isLeft = false;
    private bool isGround = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //animation = GetComponent<Animation>();
    }


    void Update()
    {

        Walk();
        Jump();
        Flip();

    }

    private void Walk()
    {
        float moveX = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveX * speed, rb.linearVelocity.y);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
            rb.AddForce(Vector2.up * jumpForce);
    }

    private void Flip()
    {
        if ((!isLeft && moveVector.x < 0) || (!isLeft && moveVector.x > 0))
        {
            transform.localScale *= new Vector2(-1, 1);
            isLeft = !isLeft;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("ground"))
            isGround = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("ground"))
            isGround = false;
    }
}
