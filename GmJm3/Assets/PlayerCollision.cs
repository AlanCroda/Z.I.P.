using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerCollision : MonoBehaviour
{
    [SerializeField] Player player;

    internal bool isGrounded()
    {
        var center_capsule = player.capsuleCollider.bounds.center;
        RaycastHit2D hit = Physics2D.Raycast(center_capsule, Vector2.down, 1.5f, player.ground);
        if (hit.collider != null)
        {
            return true;
        }
        return false;
    }
}
