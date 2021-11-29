using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerVelocity : MonoBehaviour
{
    public InputActionProperty VelocityProperty;

    public Vector3 Velocity { get; private set; } = Vector3.zero;

    private void Update()
    {
        Velocity = VelocityProperty.action.ReadValue<Vector3>();
    }
}
