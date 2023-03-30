using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [Header("Files")]
    [Tooltip("Files connected to this script")]
    //areas
    [SerializeField]
    internal PlayerInput playerInput;
    [SerializeField]
    internal PlayerMovement playerMovement;
    [SerializeField]
    internal PlayerCollision collisionScript;

    [Header("Health")]
    [SerializeField]
    internal int health;

    [Header("Layers")]
    [SerializeField]
    internal LayerMask ground;

    [Header("Movement")]
    [SerializeField]
    internal float jumpForce;
    [SerializeField]
    internal float fallMultiplier;
    [SerializeField]
    internal float walkSpeed = 0;
}
