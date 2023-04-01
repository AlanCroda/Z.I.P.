using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Player))]
public class PlayerInput : MonoBehaviour
{
    [SerializeField] Player player;
    internal _playerActions _playerActions;

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
        _moveInput.x = _playerActions.Player.Movement.ReadValue<Vector2>().x;
        _moveInput.y = _playerActions.Player.Movement.ReadValue<Vector2>().y;
        _jumpPressed = _playerActions.Player.Jump.ReadValue<float>();
        _floatPressed = _playerActions.Player.Float.ReadValue<float>();
    }
}
