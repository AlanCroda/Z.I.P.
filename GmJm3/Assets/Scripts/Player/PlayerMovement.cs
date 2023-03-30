using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Player player;
    Rigidbody2D rb;

    Vector2 _moveInput;
    bool _jumpPressed;
    bool isWallSliding = false;
    int facingDirection = 1;
    

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
            TargetSpeed *= player.jumpHangMaxSpeedMultiplier;
            accelRate *= player.jumpHangAccelerationMultiplier;
        }

        float movement = SpeedDif * accelRate;

        rb.AddForce(movement * Vector2.right, ForceMode2D.Force);

        if (Mathf.Approximately(_moveInput.x, 0))
        {
            float amount = Mathf.Min(Mathf.Abs(rb.velocity.x), Mathf.Abs(player.frictionAmount));
            amount *= Mathf.Sign(rb.velocity.x);
            rb.AddForce(Vector2.right * -amount, ForceMode2D.Force);
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
        if (_jumpPressed)
        {
            jump();
        }
        //var height
        if(!_jumpPressed && rb.velocity.y > 0) {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * player.fallMultiplier * Time.deltaTime);
        }
        if(rb.velocity.y < 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Max(rb.velocity.y, player.maxFallSpeed));
        }
    }

    internal void jump()
    {
        if(player.collisionScript.isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            //can jump
            rb.AddForce(Vector2.up * player.jumpForce, ForceMode2D.Impulse);
        }
        else if(isWallSliding && !player.collisionScript.isGrounded()) 
        {
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

    /*
    internal void wallJump(int wallJumpDirection)
    {
        Vector2 force = new Vector2(player.wallJumpForce.x, player.wallJumpForce.y);
        force.x *= wallJumpDirection;

        if (Mathf.Sign(rb.velocity.x) != Mathf.Sign(force.x))
        {
            force.x -= rb.velocity.x;
        }

        if (rb.velocity.y < 0)
        {
            force.y -= rb.velocity.y;
        }

        rb.AddForce(force, ForceMode2D.Impulse);
    }*/

    private void FixedUpdate()
    {
        move();
        jumpSetup();
    }

    private void Update()
    {
        _jumpPressed = (player.playerInput._jumpPressed > 0);
        _moveInput = player.playerInput._moveInput;
        isWallSliding = player.collisionScript.touchingWall();
        WallSliding();
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
