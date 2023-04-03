using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Dash : MonoBehaviour
{
    [SerializeField]
    Player player;

    public void dash(InputAction.CallbackContext context)
    {
        if(context.started && player.canDash && player.hasDashPowerup)
        {
            player.hasControl = false;
            if (player.hasDashPowerup && player.playerInput._moveInput.magnitude > 0)
            {
                player.playerMovement.rb.velocity = Vector2.zero;
                player.playerMovement.rb.AddForce(player.playerInput._moveInput * player.dashForce, ForceMode2D.Impulse);
                StartCoroutine(DashCoroutine());
            }
            else
            {
                player.playerMovement.rb.velocity = Vector2.zero;
                player.playerMovement.rb.AddForce(Vector2.right * -player.playerMovement.facingDirection * player.dashForce, ForceMode2D.Impulse);
                StartCoroutine(DashCoroutine());
            }
            player.canDash = false;
        }

        IEnumerator DashCoroutine()
        {
            player.playerMovement.rb.gravityScale = 0;
            yield return new WaitForSeconds(player.dashTime);
            player.playerMovement.rb.gravityScale = 5;
            player.hasControl = true;
        }
    }
}
