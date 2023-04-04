using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class actionEvent : MonoBehaviour
{
    public bool isInRange;
    public UnityEvent onEnter,onStay,onExit;
    public KeyCode getKey;


    private void Update()
    {
        if(isInRange)
        {
            if (Input.GetKeyDown(getKey)) onStay?.Invoke();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isInRange = true;
    }
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        isInRange = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isInRange = false;
    }
}
