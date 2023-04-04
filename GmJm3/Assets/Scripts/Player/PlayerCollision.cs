using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerCollision : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] PlayerSO playerSO;
    [SerializeField] PlayerStateMachine playerStateMachine;


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(transform.position-transform.up*player.bottomDistance,player.bottomBoxSize);

        Gizmos.color = Color.red;
        Gizmos.DrawCube(transform.position - transform.right * player.rightDistance - transform.up * player.sideBoxCastOffset, player.rightBoxSize);

        Gizmos.color = Color.red;
        Gizmos.DrawCube(transform.position + transform.right * player.leftDistance - transform.up * player.sideBoxCastOffset, player.rightBoxSize);
    }

    internal bool isGrounded()
    {
        if(Physics2D.BoxCast(transform.position,player.bottomBoxSize,0,-transform.up,player.bottomDistance,player.ground))
        {
            playerStateMachine.isGrounded = true;
            ResetPowerups();
            return true;
        }
        else
        {
            playerStateMachine.isGrounded = false;
            return false;
        }
    }

    internal bool touchingWall()
    {
        if (Physics2D.BoxCast(transform.position - transform.up * player.sideBoxCastOffset, player.rightBoxSize, 0, -transform.right, player.rightDistance, player.ground))
        {
            playerStateMachine.touchingWall = true;
            return true;
        }
        if (Physics2D.BoxCast(transform.position - transform.up * player.sideBoxCastOffset, player.rightBoxSize, 0, transform.right, player.leftDistance, player.ground))
        {
            playerStateMachine.touchingWall = false;
            return false;
        }
        else { playerStateMachine.touchingWall = false;
            return false;
        }
    }

    public void ResetPowerups()
    {
        playerSO.CanDoubleJump = true;
        player.floating.currentFloatTime = playerSO.floatTime;
        playerSO.canDash = true;
    }
}
