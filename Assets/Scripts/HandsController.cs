using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.InputSystem;

public class HandsController : MonoBehaviour
{
    public Hand LeftHand;
    public Hand RightHand;

    public static float MIN_TRIGGER = 0.3f;


    private bool _leftPressed = false;
    private bool _rightPressed = false;

    private void OnLeftGripPressed(InputValue value)
    {
        _leftPressed = value.Get<bool>();
        Debug.Log(_leftPressed);
    }

    private void OnRightGripPressed(InputValue value)
    {
        _rightPressed = value.Get<bool>();
        Debug.Log(_rightPressed);
    }

    private void Update()
    {
        if (_leftPressed && !RightHand.Holding)
        {
            Debug.Log("Grab object");
            LeftHand.GrabObject();
        }

        if (_leftPressed  && LeftHand.Holding)
        {
            LeftHand.DropObject();
            Debug.Log("Drop object");
        }

        if (_rightPressed  && !RightHand.Holding)
        {
            RightHand.GrabObject();
            Debug.Log("Grab object");
        }

        if (_rightPressed  && RightHand.Holding)
        {
            RightHand.DropObject();
            Debug.Log("Drop object");
        }
    }
}
