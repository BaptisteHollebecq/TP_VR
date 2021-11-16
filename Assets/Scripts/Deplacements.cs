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

    private void OnLeftTriggerPressed()
    {
        Debug.Log("Left Trigger pressed");
    }
}
