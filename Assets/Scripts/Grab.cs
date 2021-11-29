using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Grab : MonoBehaviour
{
    [SerializeField]
    private InputActionReference m_ActionReference;
    public InputActionReference actionReference { get => m_ActionReference; set => m_ActionReference = value; }

    //public GrabManager manager;

    private bool grip = false;
    public GameObject inHand = null;
    private Rigidbody _rb;

    public Vector3 velocity = Vector3.zero;
    private Vector3 lastpos = Vector3.zero;

    private void Awake()
    {
        actionReference.action.Enable();
    }

    void Update()
    {
        lastpos = transform.position;

        if (actionReference != null && actionReference.action != null)
        {
            float value = actionReference.action.ReadValue<float>();
            Debug.Log(value);
            if (value > .9f)
            {
                grip = true;
                if (inHand != null)
                {
                    inHand.transform.parent = transform.parent;
                    Rigidbody rb = inHand.GetComponent<Rigidbody>();
                    rb.isKinematic = true;
                    rb.useGravity = false;
                }
            }
            if (value < .5f && grip)
            {
                grip = false;
                if (inHand != null)
                {
                    inHand.transform.parent = null;
                    Rigidbody rb = inHand.GetComponent<Rigidbody>();
                    rb.isKinematic = false;
                    rb.useGravity = true;
                    //rb.velocity = ((transform.position - lastpos) / Time.deltaTime) * 50000;
                    inHand = null;
                }
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Grab")
        {
            Debug.Log(other.gameObject);
            inHand = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Grab")
        {
            inHand = null;
        }
    }
}
