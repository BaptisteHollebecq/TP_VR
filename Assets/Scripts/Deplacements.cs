using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.InputSystem;

public class Deplacements : MonoBehaviour
{
    public float headHeight = 1.65f;

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
        RaycastHit hit;
        if (Physics.Raycast(transform.position, - transform.up, out hit))
        {
            b.height = (hit.point - transform.position).magnitude;
        }
        b.playerRig = gameObject;
        b.Shoot(rightHandObject.transform.forward);
    }

    private void ShotLeft()
    {
        movementLeft = false;
        var inst = Instantiate(Orb, LeftHandObject.transform.position, Quaternion.identity);
        Orb b = inst.GetComponent<Orb>();
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit))
        {
            b.height = (hit.point - transform.position).magnitude;
        }
        b.playerRig = gameObject;
        b.Shoot(LeftHandObject.transform.forward);
    }

    private void DrawLeftLine()
    {
        movementLeft = true;
    }

    private void DrawRightLine()
    {
        movementRight = true;
    }
}
