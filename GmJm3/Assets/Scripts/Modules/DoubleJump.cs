using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DoubleJump : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private screenShake screenShake;
    //[SerializeField] private float timescale = 1;

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    public void doubleJump()
    {
        if(!player.collisionScript.isGrounded() && !player.collisionScript.touchingWall() && player.canDoubleJump && player.hasDoubleJumpPowerup)
        {

            StartCoroutine(FreezeFrames());
        }
    }

    IEnumerator FreezeFrames()
    {
        screenShake.ShakeScreen(.5f, 1.2f);
        player.vfxDoubleJump.Play();
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(0.02f);
        Time.timeScale = 1;
        player.playerMovement.lastJumpPressed = 0;
        player.canDoubleJump = false;
        player.playerMovement.rb.velocity = new Vector2(player.playerMovement.rb.velocity.x, 0);
        player.playerMovement.rb.AddForce(Vector2.up * player.doubleJumpForce, ForceMode2D.Impulse);
    }

}
