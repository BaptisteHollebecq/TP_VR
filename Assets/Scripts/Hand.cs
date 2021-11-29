using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public bool Holding = false;
    public GameObject Object = null;

    private Rigidbody _rb;

    private void OnTriggerEnter(Collider other)
    {
        if (!Holding)
        {
            Object = other.gameObject;
            Debug.Log("TRIGGER OBJECT");
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (!Holding)
        {
            Object = null;
            Debug.Log("TRIGGER OFF OBJECT");
        }
    }

    public void GrabObject()
    {
        if (Object != null && Object.tag == "Grab")
        {
            _rb = Object.GetComponent<Rigidbody>();
            _rb.isKinematic = true;
            Object.transform.parent = this.transform;
            Holding = true;
            Debug.Log("GRAB OBJECT");
        }
    }

    public void DropObject()
    {
        Object.transform.parent = null;
        _rb.isKinematic = false;
        Holding = false;
        Debug.Log("DROP OBJECT");
    }
}
