using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terminal : MonoBehaviour
{
    [SerializeField]
    bool doubleJumpPickup;
    [SerializeField]
    bool floatPickup;
    [SerializeField]
    bool dashPickup;
    [SerializeField]
    Player player;

    public void Activate()
    {
        if (doubleJumpPickup)
        {
            player.hasDoubleJumpPowerup = true;
        }
        if(floatPickup)
        {
            player.hasFloatingPowerup = true;
        }
        if(dashPickup)
        {
            player.hasDashPowerup = true;
        }
    }
}
