using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Floating : MonoBehaviour
{
    [SerializeField] Player _player;
    [SerializeField] PlayerMovement _playerMovement;
    [SerializeField] bool _isFloating;
    [SerializeField] float _floatSpeed;
    private float _noFloatSpeed;

    private void Awake()
    {
        _player = GetComponent<Player>();
        _playerMovement = GetComponent<PlayerMovement>();
        _noFloatSpeed = _player.maxFallSpeed;
    }

    private void FixedUpdate()
    {
        if (_player.hasFloatingPowerup)
        {
            checkFloat();
        }
    }

    public void checkFloat()
    {
        if (_playerMovement._jumpPressed)
        {
            _isFloating = true;
        }
        else
        {
            _isFloating = false;
        }

        if (_isFloating && !_player.collisionScript.isGrounded())
        {
            _player.maxFallSpeed = _floatSpeed;
        }
        else
        {
            _player.maxFallSpeed = _noFloatSpeed;
        }
    }
}
