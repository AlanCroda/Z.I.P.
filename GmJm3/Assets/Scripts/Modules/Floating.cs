using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Floating : MonoBehaviour
{
    [SerializeField] Player _player;
    [SerializeField] PlayerMovement _playerMovement;
    [SerializeField] float _floatSpeed, floatHorizontalSpeed;
    [SerializeField] ParticleSystem VFXFloat;
    public bool _isFloating;
    private float _noFloatSpeed;

    private void Awake()
    {
        _player = GetComponent<Player>();
        _playerMovement = GetComponent<PlayerMovement>();
        _noFloatSpeed = _player.maxFallSpeed;
        floatHorizontalSpeed = _player.walkSpeed;
    }

    private void Update()
    {
        if (_player.hasFloatingPowerup)
        {
            checkFloat();
        }

        if (_isFloating)
        {
            VFXFloat.Play();
        }
        else
        {
            VFXFloat.Stop();    
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
            ///_player.walkSpeed = floatHorizontalSpeed/2; slow down floating speed but affects normal jump speed.
        }
        else
        {
            _player.maxFallSpeed = _noFloatSpeed;
            // _player.walkSpeed = floatHorizontalSpeed; slow down floating speed but affects normal jump speed.

        }
    }
}
