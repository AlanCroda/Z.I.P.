using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] private Animator _anim;
    [SerializeField] private PlayerMovement _movement;
    [SerializeField] private PlayerCollision collision;
    [SerializeField] private Player playerVariables;
    [SerializeField] private PlayerStateMachine playerStateMachine;

    [SerializeField] InputSO playerMovement;

    private float _lockedTill;

    private void Start()
    {
        _movement = GetComponent<PlayerMovement>();
        collision = GetComponent<PlayerCollision>();
        playerVariables = GetComponent<Player>();
    }

    private void Update()
    {
        var state = GetState();

        if (state == _currentState) return;
        _anim.CrossFade(state, 0.1f, 0);
        _currentState = state;
    }

    private int GetState()
    {
        if (Time.time < _lockedTill) return _currentState;
        // Priorities

        if (playerMovement.bools[0]) return Jump;
        if (playerStateMachine.isFloating && !collision.isGrounded()) return Floating; 
        if (playerMovement.vectors[0].x ==0) return Idle;
        if (collision.isGrounded()) return playerMovement.vectors[0].x == 0 ? Idle : Walk; 
        return playerMovement.vectors[0].y > 0 ? Jump : Walk;

        //int LockState(int s, float t)
        //{
        //    _lockedTill = Time.time + t;
        //    return s;
        //}
    }


    #region Cached Properties

    private int _currentState;
    private static readonly int Idle = Animator.StringToHash("PlayerIdle");
    private static readonly int Walk = Animator.StringToHash("PlayerWalk");
    private static readonly int Jump = Animator.StringToHash("PlayerJump");
    private static readonly int Floating = Animator.StringToHash("PlayerFloating");

    #endregion
}
