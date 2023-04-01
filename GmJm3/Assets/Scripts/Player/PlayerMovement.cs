using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Player))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] PlayerAnimations playerAnims;
    [HideInInspector] public Rigidbody2D rb;

    bool isWallSliding = false;
    int facingDirection = -1;

    [HideInInspector]
    public Vector2 _moveInput;
    [HideInInspector]
    public bool _jumpPressed = false;
    [HideInInspector]
    public float lastJumpPressed;
    float coyoteTime;



    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void move()
    {
        //calculate the direction we want to move in and our target velocity
        float TargetSpeed = _moveInput.x * player.walkSpeed;
        TargetSpeed = Mathf.Lerp(rb.velocity.x, TargetSpeed, 1);
        //calculated the difference between our current speed and our target speed
        float SpeedDif = TargetSpeed - rb.velocity.x;
        //change acceleration depending on situation
        float accelRate = (Mathf.Abs(TargetSpeed) > 0.01f) ? player.acceleration : player.decceleration;

        if (!player.collisionScript.isGrounded() && rb.velocity.y < player.jumpHangTimeThreshold)
        {
            SpeedDif *= player.jumpHangMaxSpeedMultiplier;
            accelRate *= player.jumpHangAccelerationMultiplier;
        }

        float movement = SpeedDif * accelRate;

        rb.AddForce(movement * Vector2.right, ForceMode2D.Force);

        if (Mathf.Approximately(_moveInput.x, 0))
        {
            float amount = Mathf.Min(Mathf.Abs(rb.velocity.x), Mathf.Abs(player.frictionAmount));
            amount *= Mathf.Sign(rb.velocity.x);
            rb.AddForce(Vector2.right * -amount, ForceMode2D.Impulse);
        }


        if(player.facingRight && _moveInput.x < 0)
        {
            Flip();
        }
        else if(!player.facingRight && _moveInput.x > 0) 
        { 
            Flip(); 
        }

    }

    void WallSliding()
    {
        if(isWallSliding)
        {
            if(rb.velocity.y < -player.wallSlideSpeed)
            {
                rb.velocity = new Vector2(rb.velocity.x, -player.wallSlideSpeed);
            }
        }
    }

    void jumpSetup()
    {
        if(player.collisionScript.isGrounded() && lastJumpPressed > 0)
        {
            lastJumpPressed = 0;
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(Vector2.up * player.jumpForce, ForceMode2D.Impulse);
        }
        if(isWallSliding && !player.collisionScript.isGrounded() && lastJumpPressed > 0)
        {
            lastJumpPressed = 0;
            Vector2 force = new Vector2(player.wallJumpForce.x, player.wallJumpForce.y);
            force.x *= facingDirection;

            if (Mathf.Sign(rb.velocity.x) != Mathf.Sign(force.x))
            {
                force.x -= rb.velocity.x;
            }

            if (rb.velocity.y < 0)
            {
                force.y -= rb.velocity.y;
            }

            rb.AddForce(force, ForceMode2D.Impulse);
        }

        if(lastJumpPressed > 0)
        {
            player.doubleJump.doubleJump();
        }

        if(!_jumpPressed && rb.velocity.y > 0)
        {
            rb.AddForce(-Vector2.up * player.jumpCutValue, ForceMode2D.Impulse);
        }

        if(rb.velocity.y < 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Max(rb.velocity.y, player.maxFallSpeed));
        }
    }

    public void jump(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            lastJumpPressed = player.jumpBuffer;
            if (coyoteTime > 0)
            {
                lastJumpPressed = 0;
                coyoteTime = 0;
                rb.velocity = new Vector2(rb.velocity.x, 0);
                rb.AddForce(Vector2.up * player.jumpForce, ForceMode2D.Impulse);
            }
            else if (isWallSliding && !player.collisionScript.isGrounded())
            {
                lastJumpPressed = 0;
                rb.velocity = Vector2.zero;
                Vector2 force = new Vector2(player.wallJumpForce.x, player.wallJumpForce.y);
                force.x *= facingDirection;

                if (Mathf.Sign(rb.velocity.x) != Mathf.Sign(force.x))
                {
                    force.x -= rb.velocity.x;
                }

                if (rb.velocity.y < 0)
                {
                    force.y -= rb.velocity.y;
                }

                rb.AddForce(force, ForceMode2D.Impulse);
            }
        }
    }

    private void FixedUpdate()
    {
        move();
        jumpSetup();
    }

    private void Update()
    {
        _jumpPressed = (player.playerInput._jumpPressed > 0);

        lastJumpPressed -= Time.deltaTime;
        coyoteTime -= Time.deltaTime;
        if(player.collisionScript.isGrounded())
        {
            coyoteTime = player.coyoteBufferTime;
        }

        _moveInput = player.playerInput._moveInput;

        isWallSliding = player.collisionScript.touchingWall();
        WallSliding();

        if (_moveInput.x != 0 && player.collisionScript.isGrounded())
        {
            player.vfxRun.Play();
        }
        else if(_moveInput.x == 0 || !player.collisionScript.isGrounded())
        {
            player.vfxRun.Stop();
        }
    }


    private void Flip()
    {
        if(!isWallSliding)
        {
            facingDirection *= -1;
            player.facingRight = !player.facingRight;
            transform.Rotate(0, 180, 0);
        }
    }

}
