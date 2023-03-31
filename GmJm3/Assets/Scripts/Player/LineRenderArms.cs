using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRenderArms : MonoBehaviour
{
    [SerializeField] private LineRenderer RightLR, LeftLR;
    [SerializeField] private Transform RightHand, RightShoulder, LeftHand, LeftShoulder;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        rightArm();
        leftArm();
    }

    void rightArm()
    {
        RightLR.SetPosition(0, RightShoulder.position);
        RightLR.SetPosition(1, RightHand.position);
    }
    void leftArm()
    {
        LeftLR.SetPosition(0, LeftShoulder.position);
        LeftLR.SetPosition(1, LeftHand.position);
    }


}
