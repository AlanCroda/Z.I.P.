using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class actionEvent : MonoBehaviour
{
    public UnityEvent onEnter,onStay,onExit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        onEnter?.Invoke();
    }
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        onStay?.Invoke();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        onExit?.Invoke();
    }
}
