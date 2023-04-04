using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Player))]
public class PlayerInput : MonoBehaviour
{
    [SerializeField] Player player;
    internal _playerActions _playerActions;
    [SerializeField] InputSO playerMovement;

    internal Vector2 _moveInput;
    internal float _jumpPressed;
    internal float _floatPressed;
    internal float _dashPressed;

    private void Awake()
    {
        _playerActions = new _playerActions();
    }


    private void OnEnable()
    {
        _playerActions.Player.Enable();
    }

    private void OnDisable()
    {
        _playerActions.Player.Disable();
    }


    private void Update()
    {
        playerMovement.vectors[0].x = _playerActions.Player.Movement.ReadValue<Vector2>().x;
        playerMovement.vectors[0].y = _playerActions.Player.Movement.ReadValue<Vector2>().y;
        playerMovement.bools[0] = (_playerActions.Player.Jump.ReadValue<float>() > 0);
        playerMovement.floats[0] = _playerActions.Player.Float.ReadValue<float>();
    }
}
