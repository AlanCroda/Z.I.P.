using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Player player;
    Rigidbody2D rb;

    Vector2 _moveInput;
    bool _jumpPressed;
    

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void move()
    {
        rb.velocity = new Vector2(_moveInput.x * player.walkSpeed, rb.velocity.y);
    }

    void jumpSetup()
    {
        if (_jumpPressed)
        {
            jump();
        }
        //var height
        if(!_jumpPressed && rb.velocity.y > 0) {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.2f * Time.deltaTime);
        }
    }

    internal void jump()
    {
        if(player.collisionScript.isGrounded())
        {
            //can jump
            rb.AddForce(Vector2.up * player.jumpForce, ForceMode2D.Impulse);
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
        _moveInput = player.playerInput._moveInput;
    }


}
