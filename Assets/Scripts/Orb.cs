using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb : MonoBehaviour
{

    public float Power = 10f;

    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void Shoot(Vector3 direction)
    {
        _rb.AddForce(direction * Power, ForceMode.Impulse);
    }
}
