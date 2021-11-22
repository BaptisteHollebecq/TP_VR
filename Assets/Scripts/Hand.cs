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
        //if (/*_object.tag.Equals("Grab")*/)
        //{
            _object = other.gameObject;
            Debug.Log("TRIGGER OBJECT");
        //}
    }
    
    private void OnTriggerExit(Collider other)
    {
        _object = null;
        Debug.Log("TRIGGER OFF OBJECT");
    }

    public void GrabObject()
    {
        if (_object != null /*&& _object.tag.Equals("Grab")*/)
        {
            _rb = _object.GetComponent<Rigidbody>();
            _rb.isKinematic = true;
            _object.transform.parent = this.transform;
            Holding = true;
            Debug.Log("GRAB OBJECT");
        }
    }

    private Vector3 _prevPosition;

    private void Update()
    {
        _prevPosition = transform.position;
    }

    public void DropObject()
    {
        _object.transform.parent = null;
        _rb.isKinematic = false;
        Vector3 vel = (transform.position - _prevPosition) / Time.deltaTime;
        _rb.AddForce(vel);
        Holding = false;
        Debug.Log("DROP OBJECT");
    }
}
