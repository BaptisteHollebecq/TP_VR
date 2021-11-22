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
    public GameObject Orb;


    float leftpressed = 0;
    bool movementLeft = false;
    float rightpressed = 0;
    bool movementRight = false;

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
        if (leftpressed > .9f)
            DrawLeftLine();
        if (leftpressed == 0 && movementLeft)
            ShotLeft();
        if (rightpressed > .9f)
            DrawRightLine();
        if (rightpressed == 0 && movementRight)
            ShotRight();
    }

    private void ShotRight()
    {
        movementRight = false;
        var inst = Instantiate(Orb, rightHandObject.transform.position, Quaternion.identity);
        Orb b = inst.GetComponent<Orb>();
        b.Shoot(rightHandObject.transform.forward);
    }

    private void ShotLeft()
    {
        movementLeft = false;
        var inst = Instantiate(Orb, LeftHandObject.transform.position, Quaternion.identity);
        Orb b = inst.GetComponent<Orb>();
        b.Shoot(LeftHandObject.transform.forward);
    }

    private void DrawLeftLine()
    {
        Debug.Log("left pressed");
        movementLeft = true;
        Debug.DrawRay(LeftHandObject.transform.position, LeftHandObject.transform.forward, Color.red);
        Debug.DrawRay(LeftHandObject.transform.position, - LeftHandObject.transform.forward, Color.green);
        Debug.DrawRay(LeftHandObject.transform.position, - LeftHandObject.transform.right, Color.blue);
        Debug.DrawRay(LeftHandObject.transform.position,LeftHandObject.transform.right, Color.yellow);
    }

    private void DrawRightLine()
    {
        Debug.Log("right pressed");
        movementRight = true;
        Debug.DrawRay(rightHandObject.transform.position, rightHandObject.transform.forward, Color.red);
        Debug.DrawRay(rightHandObject.transform.position, - rightHandObject.transform.forward, Color.green);
        Debug.DrawRay(rightHandObject.transform.position, - rightHandObject.transform.right, Color.blue);
        Debug.DrawRay(rightHandObject.transform.position,rightHandObject.transform.right, Color.yellow);
    }
}
