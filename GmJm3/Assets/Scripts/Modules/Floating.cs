using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Floating : MonoBehaviour
{
    [SerializeField] Player _player;
    [SerializeField] PlayerMovement _movement;

    private float _noFloatSpeed;
    [HideInInspector] public float currentFloatTime;

    private void Awake()
    {
        _player = GetComponent<Player>();
        _movement = GetComponent<PlayerMovement>();
        _noFloatSpeed = _player.maxFallSpeed;
        currentFloatTime = _player.floatTime;
    }

    private void Update()
    {
        if (_player.hasFloatingPowerup && _player.hasControl)
        {
            checkFloat();
        }
        if(!_player.hasControl)
        {
            _player._isFloating = false;
            _player.maxFallSpeed = _noFloatSpeed;
        }

        if (_player._isFloating)
        {
            _player.vfxFloat.Play();
            _movement._jumpPressed = false;
        }
        else
        {
            _player.vfxFloat.Stop();
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
