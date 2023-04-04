using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(menuName ="StateMachine/Player")]
public class PlayerStateMachine : ScriptableObject
{
    [SerializeField] public bool isFloating;
    [SerializeField] public bool isWallSliding;
    [SerializeField] public bool isGrounded;
    [SerializeField] public bool touchingWall;
}
