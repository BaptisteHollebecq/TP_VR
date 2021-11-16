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

    private void OnLeftTriggerPressed(InputValue value)
    {
        leftpressed = value.Get<float>();
        Debug.Log(leftpressed);
    }

    private void Update()
    {
        if (leftpressed > .5f)
            Debug.Log("pressed");
    }
}
