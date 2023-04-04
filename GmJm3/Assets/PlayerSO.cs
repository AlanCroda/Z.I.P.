using UnityEditor.Build;
using UnityEngine;

[CreateAssetMenu(menuName = "PlayerSO / Variables")]
public class PlayerSO : ScriptableObject
{
    [Header("Movement")]
    [SerializeField] public float WalkSpeed;
    [SerializeField] public float Acceleration;
    [SerializeField] public float Deceleration;
    [SerializeField] public float Friction;

    [Header("State Machine")]
    [SerializeField] public bool FacingRight;
    [SerializeField] public bool HasControl;

    [SerializeField] public bool IsFloating;
    [SerializeField] public bool CanDoubleJump;
    [SerializeField] public bool canDash;
    [SerializeField] public bool isWallSliding;

    [SerializeField] public bool HasFloatingPowerup;
    [SerializeField] public bool HasDoubleJumpPowerUp;
    [SerializeField] public bool HasDashPowerup;

    [Header("Jumping")]
    [SerializeField] public float JumpForce;
    [SerializeField] public float FallMultiplier;
    [SerializeField] public float MaxFallSpeed;
    [SerializeField] public float JumpHangTimeThreshhold;
    [SerializeField] public float JumpHangAccelerationMultiplier;
    [SerializeField] public float JumpHangMaxSpeedMultiplier;
    [SerializeField] public Vector2 WallJumpForce;
    [SerializeField] public float WallSlideSpeed;
    [SerializeField] public float JumpCutValue;
    [SerializeField] public float JumpBuffer;
    [SerializeField] public float CoyoteBufferTime;

    [Header("Powerups")]
    [SerializeField]
    public bool hasFloatingPowerup;
    [SerializeField]
    public bool _isFloating;
    [SerializeField]
    public float floatTime;
    [SerializeField]
    public float floatSpeed;
    [SerializeField]
    public bool hasDoubleJumpPowerup;
    [SerializeField]
    public bool canDoubleJump;
    [SerializeField]
    public float doubleJumpForce;
    [SerializeField]
    public bool hasDashPowerup;
    [SerializeField]
    public float dashForce;
    [SerializeField]
    public float dashTime;

    private void OnEnable()
    {
        FacingRight = true;
        HasControl = true;
        floatTime = 1.5f;
    }
}
