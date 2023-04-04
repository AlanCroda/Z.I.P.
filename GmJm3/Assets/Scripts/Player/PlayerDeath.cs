using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField]
    Player player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Checkpoint")
        {
            player.checkpointPosition = collision.gameObject.transform.position;
        }

        if(collision.gameObject.tag == "Trap")
        {
            player.transform.position = player.checkpointPosition;
        }
    }
}
