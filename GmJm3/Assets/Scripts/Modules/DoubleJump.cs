using System.Collections;
using UnityEngine;

public class DoubleJump : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private screenShake screenShake;
    [SerializeField] private PlayerSO playerSO;
    [SerializeField] private InputSO playerMovement;
    //[SerializeField] private float timescale = 1;

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    public void doubleJump()
    {
        if(!player.collisionScript.isGrounded() && !player.collisionScript.touchingWall() && playerSO.canDoubleJump && playerSO.hasDoubleJumpPowerup)
        {

            StartCoroutine(FreezeFrames());
        }
    }

    IEnumerator FreezeFrames()
    {
        screenShake.ShakeScreen(.5f, .5f);
        player.vfxDoubleJump.Play();
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(0.02f);
        Time.timeScale = 1;
        player.playerMovement.lastJumpPressed = 0;
        playerSO.canDoubleJump = false;
        player.playerMovement.rb.velocity = new Vector2(playerMovement.vectors[1].x, 0);
        player.playerMovement.rb.AddForce(Vector2.up * playerSO.doubleJumpForce, ForceMode2D.Impulse);
    }

}
