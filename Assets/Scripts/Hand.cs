using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    [SerializeField]
    public bool Holding = false;

    private GameObject _object;
    private Transform _objectParentTransform;


    private void OnCollisionEnter(Collision collision)
    {
        if (_object != null)
        {
            return;
        }

        _object = collision.gameObject;
    }

    private void OnCollisionExit(Collision collision)
    {
        _object = null;
    }

    public void GrabObject()
    {
        if (_object != null)
        {
            _objectParentTransform = _object.transform.parent;
            _object.transform.parent = this.transform;
            Holding = true;
        }
    }

    public void DropObject()
    {
        _object.transform.parent = _objectParentTransform;
        Holding = false;
    }
}
