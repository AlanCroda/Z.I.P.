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
            Gizmos.DrawCube(transform.position-transform.up*player.maxDistance,player.BoxSize);
    }

    internal bool isGrounded()
    {
        /*var center_capsule = capsuleCollider.bounds.center;
        RaycastHit2D hit = Physics2D.Raycast(center_capsule, Vector2.down, 1.5f, player.ground);
        if (hit.collider != null)
        {
            return true;
        }*/
        if(Physics2D.BoxCast(transform.position,player.BoxSize,0,-transform.up,player.maxDistance,player.ground))
        {
            return true;
        }
        else
        {
            return false;
        }

    }
}
