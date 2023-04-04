using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Player))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerSO playerSO;
    [SerializeField] private PlayerStateMachine playerStateMachine;
    [SerializeField] private InputSO playerMovement;

    [SerializeField] Player player;
    [SerializeField] PlayerAnimations playerAnims;
    [HideInInspector] public Rigidbody2D rb;
    private PlayerAudio pAudio;

    bool isWallSliding = false;
    internal int facingDirection = -1;

    [HideInInspector]
    public Vector2 _moveInput;
    [HideInInspector]
    public float lastJumpPressed;
    float coyoteTime;



    private void Start()
    {
        pAudio = GetComponent<PlayerAudio>();   
        rb = GetComponent<Rigidbody2D>();
    }

    void move()
    {
        //calculate the direction we want to move in and our target velocity
        float TargetSpeed = playerMovement.vectors[0].x * playerSO.WalkSpeed;
        TargetSpeed = Mathf.Lerp(rb.velocity.x, TargetSpeed, 1);
        //calculated the difference between our current speed and our target speed
        float SpeedDif = TargetSpeed - rb.velocity.x;
        //change acceleration depending on situation
        float accelRate = (Mathf.Abs(TargetSpeed) > 0.01f) ? playerSO.WalkSpeed : playerSO.Deceleration;

        if (!playerStateMachine.isGrounded && rb.velocity.y < playerSO.JumpHangTimeThreshhold)
        {
            SpeedDif *= playerSO.JumpHangMaxSpeedMultiplier;
            accelRate *= playerSO.JumpHangAccelerationMultiplier;
        }

        float movement = SpeedDif * accelRate;

        rb.AddForce(movement * Vector2.right, ForceMode2D.Force);

        if (Mathf.Approximately(playerMovement.vectors[0].x, 0))
        {
            float amount = Mathf.Min(Mathf.Abs(rb.velocity.x), Mathf.Abs(playerSO.Friction));
            amount *= Mathf.Sign(rb.velocity.x);
            rb.AddForce(Vector2.right * -amount, ForceMode2D.Impulse);
        }


        if(playerSO.FacingRight && playerMovement.vectors[0].x < 0)
        {
            Flip();
        }
        else if(!playerSO.FacingRight && playerMovement.vectors[0].x > 0) 
        { 
            Flip(); 
        }

       

    }

    void WallSliding()
    {
        if(playerStateMachine.isWallSliding)
        {
            pAudio.sfxWallSlide(player.sfxWallSlide);
            if (rb.velocity.y < -playerSO.WallSlideSpeed)
            {
                rb.velocity = new Vector2(rb.velocity.x, -playerSO.WallSlideSpeed);
            }
        }
    }

    void jumpSetup()
    {
        if(player.collisionScript.isGrounded() && lastJumpPressed > 0)
        {
            lastJumpPressed = 0;
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(Vector2.up * playerSO.JumpForce, ForceMode2D.Impulse);
        }
        if(playerStateMachine.isWallSliding && !player.collisionScript.isGrounded() && lastJumpPressed > 0)
        {
            lastJumpPressed = 0;
            Vector2 force = new Vector2(playerSO.WallJumpForce.x, playerSO.WallJumpForce.y);
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

        if(!playerMovement.bools[0] && rb.velocity.y > 0)
        {
            rb.AddForce(-Vector2.up * playerSO.JumpCutValue, ForceMode2D.Impulse);
        }

        if(rb.velocity.y < 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Max(rb.velocity.y, playerSO.MaxFallSpeed));
        }
    }

    public void jump(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            lastJumpPressed = playerSO.JumpBuffer;
            if (coyoteTime > 0)
            {
                lastJumpPressed = 0;
                coyoteTime = 0;
                rb.velocity = new Vector2(rb.velocity.x, 0);
                pAudio.sfxJump(player.sfxJump);
                rb.AddForce(Vector2.up * playerSO.JumpForce, ForceMode2D.Impulse);
            }
            else if (playerStateMachine.isWallSliding && !player.collisionScript.isGrounded())
            {
                lastJumpPressed = 0;
                rb.velocity = Vector2.zero;
                
                Vector2 force = new Vector2(playerSO.WallJumpForce.x, playerSO.WallJumpForce.y);
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
        if(playerSO.HasControl)
        {
            move();
            jumpSetup();
        }
    }

    private void Update()
    {
        lastJumpPressed -= Time.deltaTime;
        coyoteTime -= Time.deltaTime;
        if(player.collisionScript.isGrounded())
        {
            coyoteTime = playerSO.CoyoteBufferTime;
        }

        playerStateMachine.isWallSliding = player.collisionScript.touchingWall();
        WallSliding();

        if (playerMovement.vectors[0].x != 0 && player.collisionScript.isGrounded())
        {
            pAudio.sfXWalk(player.sfxWalk);
            player.vfxRun.Play();
        }
        else
        {
            pAudio.stopAudio();
            player.vfxRun.Stop();
        }

    }


    private void Flip()
    {
        if(!isWallSliding)
        {
            facingDirection *= -1;
            playerSO.FacingRight = !playerSO.FacingRight;
            transform.Rotate(0, 180, 0);
        }
    }

}
