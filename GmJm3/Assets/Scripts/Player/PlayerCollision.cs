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
