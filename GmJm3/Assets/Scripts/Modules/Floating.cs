using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Floating : MonoBehaviour
{
    [SerializeField] Player _player;
    [SerializeField] bool _isFloating;
    [SerializeField] float _floatSpeed;
    private float _noFloatSpeed;

    private void Awake()
    {
        _player = GetComponent<Player>();
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
        // TODO: Research how to use "Jump" InputSystem event as a KeyHeldDown to activate this method,
        // for now it's bound to Spacebar held down.
        if (Input.GetKey(KeyCode.Space))
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
