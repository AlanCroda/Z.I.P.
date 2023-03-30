using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerCollision : MonoBehaviour
{
    [SerializeField] Player player;

    internal CapsuleCollider2D capsuleCollider;

    private void Awake()
    {
        capsuleCollider = GetComponent<CapsuleCollider2D>();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(transform.position-transform.up*player.maxDistance,player.bottomBoxSize);

        Gizmos.color = Color.red;
        Gizmos.DrawCube(transform.position - transform.right/2 * player.maxDistance, player.leftBoxSize);

        Gizmos.color = Color.red;
        Gizmos.DrawCube(transform.position + transform.right/2 * player.maxDistance, player.rightBoxSize);
    }

    internal bool isGrounded()
    {
        if(Physics2D.BoxCast(transform.position,player.bottomBoxSize,0,-transform.up,player.maxDistance,player.ground))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    internal int touchingWall()
    {
        if (Physics2D.BoxCast(transform.position, player.leftBoxSize, 0, -transform.right/2, player.maxDistance, player.ground))
        {
            return 1;
        }
        if (Physics2D.BoxCast(transform.position, player.rightBoxSize, 0, transform.right/2, player.maxDistance, player.ground))
        {
            return -1;
        }
        else
        {
            return 0;
        }
    }
}
