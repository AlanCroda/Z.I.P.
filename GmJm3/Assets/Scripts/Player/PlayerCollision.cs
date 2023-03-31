using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerCollision : MonoBehaviour
{
    [SerializeField] Player player;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(transform.position-transform.up*player.bottomDistance,player.bottomBoxSize);

        Gizmos.color = Color.red;
        Gizmos.DrawCube(transform.position - transform.right * player.rightDistance - transform.up * player.rightBoxCastOffset, player.rightBoxSize);
    }

    internal bool isGrounded()
    {
        if(Physics2D.BoxCast(transform.position,player.bottomBoxSize,0,-transform.up,player.bottomDistance,player.ground))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    internal bool touchingWall()
    {
        if (Physics2D.BoxCast(transform.position - transform.up * player.rightBoxCastOffset, player.rightBoxSize, 0, -transform.right, player.rightDistance, player.ground))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
