using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    [SerializeField] Terminal terminal;
    internal bool canInteract = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Terminal")
        {
            canInteract = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Terminal")
        {
            canInteract = false;
        }
    }

    public void interact()
    {
        if(canInteract)
        {
            terminal.Activate();
        }
    }
}
