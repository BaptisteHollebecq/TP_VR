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

    private float _leftPressed = 0;
    private float _rightPressed = 0;

    private void OnLeftGripPressed(InputValue value)
    {
        _leftPressed = value.Get<float>();
        Debug.Log(_leftPressed);
    }

    private void OnRightGripPressed(InputValue value)
    {
        _rightPressed = value.Get<float>();
        Debug.Log(_rightPressed);
    }

    private void Update()
    {
        if (_leftPressed > MIN_TRIGGER && !LeftHand.Holding)
        {
            Debug.Log("Grab object");
            LeftHand.GrabObject();
        }

        if (_leftPressed < MIN_TRIGGER  && LeftHand.Holding)
        {
            LeftHand.DropObject();
            Debug.Log("Drop object");
        }

        if (_rightPressed > MIN_TRIGGER && !RightHand.Holding)
        {
            RightHand.GrabObject();
            Debug.Log("Grab object");
        }

        if (_rightPressed < MIN_TRIGGER && RightHand.Holding)
        {
            RightHand.DropObject();
            Debug.Log("Drop object");
        }
    }
}
