using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DoubleJump : MonoBehaviour
{
    [SerializeField] Player player;

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    public void doubleJump()
    {
        if(!player.collisionScript.isGrounded() && !player.collisionScript.touchingWall() && player.canDoubleJump && player.hasDoubleJumpPowerup)
        {
            player.playerMovement.lastJumpPressed = 0;
            player.canDoubleJump = false;
            player.playerMovement.rb.velocity = new Vector2(player.playerMovement.rb.velocity.x, 0);
            player.playerMovement.rb.AddForce(Vector2.up * player.doubleJumpForce, ForceMode2D.Impulse);
        }
    }
}
