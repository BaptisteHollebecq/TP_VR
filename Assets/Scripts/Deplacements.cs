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

    public InputActionReference leftTrigger;
    public InputActionReference rightTrigger;

    private bool activeLeft = false;
    private bool activeRight = false;


    private void Update()
    {
        bool activeLeft = leftTrigger.action.ReadValue<bool>();
        bool activeRight = rightTrigger.action.ReadValue<bool>();

        if (activeLeft)
            AimMovement("left");
        else if (activeRight)
            AimMovement("right");
    }

    private void AimMovement(string side)
    {
        Debug.Log(side);
    }
}
