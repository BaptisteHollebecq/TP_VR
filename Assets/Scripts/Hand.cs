using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    [SerializeField]
    public bool Holding = false;

    public GameObject Object = null;
    private Rigidbody _rb;
    private float _grabLayer = 9;


    private void OnTriggerEnter(Collider other)
    {
        Object = other.gameObject;
        Debug.Log("TRIGGER OBJECT");
    }
    
    private void OnTriggerExit(Collider other)
    {
        Object = null;
        Debug.Log("TRIGGER OFF OBJECT");
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

    private Vector3 _prevPosition;

    private void Update()
    {
        _prevPosition = transform.position;
    }

    public void DropObject()
    {
        Object.transform.parent = null;
        _rb.isKinematic = false;
        Vector3 vel = (transform.position - _prevPosition) / Time.deltaTime;
        _rb.AddForce(vel);
        Holding = false;
        Debug.Log("DROP OBJECT");
    }
}
