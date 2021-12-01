using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Grab : MonoBehaviour
{
    [SerializeField]
    private InputActionReference m_ActionReference;
    public InputActionReference actionReference { get => m_ActionReference; set => m_ActionReference = value; }

    public InputActionReference velocityReference { get => m_ActionReference; set => m_ActionReference = value; }
    //public GrabManager manager;

    public bool grip = false;
    public GameObject inHand = null;
    private Rigidbody _rb;

    public Vector3 velocity = Vector3.zero;

    private void Awake()
    {
        actionReference.action.Enable();
        velocityReference.action.Enable();
    }

    void Update()
    {
        if (velocityReference != null && velocityReference.action != null)
        {
            velocity = velocityReference.action.ReadValue<Vector3>();
        }

        if (actionReference != null && actionReference.action != null)
        {
            float value = actionReference.action.ReadValue<float>();
            Debug.Log(value);
            if (value > .99f)
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
            if (value < .95f && grip)
            {
                grip = false;
                if (inHand != null)
                {
                    inHand.transform.parent = null;
                    Rigidbody rb = inHand.GetComponent<Rigidbody>();
                    rb.isKinematic = false;
                    rb.useGravity = true;
                    rb.velocity = velocity;
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
