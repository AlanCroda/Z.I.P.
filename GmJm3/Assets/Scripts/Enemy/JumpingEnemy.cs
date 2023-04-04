using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
public class JumpingEnemy : MonoBehaviour
{
    [Header("Jumping")]
    [Tooltip("This effects Jump Height")]
    [Range(2f,8f)]
    [SerializeField] private float jumpHeight;

    [Header("Movement")]
    [Tooltip("Speed Of Enemy")]
    [Range(4f,10f)]
    [SerializeField] private float speed;
    [Tooltip("Distance from and to the enemy")]
    [Range(3f,8f)]
    [SerializeField] private float distance;


    #region ignore
    //Private
    [SerializeField] private float pointA;
    [SerializeField] private float pointB;
    float PlayerPos;
    private float dir;
    private float coolDown = 0.2f;
    private float jumpCoolDown;
    private float groundCheck = 2f;


    //Components
    private CapsuleCollider2D collisionCollider;
    private Rigidbody2D rb;
    #endregion

    #region Initiation

    private void Start()
    {
        Init();     
    }

    private void Init()
    {
        dir = speed;
        collisionCollider = GetComponent<CapsuleCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        jumpCoolDown = coolDown;
        rb.velocity = new Vector2(dir, rb.velocity.y);
        PlayerPos = transform.position.x;
        pointA = PlayerPos + distance;
        pointB = PlayerPos - distance;

    }
    #endregion

    #region Update
    protected virtual void Update()
    {
        OnMove();
        JumpEnemy();
        jumpCoolDown -= Time.deltaTime;

    }

    #endregion

    #region Jump

    void JumpEnemy()
    {
        if(jumpCoolDown <= 0)
        {
            if (isGrounded())
            {
                print("Jumped");
                rb.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
            }
            jumpCoolDown = coolDown;
        }
         
    }

    private bool isGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, groundCheck, LayerMask.GetMask("Ground"),0);
        return hit;
    }

    #endregion

    #region Movement
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
    #endregion
}
