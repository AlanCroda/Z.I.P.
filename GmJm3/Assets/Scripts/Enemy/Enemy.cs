using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    private Rigidbody2D rb;
    private Transform currentPoint;
    public float speed;
    public float radius = 5;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentPoint = pointB.transform;

    }

    private void Update()
    {
        EnemyPatrol();
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
        //Gizmos.color(Color.red);
    }

    void RayCast2D()
    {
        RaycastHit2D hit = Physics2D.CircleCast(transform.position, radius, Vector2.zero);

        if (hit.collider.gameObject.tag == "Player")
        {
            //put code here that u want to grab off player
        }
        if (!hit.collider)
        {
            //put code here if no collider is found
           
        }

    }

    void EnemyPatrol()
    {
        Vector2 point = currentPoint.position - transform.position;

        if (currentPoint == pointB.transform)
        {
            rb.velocity = new Vector2(speed, 0);
        }
        else
        {
            rb.velocity = new Vector2(-speed, 0);
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointB.transform)
        {
            currentPoint = pointA.transform;
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointA.transform)
        {
            currentPoint = pointB.transform;
        }
    }
}
