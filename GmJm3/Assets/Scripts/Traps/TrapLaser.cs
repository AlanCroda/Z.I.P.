using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class TrapLaser : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public Transform point1, point2;

    // Update is called once per frame
    void Update()
    {
        lineRenderer.SetPosition(0, point1.position);
        lineRenderer.SetPosition(1, point2.position);
    }
}
