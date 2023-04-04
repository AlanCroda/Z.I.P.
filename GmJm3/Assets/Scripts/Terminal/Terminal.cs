using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terminal : MonoBehaviour
{
    [SerializeField] PlayerSO playerSO;

    [SerializeField] bool doubleJumpPickup;
    [SerializeField] bool floatPickup;
    [SerializeField] bool dashPickup;
    private static Terminal terminal;

    private void Start()
    {
        terminal = GetComponent<Terminal>();
    }

    public void Activate()
    {
        if(terminal.doubleJumpPickup)
        {
            playerSO.hasDoubleJumpPowerup = true;
        }
        if(terminal.floatPickup)
        {
            playerSO.hasFloatingPowerup = true;
        }
        if(terminal.dashPickup)
        {
            playerSO.hasDashPowerup = true;
        }
    }
}
