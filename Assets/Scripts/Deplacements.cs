using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.InputSystem;

public class Deplacements : MonoBehaviour
{
    public GameObject LeftHandObject;
    public GameObject rightHandObject;


    float leftpressed = 0;
    float rightpressed = 0;

    private void OnLeftTriggerPressed(InputValue value)
    {
        leftpressed = value.Get<float>();
    }

    private void OnRightTriggerPressed(InputValue value)
    {
        rightpressed = value.Get<float>();
    }

    private void Update()
    {
        if (leftpressed > .8f)
            DrawLeftLine();
        if (rightpressed > .8f)
            DrawRightLine();
    }

    private void DrawLeftLine()
    {
        Debug.DrawLine(LeftHandObject.transform.position, LeftHandObject.transform.position + LeftHandObject.transform.forward, Color.red);
        Debug.DrawLine(LeftHandObject.transform.position, LeftHandObject.transform.position - LeftHandObject.transform.forward, Color.green);
        Debug.DrawLine(LeftHandObject.transform.position, LeftHandObject.transform.position - LeftHandObject.transform.right, Color.blue);
        Debug.DrawLine(LeftHandObject.transform.position, LeftHandObject.transform.position + LeftHandObject.transform.right, Color.yellow);
    }

    private void DrawRightLine()
    {
        Debug.DrawLine(rightHandObject.transform.position, rightHandObject.transform.position + rightHandObject.transform.forward, Color.red);
        Debug.DrawLine(rightHandObject.transform.position, rightHandObject.transform.position - rightHandObject.transform.forward, Color.green);
        Debug.DrawLine(rightHandObject.transform.position, rightHandObject.transform.position - rightHandObject.transform.right, Color.blue);
        Debug.DrawLine(rightHandObject.transform.position, rightHandObject.transform.position + rightHandObject.transform.right, Color.yellow);
    }
}
