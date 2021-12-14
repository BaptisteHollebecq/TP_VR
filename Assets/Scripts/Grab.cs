using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Grab : MonoBehaviour
{
    [SerializeField]
    private InputActionReference m_ActionReference;

    [SerializeField]
    private InputActionReference m_VelocityReference;

    public InputActionReference actionReference { get => m_ActionReference; set => m_ActionReference = value; }

    public InputActionReference velocityReference { get => m_VelocityReference; set => m_VelocityReference = value; }

    public LayerMask GrabLayer;

    public bool grip = false;
    public GameObject DirectionIndicator;
    public Rigidbody inHand = null;
    private Rigidbody _rb;

    public Vector3 velocity = Vector3.zero;

    private void Awake()
    {
        actionReference.action.Enable();
        velocityReference.action.Enable();
    }

    void Update()
    {

        if (actionReference != null && actionReference.action != null)
        {
            float value = actionReference.action.ReadValue<float>();
            if (value > .95f && !grip)
                grip = true;
            else if (value < .9f && grip)
            {
                grip = false;
                if (inHand)
                {
                    inHand.transform.SetParent(null);
                    inHand.useGravity = true;
                    inHand.isKinematic = false;
                    inHand.velocity = velocity * 1.5f;
                }
            }

        }
    }

    private void FixedUpdate()
    {
        if (!grip)
        {
           Collider[] colliders = Physics.OverlapSphere(transform.position, .05f, GrabLayer);
            if (colliders.Length > 0)
                inHand = colliders[0].transform.GetComponent<Rigidbody>();
            else
                inHand = null;
        }
        else
        {
            if (inHand)
            {
                if (inHand.transform.parent != transform.parent)
                {
                    inHand.transform.SetParent(transform.parent);
                    inHand.isKinematic = true;
                    inHand.useGravity = false;
                }

                if (velocityReference != null && velocityReference.action != null)
                {
                    velocity = velocityReference.action.ReadValue<Vector3>();
                }

            }
        }
    }

    public void ShowIndicator()
    {
        DirectionIndicator.SetActive(true);
    }

    public void HideIndicator()
    {
        DirectionIndicator.SetActive(false);
    }
}
