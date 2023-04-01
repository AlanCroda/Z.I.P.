using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Floating : MonoBehaviour
{
    [SerializeField] Player _player;
    [SerializeField] PlayerMovement _playerMovement;

    private float _noFloatSpeed;
    [HideInInspector] public float currentFloatTime;

    private void Awake()
    {
        _player = GetComponent<Player>();
        _playerMovement = GetComponent<PlayerMovement>();
        _noFloatSpeed = _player.maxFallSpeed;
        currentFloatTime = _player.floatTime;
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
        if (_player.playerInput._floatPressed > 0 && currentFloatTime > 0)
        {
            _player._isFloating = true;
        }
        else
        {
            _player._isFloating = false;
        }

        if (_player._isFloating && !_player.collisionScript.isGrounded())
        {
            currentFloatTime -= Time.deltaTime;
            _player.maxFallSpeed = _player.floatSpeed;
        }
        else
        {
            _player.maxFallSpeed = _noFloatSpeed;
        }
    }
}
