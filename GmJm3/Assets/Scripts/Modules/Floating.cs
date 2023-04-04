using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Floating : MonoBehaviour
{
    [SerializeField] Player _player;
    [SerializeField] PlayerMovement _movement;
    [SerializeField] PlayerSO playerSO;

    [SerializeField] InputSO playerMovement;

    private float _noFloatSpeed;
    public float currentFloatTime;

    private void Awake()
    {
        _player = GetComponent<Player>();
        _movement = GetComponent<PlayerMovement>();
        _noFloatSpeed = playerSO.MaxFallSpeed;
        currentFloatTime = playerSO.floatTime;
    }

    private void Update()
    {
        if (playerSO.HasFloatingPowerup && playerSO.HasControl)
        {
            checkFloat();
        }
        if(!playerSO.HasControl)
        {
            playerSO.IsFloating = false;
            playerSO.MaxFallSpeed = _noFloatSpeed;
        }

        if (playerSO.IsFloating)
        {
            _player.vfxFloat.Play();
            playerMovement.bools[0] = false;
        }
        else
        {
            _player.vfxFloat.Stop();
        }
    }

    public void checkFloat()
    {
        if (playerMovement.floats[0] > 0 && currentFloatTime > 0)
        {
            playerSO.IsFloating = true;
        }
        else
        {
            playerSO.IsFloating = false;
        }

        if (playerSO.IsFloating && !_player.collisionScript.isGrounded())
        {
            currentFloatTime -= Time.deltaTime;
            playerSO.MaxFallSpeed = playerSO.floatSpeed;
        }
        else
        {
            playerSO.MaxFallSpeed = _noFloatSpeed;
        }
    }
}
