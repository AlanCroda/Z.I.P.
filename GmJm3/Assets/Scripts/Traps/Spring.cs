using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    [SerializeField]
    Player player;
    [SerializeField]
    float springForce;
    [SerializeField]
    float springVerticalForce;
    [SerializeField]
    bool up;
    [SerializeField]
    bool down;
    [SerializeField]
    bool right;
    [SerializeField]
    bool left;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(up)
            {
                player.playerMovement.rb.velocity = new Vector2(player.playerMovement.rb.velocity.x, 0);
                player.playerMovement.rb.AddForce(Vector2.up * springForce, ForceMode2D.Impulse);
            }
            if (right)
            {
                player.playerMovement.rb.velocity = new Vector2(0, player.playerMovement.rb.velocity.y);
                player.playerMovement.rb.AddForce(new Vector2(springForce, springVerticalForce), ForceMode2D.Impulse);
            }
            if (down)
            {
                player.playerMovement.rb.velocity = new Vector2(player.playerMovement.rb.velocity.x, 0);
                player.playerMovement.rb.AddForce(-Vector2.up * springForce, ForceMode2D.Impulse);
            }
            if (left)
            {
                player.playerMovement.rb.velocity = new Vector2(0, player.playerMovement.rb.velocity.x);
                player.playerMovement.rb.AddForce(new Vector2(-springForce, springVerticalForce), ForceMode2D.Impulse);
            }

            player.collisionScript.ResetPowerups();
        }
    }
}
