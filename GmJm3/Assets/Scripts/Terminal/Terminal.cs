using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terminal : MonoBehaviour
{
    [SerializeField] bool doubleJumpPickup;
    [SerializeField] bool floatPickup;
    [SerializeField] bool dashPickup;
    private static Player player;
    private static Terminal terminal;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        terminal = GetComponent<Terminal>();
    }

    public void Activate()
    {
        if(terminal.doubleJumpPickup)
        {
            player.hasDoubleJumpPowerup = true;
        }
        if(terminal.floatPickup)
        {
            player.hasFloatingPowerup = true;
        }
        if(terminal.dashPickup)
        {
            player.hasDashPowerup = true;
        }
    }
}
