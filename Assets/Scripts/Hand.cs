using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    [SerializeField]
    public bool Holding = false;

    private GameObject _object = null;
    private Rigidbody _rb;


    private void OnTriggerEnter(Collider other)
    {
        _object = other.gameObject;
        Debug.Log("TRIGGER OBJECT");
    }
    
    private void OnTriggerExit(Collider other)
    {
        _object = null;
        Debug.Log("TRIGGER OFF OBJECT");
    }

    public void GrabObject()
    {
        if (_object != null /*&& _object.layer.Equals("Grabbable")*/)
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
