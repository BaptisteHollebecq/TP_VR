using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    [SerializeField]
    public bool Holding = false;

    private GameObject _object = null;
    private Rigidbody _rb;


    private void OnCollisionEnter(Collision collision)
    {
        if (_object != null)
        {
            return;
        }

        _object = collision.gameObject;
        Debug.Log("COLLIDE OBJECT");
    }

    private void OnCollisionExit(Collision collision)
    {
        _object = null;
        Debug.Log("COLLIDE OFF OBJECT");
    }

    public void GrabObject()
    {
        if (_object != null)
        {
            _rb = _object.GetComponent<Rigidbody>();
            _rb.isKinematic = true;
            _object.transform.parent = this.transform;
            Holding = true;
            Debug.Log("GRAB OBJECT");
        }
    }

    public void DropObject()
    {
        _object.transform.parent = null;
        _rb.isKinematic = false;
        Holding = false;
        Debug.Log("DROP OBJECT");
    }
}
