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

    [Header("Layers")]
    [SerializeField]
    internal LayerMask ground;

    [Header("Movement")]
    [SerializeField]
    internal float walkSpeed;
    [SerializeField]
    internal float acceleration;
    [SerializeField]
    internal float decceleration;
    [SerializeField]
    internal float frictionAmount;
    [SerializeField]
    internal bool facingRight;

    [Header("Jumping")]
    [SerializeField]
    internal float jumpForce;
    [SerializeField]
    internal float fallMultiplier;
    [SerializeField]
    internal float maxFallSpeed;
    [SerializeField]
    internal float jumpHangTimeThreshold;
    [SerializeField]
    internal float jumpHangAccelerationMultiplier;
    [SerializeField]
    internal float jumpHangMaxSpeedMultiplier;
    [SerializeField]
    internal Vector2 wallJumpForce;
    [SerializeField]
    internal int jumpsLeft;
    internal int amountOfJumps;
    [SerializeField]
    internal float wallSlideSpeed;
    [SerializeField]
    internal float jumpCutValue;
    [SerializeField]
    internal float jumpBuffer;
    [SerializeField]
    internal float coyoteBufferTime;

    [Header("GroundCheck")]
    [SerializeField]
    internal Vector3 bottomBoxSize;
    [SerializeField]
    internal Vector3 rightBoxSize;
    [SerializeField]
    internal float bottomDistance;
    [SerializeField]
    internal float rightDistance;
    [SerializeField]
    internal float leftDistance;
    [SerializeField]
    internal float sideBoxCastOffset;

    [Header("Particle Effects")]
    [SerializeField]
    internal ParticleSystem vfxRun;
}
