using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
public class JumpingEnemy : MonoBehaviour
{
    public float pointA;
    public float pointB;
    private Rigidbody2D rb;
    public float speed;

    public float jumpHeight;
    public LayerMask groundLayer;
    public float groundCheck;
    public Vector2 boxSize;
    [SerializeField] private float dir;
    [SerializeField] private float distance;
    float PlayerPos;
    public CapsuleCollider2D capsuleCollider;
    private float jumpCoolDown;
    [SerializeField] private float coolDown;




    private void Start()
    {
        Init();     
    }

    private void Init()
    {
        dir = speed;
        rb = GetComponent<Rigidbody2D>();
        jumpCoolDown = coolDown;
        rb.velocity = new Vector2(dir, rb.velocity.y);
        pointA = distance;
        pointB = -distance;

    }
    private void Update()
    {
        OnMove();
        JumpEnemy();
        jumpCoolDown -= Time.deltaTime;

    }
    

    void JumpEnemy()
    {   
        if(jumpCoolDown <= 0)
        {
            if (isGrounded())
            {
                rb.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);

            }
            jumpCoolDown = coolDown;
        }
         
    }

    private bool isGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1f, groundLayer,0);
        return hit;
    }
    private void OnMove()
    {
        rb.velocity = new Vector2(dir, rb.velocity.y);
        PlayerPos = transform.position.x;
        if (PlayerPos > pointA )
        {       
            dir = -speed ;           
        }
        
        if(PlayerPos < pointB)
        {
            dir = speed;           
        }
        
    }


}
