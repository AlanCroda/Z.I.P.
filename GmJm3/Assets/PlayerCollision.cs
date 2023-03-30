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

    internal bool isGrounded()
    {
        var center_capsule = capsuleCollider.bounds.center;
        RaycastHit2D hit = Physics2D.Raycast(center_capsule, Vector2.down, 1.5f, player.ground);
        if (hit.collider != null)
        {
            return true;
        }
        return false;
    }
}
